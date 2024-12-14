using Code.Core.StateMachine.Phases;

namespace Code.Core.StateMachine
{
    public interface IPayloadStateMachine<in T>
    {
        void Enter<TState, TPayload>(TPayload payload) where TState : class, T, IPayloadState<TPayload>;
    }
}