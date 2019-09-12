using System;
using UnityEngine;

namespace SimplyTools.Scriptables
{
    /// <summary>
    /// Container for an event Trigger
    /// </summary>
    [CreateAssetMenu(menuName = "Simply/Scriptables/Trigger")]
    public class SOTrigger : ScriptableObject
    {
        /// <summary>
        /// Can this Trigger only be fired once (before requiring a call to <see cref="Reset"/>)
        /// </summary>
        public bool TriggerOnce;

        /// <summary>
        /// The listeners subscribed to this Trigger
        /// </summary>
        public event Action OnTriggered;

        /// <summary>
        /// Has the Trigger been fired
        /// </summary>
        public bool Triggered { get; private set; }

        /// <summary>
        /// Fires the Trigger
        /// </summary>
        public void Trigger()
        {
            if (!Triggered)
            {
                #if DEBUG
                Debug.Log(name + " Triggered");
                #endif

                OnTriggered?.Invoke();

                if (Application.isPlaying && TriggerOnce)
                    Triggered = true;
            }
        }
        
        /// <summary>
        /// Resets the Trigger (only required when <see cref="TriggerOnce"/> is true)
        /// </summary>
        public void Reset() => Triggered = false;
    }
}