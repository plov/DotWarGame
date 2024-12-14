using Code.Core;
using Code.Core.StateMachine;
using Code.Scenes;
using Code.SmartDebug;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
    public class Settings : MonoBehaviour
    {
        private IGameStateMachine _stateMachine; 
        [SerializeField]
        private GameObject _closeBtnObject;
        private Button _closeBtn;
                                                                                    
        [Inject]                                                                           
        private void Construct(IGameStateMachine stateMachine) =>                          
            _stateMachine = stateMachine;

        private void Awake()
        {
            _closeBtn = _closeBtnObject.GetComponent<Button>();
            _closeBtn.onClick.AddListener(CloseBtnClick);
        }
        
        protected void CloseBtnClick()                                                  
        {                                                                                  
            DLogger.Message(DSenders.UI).WithText("Settings CloseBtn clicked").Log();            
            _stateMachine.Enter<LoadSceneState, string>(ScenesList.Main);                                    
        }                                                                                  
    }
}