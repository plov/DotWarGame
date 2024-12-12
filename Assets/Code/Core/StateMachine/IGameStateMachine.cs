using Code.Core.StateMachine.States;

namespace Code.Core.StateMachine
{
    public interface IGameStateMachine : IStateMachine<IGameState>, IPayloadStateMachine<IGameState>
    {
    }
}