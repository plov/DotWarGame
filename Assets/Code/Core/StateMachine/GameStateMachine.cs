using Code.Core.StateMachine.States;
using Code.SmartDebug;

namespace Code.Core.StateMachine
{
    public class GameStateMachine : SimpleStateMachine<IGameState>, IGameStateMachine
    {
        protected override StateMachineLogger Logger { get; } = new(DSenders.GameStateMachine);
    }
}