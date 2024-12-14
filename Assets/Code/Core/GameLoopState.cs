using Code.Core.StateMachine.Phases;
using Code.PlayerInput;

namespace Code.Core
{
  public class GameLoopState : IGamePhase, IEnterPhase, IExitPhase
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