
using System.Collections.Generic;
using Code.Core.Communication;
using Code.Game.Level.Ways;
using Code.SmartDebug;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Game.Level
{
    public class Level : MonoBehaviour
    {
        private List<GameObject> _ways = new List<GameObject>();
        private WayCreator _wayCreator;
         

        [SerializeField] private GameObject pauseBtnObj;
        private Button _pauseBtn;
        [SerializeField] private GameObject pausePopupObj;
        [SerializeField] private GameObject[] dotPrefabsObj;
        [SerializeField] private GameObject wayPrefab;
        [SerializeField] private GameObject wayCreatorPrefab;
        [SerializeField] private  Canvas canvas;
        
        private void Awake()
        {
            Subscribe();
            WayCreatorInit();
            _pauseBtn = pauseBtnObj.GetComponent<Button>();
            _pauseBtn.onClick.AddListener(PauseBtnClick);
        }

        private void WayCreatorInit()
        {
            GameObject wayCreatorObject = Instantiate(wayCreatorPrefab);
            _wayCreator = wayCreatorObject.GetComponent<WayCreator>();
            _wayCreator.wayPrefab = wayPrefab;
            _wayCreator.canvas = canvas;
        }

        public void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            GameEventBus.Subscribe(GameEvents.DotUp, OnPointerUp);
        }

        private void Unsubscribe()
        {
            GameEventBus.Unsubscribe(GameEvents.DotUp, OnPointerUp);
        }

        private void PauseBtnClick()
        {
            DLogger.Message(DSenders.UI).WithText("Level PauseBtn clicked").Log();
            pausePopupObj.SetActive(true);
        }

        private void OnPointerUp(object data)
        {
            var dot = (data) as DotView;
            if (dot != null)
            {
                dot.Select();
                
                CreateWay(dot);
            }
        }

        private void CreateWay(DotView dot)
        {
            var dotObject = _wayCreator.Process(dot);
            if (dotObject != null)
            {
                _ways.Add(dotObject);
            }
        }
    }
}