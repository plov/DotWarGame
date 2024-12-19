using Code.Core;
using Code.Core.StateMachine;
using Code.Scenes;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Game.Level
{
    public class PausePopup : MonoBehaviour
    {
        [SerializeField] private GameObject _exitBtnObj;
        private Button _exitBtn;
        [SerializeField] private GameObject _resumeBtnObj;
        private Button _resumeBtn;
        
        private IGameStateMachine _stateMachine;
        
        [Inject]
        private void Construct(IGameStateMachine stateMachine) =>
            _stateMachine = stateMachine;

        private void Awake()
        {
            _exitBtn = _exitBtnObj.GetComponent<Button>();
            _exitBtn.onClick.AddListener(ExitBtmClick);
            _resumeBtn = _resumeBtnObj.GetComponent<Button>();
            _resumeBtn.onClick.AddListener(ResumeBtnClick);
        }

        private void  ExitBtmClick()
        {
            _stateMachine.Enter<LoadSceneState, string>(ScenesList.Main);
        }

        private void ResumeBtnClick()
        {
            //event for resume
            gameObject.SetActive(false);
        }
    }
}