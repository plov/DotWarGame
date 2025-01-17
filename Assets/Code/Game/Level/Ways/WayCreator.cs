using Code.Game.Data;
using JetBrains.Annotations;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Code.Game.Level.Ways
{
    public class WayCreator:MonoBehaviour
    {
        private GameObject _wayObject;
		private WayView _wayView;
        private WayData _wayData;
        private bool _isFinish; 
        public GameObject wayPrefab;

        public DotData GetDot1()
        {
            if (_isFinish)
            {
                return _wayData.FirstDotData;
            }
            return null;
        }

        public void Cancel()
        {
            Destroy(_wayObject);
            _wayView = null;
            _isFinish = false;
        }

        public (WayView, WayData) Process(DotData dot)
        {
            if (!_isFinish)
            {
                _wayObject = Instantiate(wayPrefab);
                _wayView = _wayObject.GetComponent<WayView>();
                _wayView.StartPosition = dot.position;
                _wayData = new WayData() { FirstDotData = dot };
                _isFinish = true;
                return (null, null);
            }
            else
            {
                _wayView.SetDotView2(dot);
                _wayData.SecondDotData = dot;
                _isFinish = false;
                return (_wayView, _wayData);
            }
        }
    }
}