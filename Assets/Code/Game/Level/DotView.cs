using System;
using Code.SmartDebug;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Code.Core.Communication;

namespace Code.Game.Level
{
    public class DotView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private GameObject dotPrefab;
        public int Id;

        public void Start()
        {
            GameEventBus.Subscribe(GameEvents.WayFinished, Deselect);
        }

        public void OnDestroy()
        {
            GameEventBus.Unsubscribe(GameEvents.WayFinished, Deselect);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //DLogger.Message(DSenders.UI).WithText(" Dot"+Id+" pressed").Log();
            GameEventBus.Trigger(GameEvents.DotPress, this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            DLogger.Message(DSenders.UI).WithText(" Dot"+Id+" Up").Log();
            Select();
            GameEventBus.Trigger(GameEvents.DotUp, this);
        }

        public void Select()
        {
            transform.DOScale(new Vector3(1.3f, 1.3f, 0), 0.4f).SetEase(Ease.InOutElastic);
        }

        private void Deselect(object data)
        {
            DLogger.Message(DSenders.LEVEL).WithText("Button deselected").Log();
            transform.DOScale(new Vector3(1f, 1f, 0), 0.4f).SetEase(Ease.InElastic);
        }
    }
}
