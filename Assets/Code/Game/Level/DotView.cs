using Code.SmartDebug;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Code.Core.Communication;
using Code.Game.Data;
using Code.Game.EventData;

namespace Code.Game.Level
{
    public class DotView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public string id;
        private float _scale;

        public void Start()
        {
            _scale = transform.localScale.x;
            Subscribe();
        }

        private void Subscribe()
        {
            GameEventBus.Subscribe(GameEvents.DeselectDots, Deselect);
        }

        public void OnDestroy()
        {
            GameEventBus.Unsubscribe(GameEvents.DeselectDots, Deselect);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            //DLogger.Message(DSenders.UI).WithText(" Dot"+Id+" pressed").Log();
            GameEventBus.Trigger(GameEvents.DotPress, this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            DLogger.Message(DSenders.UI).WithText(" Dot"+id+" Up").Log();
            Select();
            GameEventBus.Trigger(GameEvents.DotUp, this);
        }

        public void Select()
        {
            var scale = _scale * 1.3f;
            transform.DOScale(new Vector3(scale, scale, 0), 0.4f).SetEase(Ease.InOutElastic);
        }

        private void Deselect(object data)
        {
            if ((data as WayEventData)?.Dot1.Id == id || (data as WayEventData)?.Dot2.Id == id)
            {
                DLogger.Message(DSenders.LEVEL).WithText("Button deselected").Log();
                var scale = _scale;
                transform.DOScale(new Vector3(scale, scale, 0), 0.4f).SetEase(Ease.InElastic);
            }
        }
    }
}
