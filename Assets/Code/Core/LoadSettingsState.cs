using Code.Core.StateMachine;
using Code.Core.StateMachine.Phases;
using Code.PostponedTasks;
using Code.Scenes;

namespace Code.Core
{
    public class LoadSettingsState : IGamePhase, IEnterPhase
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _loader;

        public LoadSettingsState(IGameStateMachine stateMachine, ISceneLoader loader)
        {
            _stateMachine = stateMachine;
            _loader = loader;
        }

        public void Enter()
        {
            Postponer.Wait(_loader.LoadingScreen.Appear)
                .Wait(() => _loader.Load(ScenesList.Settings))
                .Wait(_loader.LoadingScreen.Fade)
                .Do(_stateMachine.Enter<GameLoopState>);
        }
    }
}