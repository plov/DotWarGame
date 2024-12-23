using System;
using Code.SmartDebug;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Game.Level
{
    public class DotView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private GameObject dotPrefab;
        public int Id;
        
        public event Action<DotView> PointerDown;
        public event Action<DotView> PointerUp;
        
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            DLogger.Message(DSenders.UI).WithText(" Dot"+Id+" pressed").Log();
            PointerDown?.Invoke(this); 
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            DLogger.Message(DSenders.UI).WithText(" Dot"+Id+" Up").Log();
            PointerUp?.Invoke(this); 
        }
    }
}
