using Code.Core;
using Code.Core.StateMachine;
using Code.AssetsManagement;
using Code.Scenes;
using Code.Extensions;
using Code.Game.Data;
using Code.PlayerInput;
using UnityEngine.InputSystem;
using Zenject;
using Zenject.SpaceFighter;

namespace code
{
    public class ProjectInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameStateMachine();

            Container.BindServiceNLazy<Game>();
            Container.BindServiceNLazy<GameStateData>();
            //Container.BindService<GameData>();
            Container.BindServiceNLazy<SceneLoader>();
            Container.BindServiceNLazy<Input>();
            Container.BindServiceNLazy<BuildersFactory>();
            Container.BindServiceNLazy<AssetProvider>();
            //Container.BindService<AudioPlayer>();
            
        }

        private void BindGameStateMachine()
        {
            Container.BindServiceNLazy<GameStateMachine>();
            Container.FullBind<BootstrapState>();
            Container.FullBind<GameLoopState>();
            Container.FullBind<LoadSceneState>();
            Container.FullBind<LoadSettingsState>();
            Container.FullBind<LoadLevelState>();
        }
    }
}