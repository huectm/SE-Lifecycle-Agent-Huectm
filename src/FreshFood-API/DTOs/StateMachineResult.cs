namespace FreshFood.Api.DTOs;

public class StateMachineResult
{
    public bool Applied { get; set; }
    public bool Duplicate { get; set; }
    public List<string> TransitionIds { get; set; } = [];
    public OrderStateSnapshot State { get; set; } = default!;
    public List<string> Actions { get; set; } = [];
}
