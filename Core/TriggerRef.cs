using System;
using UnityEngine.Events;

namespace SimplyTools.Scriptables
{
    /// <summary>
    /// Links a <see cref="UnityEvent"/> to an <see cref="SOTrigger"/>
    /// </summary>
    [Serializable]
    public class TriggerRef
    {
        #if UNITY_EDITOR
        /// <summary>
        /// Expanded in the Hierarchy
        /// </summary>
        public bool Expanded;
        #endif

        /// <summary>
        /// The Trigger to respond to
        /// </summary>
        public SOTrigger Trigger;

        /// <summary>
        /// The event(s) that respond to <see cref="SOTrigger.OnTriggered"/>
        /// </summary>
        public UnityEvent Event;

        /// <summary>
        /// Subscribes to the <see cref="SOTrigger.OnTriggered"/> event
        /// </summary>
        public void Subscribe()
        {
            if (Trigger != null)
                Trigger.OnTriggered += DoEvent;
        }

        /// <summary>
        /// Unsubscribes to the <see cref="SOTrigger.OnTriggered"/> event
        /// </summary>
        public void Unsubscribe()
        {
            if (Trigger != null)
                Trigger.OnTriggered -= DoEvent;
        }

        /// <summary>
        /// Raises all listeners in <see cref="Event"/>
        /// </summary>
        private void DoEvent() => Event?.Invoke();
    }
}