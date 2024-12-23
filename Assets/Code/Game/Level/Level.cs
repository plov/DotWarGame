using System;
using Code.SmartDebug;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Code.Game.Level
{
    public class Level : MonoBehaviour, IPointerMoveHandler
    {
        public LineRenderer lineRenderer;
        private bool _isDrawing = false;
        private Vector3 _startPoint;
        private string _startDotName = String.Empty;

        [SerializeField] private GameObject pauseBtnObj;
        private Button _pauseBtn;
        [SerializeField] private GameObject pausePopupObj;
        [SerializeField] private GameObject[] dotPrefabsObj;


        public Vector3[] pathPoints;
        public float duration = 5f; // Duration of the path animation

        private void Awake()
        {
            _pauseBtn = pauseBtnObj.GetComponent<Button>();
            _pauseBtn.onClick.AddListener(PauseBtnClick);

            foreach (var dot in dotPrefabsObj)
            {
                dot.GetComponent<DotView>().PointerDown += OnPointerDown;
                dot.GetComponent<DotView>().PointerUp += OnPointerUp;
            }

            // try
            // {
            //     GameObject gobj = GetGameObjectWithName("Dot1");
            //     gobj.GetComponent<DotView>().LeftMouseDown += OnLeftMouseDown;
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e);
            //     throw;
            // }
        }

        protected void PauseBtnClick()
        {
            DLogger.Message(DSenders.UI).WithText("Level PauseBtn clicked").Log();
            pausePopupObj.SetActive(true);
        }

        private void Start()
        {
            // pathPoints = new Vector3[]
            // {
            //     testObj.transform.position,   // Start
            //     new Vector3(100, 100, 0),   // First waypoint
            //     new Vector3(100, 50, 0),  // Second waypoint
            //     new Vector3(80, 150, 0)    // Final destination
            // };
            //
            // testObj.transform.DOPath(pathPoints, duration, PathType.CatmullRom)
            //     .SetOptions(false) // Optionally, false to not close the loop
            //     .SetEase(Ease.Linear) // Linear movement
            //     .OnComplete(() => Debug.Log("Path animation completed"));
        }

        private void OnPointerDown(DotView unit)
        {
            _startDotName = unit.name;
            //unit.GetComponent<DotView>().gameObject.SetActive(false);
            _startPoint = unit.GetComponent<DotView>().gameObject.transform.position;
            _isDrawing = true;
            Vector3 startPos = Camera.main.ScreenToWorldPoint(new Vector3(_startPoint.x, _startPoint.y, 10f));
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, startPos);
            lineRenderer.SetPosition(1, startPos);
            Debug.Log("startPos " + startPos);
        }

        private void OnPointerUp(DotView unit)
        {
            //unit.GetComponent<DotView>().gameObject.SetActive(true);
            Debug.Log("is drawing - false");
            _isDrawing = false;
        }

        private void Update()
        {
        }

        public void OnPointerMove(PointerEventData eventData)
        {
            if (!_isDrawing)
            {
                return;
            }

            Debug.Log("is drawing - true");
            Vector3 currentPoint =
                Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 10f));

            // Update the end point of the line
            lineRenderer.SetPosition(1, currentPoint);
            CheckAnotherDot(currentPoint);
        }

        private void CheckAnotherDot(Vector3 point)
        {
            foreach (var dot in dotPrefabsObj)
            {
                if (_startDotName != dot.name)
                {
                    var dotPos = dot.transform.position;
                    var dotWorldPos =Camera.main.ScreenToWorldPoint(new Vector3(dotPos.x, dotPos.y, 10f));
                    float distance = Vector3.Distance(point, dotWorldPos);
                    Debug.Log("distance" + distance);
                    if (distance < 0.6f)
                    {
                        var transform = dot.transform.Find("bg");
                        var gameObj = transform.gameObject;
                        var image = gameObj.GetComponent<Image>();
                        if (image != null)
                        {
                            image.color = Color.red;
                        }
                    }
                    else
                    {
                        var transform = dot.transform.Find("bg");
                        var gameObj = transform.gameObject;
                        var image = gameObj.GetComponent<Image>();
                        if (image != null)
                        {
                            image.color = new Color(13f / 255f, 243f / 255f, 237f / 255f, 1f);
                        }
                    }
                }
            }
        }
    }
}