using System.Collections.Generic;
using System.Linq;
using Code.Core.Communication;
using Code.Game.Data;
using Code.Game.EventData;
using Code.Game.Level.Ways;
using Code.SmartDebug;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Game.Level
{
    public class Level : MonoBehaviour
    {
        // Serialized Fields
        [SerializeField] private GameObject pauseButtonObject;
        [SerializeField] private GameObject pausePopupObject;
        [SerializeField] private GameObject dotPrefabObject;
        [SerializeField] private GameObject wayPrefabObject;
        [SerializeField] private GameObject wayCreatorPrefabObject;
        [SerializeField] private Canvas canvas;

        // Private Fields
        private WayCreator _wayCreator;
        private Dictionary<WayView, WayData> _wayMap = new Dictionary<WayView, WayData>();
        private Dictionary<DotView, DotData> _dotMap = new Dictionary<DotView, DotData>();
        private GameData _gameData;
        private LevelData _currentLevelData;
        private LevelFactory _levelFactory;
        private Button _pauseButton;

        private static readonly Vector3 DefaultPosition = Vector3.zero;

        [Inject]
        private void Construct(GameData gameData, LevelFactory levelFactory)
        {
            _gameData = gameData;
            _levelFactory = levelFactory;
        }

        private void Awake()
        {
            InitializeLevel();
        }

        private void InitializeLevel()
        {
            SetupUI();
            SubscribeToEvents();
            _gameData.CurrentLevel = 1;
            _gameData.LevelsData = _levelFactory.BuildLevelData();
            _currentLevelData = _gameData.GetCurrentLevelData();

            InitializeWayCreator();
            InitializeDotMap();
        }

        private void SetupUI()
        {
            _pauseButton = pauseButtonObject.GetComponent<Button>();
            _pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        private void InitializeDotMap()
        {
            var dots = _gameData.LevelsData
                .Where(levelData => levelData.LevelId == _gameData.CurrentLevel)
                .SelectMany(levelData => levelData.Dots);

            foreach (var dot in dots)
            {
                var dotInstance = Instantiate(dotPrefabObject, DefaultPosition, Quaternion.identity, transform);
                dotInstance.transform.position = dot.position;

                var dotView = dotInstance.GetComponent<DotView>();
                dotView.id = dot.Id;
                _dotMap[dotView] = dot;
            }
        }

        private void InitializeWayCreator()
        {
            var wayCreatorObject = Instantiate(wayCreatorPrefabObject);
            _wayCreator = wayCreatorObject.GetComponent<WayCreator>();
            _wayCreator.wayPrefab = wayPrefabObject;
        }

        private void SubscribeToEvents()
        {
            GameEventBus.Subscribe(GameEvents.DotUp, OnPointerUp);
            GameEventBus.Subscribe(GameEvents.WayFinished, OnWayCreatingFinished);
        }

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        private void UnsubscribeFromEvents()
        {
            GameEventBus.Unsubscribe(GameEvents.DotUp, OnPointerUp);
            GameEventBus.Unsubscribe(GameEvents.WayFinished, OnWayCreatingFinished);
        }

        private void OnPauseButtonClick()
        {
            DLogger.Message(DSenders.UI).WithText("Level PauseButton clicked").Log();
            pausePopupObject.SetActive(true);
        }

        private void OnPointerUp(object data)
        {
            if (data is DotView dotView)
            {
                dotView.Select();
                var dotData = GetDotData(dotView);
                if (dotData != null)
                {
                    ProcessNewWay(dotData);
                }
            }
        }

        private void ProcessNewWay(DotData dot)
        {
            var firstDot = _wayCreator.GetDot1();

            if (firstDot != null)
            {
                if (IsDuplicateWay(firstDot, dot))
                {
                    TriggerDeselectEvent(firstDot, dot);
                    _wayCreator.Cancel();
                    return;
                }

                if (IsOppositeWay(firstDot, dot))
                {
                    RemoveWay(firstDot, dot);
                }
            }

            var (view, data) = _wayCreator.Process(dot);
            if (view != null && data != null)
            {
                _currentLevelData.Ways.Add(data);
                _wayMap[view] = data;
            }
        }

        private void TriggerDeselectEvent(DotData dot1, DotData dot2)
        {
            var wayEventData = new WayEventData { Dot1 = dot1, Dot2 = dot2 };
            GameEventBus.Trigger(GameEvents.DeselectDots, wayEventData);
        }

        private bool IsDuplicateWay(DotData dot1, DotData dot2) =>
            _gameData.GetCurrentLevelData().GetWayByDots(dot1, dot2) != null;

        private bool IsOppositeWay(DotData dot1, DotData dot2) =>
            _gameData.GetCurrentLevelData().GetWayByDots(dot2, dot1) != null;

        private void RemoveWay(DotData dot1, DotData dot2)
        {
            var wayData = _gameData.GetCurrentLevelData().GetWayByDots(dot2, dot1);
            var wayView = _wayMap.FirstOrDefault(pair => pair.Value == wayData).Key;

            if (wayView != null)
            {
                _wayMap.Remove(wayView);
                _currentLevelData.Ways.Remove(wayData);
                Destroy(wayView.gameObject);

                LogWayRemoval(wayData);
            }
            else
            {
                DLogger.Message(DSenders.GAMEPLAY).WithText("WayView not found in _wayMap. Remove failed.").Log();
            }
        }

        private void LogWayRemoval(WayData wayData)
        {
            DLogger.Message(DSenders.GAMEPLAY)
                .WithText($"Way removed: {wayData.WayId}. Remaining Count: {_wayMap.Count}")
                .Log();
        }

        private DotData GetDotData(DotView dotView) =>
            _dotMap.TryGetValue(dotView, out var dotData) ? dotData : null;

        private void OnWayCreatingFinished(object data)
        {
            if (data is WayView wayView)
            {
                var way = _wayMap[wayView];
                TriggerDeselectEvent(way.FirstDotData, way.SecondDotData);
            }
        }
    }
}