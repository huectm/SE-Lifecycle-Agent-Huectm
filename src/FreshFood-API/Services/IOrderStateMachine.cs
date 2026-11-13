namespace FreshFood.Api.Services;

public interface IOrderStateMachine
{
    Task<StateMachineResult> ProcessEventAsync(TransitionSnapshot snapshot, StateMachineEvent message, CancellationToken signal);
    OrderStateSnapshot? CurrentState();
}
