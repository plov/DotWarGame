using Code.SmartDebug;
using UnityEngine;

namespace Code.Core.StateMachine
{
    public class StateMachineLogger
    {
        private readonly DSender _sender;

        public StateMachineLogger(DSender sender)
        {
            _sender = sender;
        }

        public void LogEnter(object newState, object oldState)
        {
            DLogger.Message(_sender)
                .WithText($"Entering {NewState(newState)}. Previous state: {OldState(oldState)}")
                .Log();
        }

        public void LogEnter(object payload, object newState, object oldState)
        {
            var payloadName = payload switch
            {
                Object unityObj => unityObj.name,
                string name => name,
                _ => payload.ToString()
            };

            DLogger.Message(_sender)
                .WithText(
                    $"Entering {NewState(newState)} with payload {payloadName.White()}. Previous state: {OldState(oldState)}")
                .Log();
        }

        private static string NewState(object state)
        {
            return state.GetType().Name.White();
        }

        private static string OldState(object state)
        {
            return (state != null ? state.GetType().Name : "null").White();
        }
    }
}