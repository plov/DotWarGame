using System.Collections.Generic;
using Code.SmartDebug;
using Code.Core.StateMachine;
using Code.Core.StateMachine.States;

using Zenject;

namespace Code.Core
{
    public class Game: IInitializable
    {
        private readonly List<IGameState> _states;
        private readonly IGameStateMachine _stateMachine;

        public Game(IGameStateMachine stateMachine, List<IGameState> states)
        {
            _states = states;
            _stateMachine = stateMachine;
        }

        public void Initialize()
        {
            InitStateMachine();
            StartGame();
        }

        private void InitStateMachine()
        {
            foreach (IGameState state in _states)
                _stateMachine.RegisterState(state);
        }

        private void StartGame()
        {
            DLogger.Message(DSenders.Application).WithText("Start Game").Log();
            _stateMachine.Enter<BootstrapState>();
        }
    }
}