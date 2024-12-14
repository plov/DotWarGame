using Code.Scenes;
using Code.PostponedTasks;
using Code.Core.StateMachine;
using Code.Core.StateMachine.Phases;

namespace Code.Core
{
  public class LoadSceneState : IGamePhase, IPayloadState<string>
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _loader;

    public LoadSceneState(IGameStateMachine stateMachine, ISceneLoader loader)
    {
      _stateMachine = stateMachine;
      _loader = loader;
    }

    public void Enter(string payload) =>
      Postponer.Wait(_loader.LoadingScreen.Appear)
               .Wait(() => _loader.Load(payload))
               .Wait(_loader.LoadingScreen.Fade)
               .Do(_stateMachine.Enter<GameLoopState>);
  }
}