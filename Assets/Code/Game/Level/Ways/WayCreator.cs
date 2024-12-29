using UnityEngine;

namespace Code.Game.Level.Ways
{
    public class WayCreator:MonoBehaviour
    {
        private GameObject _wayObject;
		private WayView _wayView;
        private bool _isNew = true; 
        public GameObject wayPrefab;
        public Canvas canvas; 

        public GameObject Process(DotView dotView)
        {
            if (_isNew)
            {
                _isNew = false;
                _wayObject = Instantiate(wayPrefab);
                _wayView = _wayObject.GetComponent<WayView>();
                _wayView.canvas = canvas;
                _wayView.DotView1 = dotView;
                return null;
            }
            else
            {
                _wayView.SetDotView2(dotView);
                _isNew = true;
                return _wayObject;
                
            }
        }
    }
}