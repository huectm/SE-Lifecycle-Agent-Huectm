namespace FreshFood.Api.DTOs;

public class StateMachineEvent
{
    public string Event { get; set; } = string.Empty;
    public string AggregateId { get; set; } = string.Empty;
    public string EventId { get; set; } = string.Empty;
    public string? Reason { get; set; }
}
