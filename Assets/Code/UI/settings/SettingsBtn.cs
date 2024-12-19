using Code.Core;
using Code.Core.StateMachine;
using Code.SmartDebug;
using Zenject;

namespace Code.UI.Settings
{
    public class SettingsBtn : BaseBtn
    {
        private IGameStateMachine _stateMachine;

        [Inject]
        private void Construct(IGameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        protected override void OnClick()
        {
            DLogger.Message(DSenders.UI).WithText("SettingsBtn clicked").Log();
            _stateMachine.Enter<LoadSettingsState>();
        }
    }
}