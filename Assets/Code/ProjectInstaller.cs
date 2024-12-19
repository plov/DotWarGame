using Code.Core;
using Code.Core.StateMachine;
using Code.AssetsManagement;
using Code.Scenes;
using Code.Extensions;
using Code.PlayerInput;
using Zenject;
using Zenject.SpaceFighter;

namespace code
{
    public class ProjectInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();

            Container.BindService<Game>();
            //Container.BindService<GameData>();
            Container.BindService<SceneLoader>();
            Container.BindService<Input>();
            Container.BindService<BuildersFactory>();
            Container.BindService<AssetProvider>();
            //Container.BindService<AudioPlayer>();
            
        }

        private void BindGameStateMachine()
        {
            Container.BindService<GameStateMachine>();
            Container.FullBind<BootstrapState>();
            Container.FullBind<GameLoopState>();
            Container.FullBind<LoadSceneState>();
            Container.FullBind<LoadSettingsState>();
            Container.FullBind<LoadLevelState>();
        }
    }
}