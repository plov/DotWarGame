using Code.Core.StateMachine.Phases;
using Code.SmartDebug;

namespace Code.Core.StateMachine
{
    public class GameStateMachine : SimpleStateMachine<IGamePhase>, IGameStateMachine
    {
        protected override StateMachineLogger Logger { get; } = new(DSenders.GameStateMachine);
    }
}