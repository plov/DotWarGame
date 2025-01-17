using Code.Core.Communication;
using Code.Game.Data;
using Code.SmartDebug;
using DG.Tweening;
using UnityEngine;

namespace Code.Game.Level.Ways
{
    public class WayView : MonoBehaviour
    {
        private LineRenderer _lineRenderer;
        private Vector3[] _linePoints;
        public Vector3 StartPosition { get; set; }
        public Vector3 EndPosition { get; private set; }
        public float drawDuration = 2f;

        public void SetDotView2(DotData dot)
        {
            EndPosition = dot.position;
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
            _lineRenderer.useWorldSpace = true;
            _lineRenderer.sortingOrder = 100;
            _lineRenderer.sortingLayerName = "Default";
            
            _linePoints = new Vector3[2];
            _linePoints[0] = StartPosition + new Vector3(0, 0, -0.01f);
            _linePoints[1] = EndPosition + new Vector3(0, 0, -0.01f);
            
            _lineRenderer.positionCount = _linePoints.Length;
            
            _lineRenderer.SetPosition(0, _linePoints[0]);
            _lineRenderer.SetPosition(1, _linePoints[0]);
            
            DrawLine(_linePoints[0], _linePoints[1], drawDuration);
        }

        public void Start()
        {
        }

        public void OnDestroy()
        {
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