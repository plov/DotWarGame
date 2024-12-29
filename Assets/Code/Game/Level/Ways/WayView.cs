using Code.Core.Communication;
using Code.SmartDebug;
using DG.Tweening;
using UnityEngine;

namespace Code.Game.Level.Ways
{
    public class WayView : MonoBehaviour
    {
        private LineRenderer _lineRenderer;
        public Canvas canvas;
        private Vector3[] _linePoints;
        public DotView DotView1 { get; set; }
        public DotView DotView2 { get; private set; }
        public float drawDuration = 2f;

        public void SetDotView2(DotView dotView)
        {
            DotView2 = dotView;
            DLogger.Message(DSenders.LEVEL).WithText("DotView2 saved").Log();
            StartAnimation();
        }

        private void StartAnimation()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            _lineRenderer.startColor = Color.white;
            _lineRenderer.endColor = Color.white;
            _lineRenderer.startWidth = 0.1f;
            _lineRenderer.endWidth = 0.1f;
            
            _linePoints = new Vector3[2];
            _linePoints[0] = DotView1.transform.position; 
            _linePoints[1] = DotView2.transform.position;
            
            _lineRenderer.positionCount = _linePoints.Length;
            _lineRenderer.SetPosition(0, _linePoints[0]);
            _lineRenderer.SetPosition(1, _linePoints[0]);
            
            DrawLine(_linePoints[0], _linePoints[1], drawDuration);
        }

        public void Start()
        {
            GameEventBus.Subscribe(GameEvents.WayFinished, OnWayFinished);
            //GameEventBus.Subscribe(GameEvents.WayStart, OnWayStart);
        }

        public void OnDestroy()
        {
            GameEventBus.Unsubscribe(GameEvents.WayFinished, OnWayFinished);
            //GameEventBus.Unsubscribe(GameEvents.WayStart, OnWayStart);
        }

        private void OnWayFinished(object obj)
        {
            throw new System.NotImplementedException();
        }
        
        void DrawLine(Vector3 start, Vector3 end, float duration)
        {
            DLogger.Message(DSenders.LEVEL).WithText("DrawLine start").Log();
            DOTween.To(
                () => _lineRenderer.GetPosition(1),
                newPosition => _lineRenderer.SetPosition(1, newPosition),
                end,
                duration
            ).OnComplete(OnDrawLineComplete);
        }

        private void OnDrawLineComplete()
        {
            DLogger.Message(DSenders.LEVEL).WithText("DrawLine conplete").Log();
            GameEventBus.Trigger(GameEvents.WayFinished, this);
        }
    }
}