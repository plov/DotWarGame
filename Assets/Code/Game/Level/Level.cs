using Code.SmartDebug;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Game.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject PauseObj;
        private Button _pauseBtn;
        [SerializeField] private GameObject PausePopupObj;
        
        private void Awake()
        {
            _pauseBtn = PauseObj.GetComponent<Button>();
            _pauseBtn.onClick.AddListener(PauseBtnClick);
        }
        
        protected void PauseBtnClick()
        {
            DLogger.Message(DSenders.UI).WithText("Level PauseBtn clicked").Log();
            PausePopupObj.SetActive(true);
        }
    }
}