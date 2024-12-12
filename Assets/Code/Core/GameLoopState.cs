using Code.PlayerInput;
using Code.Core.StateMachine.States;

namespace Code.Core
{
  public class GameLoopState : IGameState, IEnterState, IExitState
  {
    private readonly IInput _input;

    public GameLoopState(IInput input) =>
      _input = input;

    public void Enter() =>
      _input.Enabled = true;

    public void Exit() =>
      _input.Enabled = false;
  }
}