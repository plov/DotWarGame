using System.Collections.Generic;
using Zenject;

namespace Code.Core.StateMachine
{
    public class StateMachineInitializer<T> : IInitializable
    {
        private readonly IStateMachine<T> _stateMachine;
        private readonly List<T> _states;

        public StateMachineInitializer(IStateMachine<T> stateMachine, List<T> states)
        {
            _states = states;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            RegisterStates();
        }

        private void RegisterStates()
        {
            foreach (var state in _states)
                _stateMachine.RegisterState(state);
        }
    }
}