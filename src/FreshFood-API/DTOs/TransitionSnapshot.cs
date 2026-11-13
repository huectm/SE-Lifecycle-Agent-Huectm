namespace FreshFood.Api.DTOs;

// Server-created execution context. Never accepted as an HTTP request DTO.
public sealed class TransitionSnapshot
{
    internal TransitionSnapshot(string aggregateId, string customerId, Order order, List<BatchInventory>? batches = null, bool initial = false)
    {
        AggregateId = aggregateId; CustomerId = customerId; ActorId = customerId;
        Order = order; Batches = batches ?? []; Initial = initial; WorkflowNode = initial ? "initial" : null;
    }
    public string AggregateId { get; }
    public string CustomerId { get; }
    public string ActorId { get; }
    internal Order Order { get; }
    internal List<BatchInventory> Batches { get; }
    internal string? WorkflowNode { get; set; }
    internal bool PaymentInitialized { get; set; }
    internal bool Initial { get; }
    internal bool FulfillmentCompleted { get; set; }
    internal bool VerifiedPayment { get; init; }
}
