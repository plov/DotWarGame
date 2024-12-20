using System;
using Code.SmartDebug;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Code.Game.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject pauseBtnObj;
        private Button _pauseBtn;
        [SerializeField] private GameObject pausePopupObj;
        [SerializeField] private GameObject testObj;


        public Vector3[] pathPoints;
        public float duration = 5f;  // Duration of the path animation
        
        private void Awake()
        {
            _pauseBtn = pauseBtnObj.GetComponent<Button>();
            _pauseBtn.onClick.AddListener(PauseBtnClick);
        }

        protected void PauseBtnClick()
        {
            DLogger.Message(DSenders.UI).WithText("Level PauseBtn clicked").Log();
            pausePopupObj.SetActive(true);
        }

        private void Start()
        {
            pathPoints = new Vector3[]
            {
                testObj.transform.position,   // Start
                new Vector3(100, 100, 0),   // First waypoint
                new Vector3(100, 50, 0),  // Second waypoint
                new Vector3(80, 150, 0)    // Final destination
            };
            
            testObj.transform.DOPath(pathPoints, duration, PathType.CatmullRom)
                .SetOptions(false) // Optionally, false to not close the loop
                .SetEase(Ease.Linear) // Linear movement
                .OnComplete(() => Debug.Log("Path animation completed"));
        }

        private void Update()
        {
            
        }
    }
}