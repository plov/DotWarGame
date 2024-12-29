using System;
using System.Collections.Generic;

namespace Code.Core.Communication
{
    public static class GameEventBus
    {
        private static Dictionary<string, Action<object>> events = new Dictionary<string, Action<object>>();
        
        public static void Subscribe(string eventName, Action<object> callback)
        {
            if (!events.ContainsKey(eventName))
            {
                events[eventName] = null;
            }

            events[eventName] += callback;
        }
        
        public static void Unsubscribe(string eventName, Action<object> callback)
        {
            if (events.ContainsKey(eventName))
            {
                events[eventName] -= callback;
            }
        }
        
        public static void Trigger(string eventName, object eventData)
        {
            if (events.ContainsKey(eventName) && events[eventName] != null)
            {
                events[eventName].Invoke(eventData);
            }
        }
    }
}