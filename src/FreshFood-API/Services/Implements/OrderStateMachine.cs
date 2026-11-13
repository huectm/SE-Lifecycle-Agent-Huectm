using System.Reflection;
using System.Text.RegularExpressions;

namespace FreshFood.Api.Services.Implements;

public sealed class OrderStateMachine(IOrderLifecycleRepository repository) : IOrderStateMachine
{
    private sealed record FollowUp(string Event, string Region);
    private sealed record Rule(string Id, string Region, string Source, string[] Events, string Guard, string Action, string Target, FollowUp[] FollowUps);
    private static readonly Rule[] Table = LoadTable();
    private TransitionSnapshot? snapshot;
    private static Rule[] LoadTable()
    {
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("FreshFood.Api.OrderTransitions.json")!;
        var rows = JsonSerializer.Deserialize<Rule[]>(stream)!;
        if (rows.Select(r => r.Id).Distinct().Count() != rows.Length) throw new InvalidOperationException("Duplicate transition row.");
        return rows;
    }
    private static string Canonical(string value) => Regex.Replace(value, "([a-z])([A-Z])", "$1_$2", RegexOptions.None, TimeSpan.FromMilliseconds(100)).ToLowerInvariant();
    public OrderStateSnapshot? CurrentState() => snapshot is null ? null : new()
    {
        FulfillmentState = snapshot.Order.OrderStatus,
        PaymentState = snapshot.Order.PaymentStatus,
        WorkflowNode = snapshot.WorkflowNode,
        FulfillmentCompleted = snapshot.FulfillmentCompleted || snapshot.Order.OrderStatus is OrderStatus.Delivered or OrderStatus.Cancelled or OrderStatus.Returned
    };
    private static string State(string region, TransitionSnapshot s) => region switch
    {
        "fulfillment" => s.FulfillmentCompleted ? "final_" + Canonical(s.Order.OrderStatus.ToString())
            : s.WorkflowNode is "initial" or "payment_choice" ? s.WorkflowNode : Canonical(s.Order.OrderStatus.ToString()),
        "payment" => s.Initial && !s.PaymentInitialized ? "pay_initial" : Canonical(s.Order.PaymentStatus.ToString()),
        _ => "refund_initial"
    };
    private static bool Guard(string guard, TransitionSnapshot s) => guard switch
    {
        "always" => true,
        "unpaid" => !s.VerifiedPayment,
        "paid" => s.VerifiedPayment,
        "initialPayment" => s.Order.OrderStatus is OrderStatus.PendingUnpaid or OrderStatus.PendingPaid,
        "verifiedInitialPayment" => s.Initial && s.VerifiedPayment && s.Order.OrderStatus == OrderStatus.PendingPaid,
        "ownedCustomer" => s.ActorId == s.CustomerId && s.Order.CustomerId == s.CustomerId,
        "plannedStock" => s.ActorId == s.CustomerId && s.Order.Details.Count > 0 && s.Order.Details.All(l => l.Quantity > 0)
            && s.Order.Details.GroupBy(l => l.BatchId).All(g => s.Batches.Any(b => b.BatchId == g.Key && g.Sum(l => l.Quantity) <= b.CurrentStock - b.ReservedStock)),
        _ => false
    };
    private async Task Apply(Rule rule, TransitionSnapshot s, StateMachineEvent message, CancellationToken ct)
    {
        switch (rule.Action)
        {
            case "accept": s.WorkflowNode = rule.Target; break;
            case "enterInitial": s.Order.OrderStatus = Enum.Parse<OrderStatus>(rule.Target.Replace("_", ""), true); s.WorkflowNode = rule.Target; break;
            case "initializePayment": s.Order.PaymentStatus = PaymentStatus.Unpaid; s.PaymentInitialized = true; break;
            case "recordVerifiedInitialPayment": s.Order.RecordPayment(PaymentStatus.Unpaid, PaymentStatus.Paid); break;
            case "completeFulfillment": s.FulfillmentCompleted = true; s.WorkflowNode = rule.Target; break;
            case "cancel":
                var batches = await repository.LockReservedBatchesAsync(s.Order.OrderId, ct);
                foreach (var line in s.Order.Details)
                    (batches.SingleOrDefault(b => b.BatchId == line.BatchId) ?? throw new DomainException("RESERVATION_INCONSISTENT", 409)).ReleaseReservation(line.Quantity);
                var previous = s.Order.OrderStatus;
                s.Order.Cancel(previous, message.Reason ?? "");
                await repository.SaveBatchesAsync(batches, ct);
                await repository.SaveAsync(s.Order, ct);
                await repository.AppendAuditAsync(new AuditLog
                {
                    CustomerId = s.CustomerId,
                    RecordIdentifier = s.Order.OrderId,
                    OldValues = JsonSerializer.Serialize(new { order_status = Canonical(previous.ToString()).ToUpperInvariant() }),
                    NewValues = JsonSerializer.Serialize(new { order_status = "CANCELLED", cancellation_reason = message.Reason })
                }, ct);
                break;
            default: throw new DomainException("STATE_EVENT_NOT_IMPLEMENTED", 503);
        }
    }
    private async Task Process(TransitionSnapshot s, StateMachineEvent message, string? region, HashSet<string> visited, List<Rule> applied, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();
        var candidates = Table.Where(r => (region is null || r.Region == region) && r.Source == State(r.Region, s) && r.Events.Contains(message.Event)).ToList();
        if (candidates.Count == 0) throw new DomainException("STATE_EVENT_NOT_ALLOWED", 409);
        if (candidates.Any(r => r.Action == "deferred")) throw new DomainException("STATE_EVENT_NOT_IMPLEMENTED", 503);
        var selected = candidates.Where(r => Guard(r.Guard, s)).ToList();
        if (selected.Count == 0) throw new DomainException("STATE_GUARD_REJECTED", 409);
        if (selected.GroupBy(r => r.Region).Any(g => g.Count() != 1)) throw new DomainException("AMBIGUOUS_STATE_TRANSITION", 500);
        foreach (var rule in selected)
        {
            if (!visited.Add(rule.Region + ":" + rule.Source + ":" + message.Event)) throw new DomainException("STATE_MACHINE_COMPLETION_CYCLE", 500);
            if (!await repository.RecordEventOnceAsync(message.AggregateId, message.EventId, rule.Id, ct)) throw new DomainException("INCONSISTENT_TRANSITION_EVIDENCE", 409);
            await Apply(rule, s, message, ct); applied.Add(rule);
            foreach (var next in rule.FollowUps) await Process(s, new() { Event = next.Event, AggregateId = message.AggregateId, EventId = message.EventId, Reason = message.Reason }, next.Region, visited, applied, ct);
        }
    }
    public async Task<StateMachineResult> ProcessEventAsync(TransitionSnapshot context, StateMachineEvent message, CancellationToken signal)
    {
        if (message.AggregateId != context.AggregateId) throw new DomainException("AGGREGATE_MISMATCH", 403);
        if (string.IsNullOrWhiteSpace(message.Event) || message.Event.StartsWith("__", StringComparison.Ordinal)) throw new DomainException("INVALID_STATE_EVENT");
        if (snapshot is not null && (snapshot.AggregateId != context.AggregateId || snapshot.CustomerId != context.CustomerId)) throw new DomainException("STATE_MACHINE_AGGREGATE_MISMATCH", 403);
        var previous = snapshot; snapshot = context; var applied = new List<Rule>();
        try
        {
            await Process(context, message, null, [], applied, signal);
            return new() { Applied = applied.Count > 0, TransitionIds = applied.Select(r => r.Id).ToList(), Actions = applied.Select(r => r.Action).ToList(), State = CurrentState()! };
        }
        catch { snapshot = previous; throw; }
    }
}
