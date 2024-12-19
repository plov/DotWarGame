using Cysharp.Threading.Tasks;
using Code.Scenes;
using Code.PostponedTasks;
using Code.Core.StateMachine;
using Code.Core.StateMachine.Phases;

namespace Code.Core
{
    public class BootstrapState : IGamePhase, IEnterPhase
    {
        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _loader;

        public BootstrapState(IGameStateMachine stateMachine, ISceneLoader loader)
        {
            _stateMachine = stateMachine;
            _loader = loader;
        }

        public void Enter()
        {
            if (MainConfig.ShowSplashScreen)
                Postponer.Wait(() => _loader.Load(ScenesList.SplashScreen))
                    .Wait(ShowSplashScreen)
                    .Do(LoadMain);
            else
                LoadMain();
        }

        private static async UniTask ShowSplashScreen() =>
            await UniTask.WaitForSeconds(MainConfig.LogoDuration);

        private void LoadMain() =>
            _stateMachine.Enter<LoadSceneState, string>(ScenesList.Main);
    }
}