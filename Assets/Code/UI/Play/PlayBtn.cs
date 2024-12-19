using Code.Core;
using Code.Core.StateMachine;
using Code.SmartDebug;
using Zenject;

namespace Code.UI.Play
{
    public class PlayBtn : BaseBtn
    {
        private IGameStateMachine _stateMachine;

        [Inject]
        private void Construct(IGameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        protected override void OnClick()
        {
            DLogger.Message(DSenders.UI).WithText("Play Button clicked").Log();
            _stateMachine.Enter<LoadLevelState>();
        }
    }
}