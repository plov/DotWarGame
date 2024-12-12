using Code.Core.StateMachine.States;

namespace Code.Core.StateMachine
{
    public interface IPayloadStateMachine<in T>
    {
        void Enter<TState, TPayload>(TPayload payload) where TState : class, T, IPayloadState<TPayload>;
    }
}