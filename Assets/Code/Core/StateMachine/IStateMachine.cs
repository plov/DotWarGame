using Code.Core.StateMachine.States;

namespace Code.Core.StateMachine
{
    public interface IStateMachine<in T>
    {
        void RegisterState(T state);
        void Enter<TState>() where TState : class, T, IEnterState;
    }
}