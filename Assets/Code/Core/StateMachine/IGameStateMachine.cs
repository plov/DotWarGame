using Code.Core.StateMachine.Phases;

namespace Code.Core.StateMachine
{
    public interface IGameStateMachine : IStateMachine<IGamePhase>, IPayloadStateMachine<IGamePhase>
    {
    }
}