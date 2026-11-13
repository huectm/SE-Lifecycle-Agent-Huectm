namespace FreshFood.Reposistory.Entities;

public partial class AuditLog
{
    public string LogId { get; set; } = string.Empty;
    public int? StaffId { get; set; }
    public string ActionType { get; set; } = string.Empty;
    public string EntityName { get; set; } = string.Empty;
    public string RecordIdentifier { get; set; } = string.Empty;
    public string OldValues { get; set; } = string.Empty;
    public string NewValues { get; set; } = string.Empty;
    public string IpAddress { get; set; } = string.Empty;
    public DateTimeOffset Timestamp { get; set; }
    public string? CustomerId { get; set; }
    public string ActorType { get; set; } = string.Empty;
}
