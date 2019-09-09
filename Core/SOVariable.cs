using System;
using UnityEngine;

namespace SimplyTools.Scriptables
{
    public abstract class SOVariable<TValueType> : ScriptableObject
    {
        [SerializeField, Tooltip("The initial value to use")]
        private TValueType initialValue = default;
        [SerializeField, Tooltip("If false then listeners will only be notified if the value is changed")]
        private bool notifyListenersOnSet = false;
        [SerializeField, Tooltip("Allow value to be set to 'null'?")]
        private bool allowNull = false;

        [NonSerialized] private TValueType m_value = default;
        [NonSerialized] private bool m_initialised = false;

        private void OnEnable() => Value = initialValue;

        public virtual TValueType Value
        {
            get { return m_value; }
            set
            {
                if (value != null || (value == null && allowNull))
                {
                    if (!Equals(value, m_value) || !m_initialised)
                    {
                        m_value = value;
                        m_initialised = true;
                        OnValueChanged?.Invoke(m_value);
                    }
                    else if (notifyListenersOnSet)
                        OnValueChanged?.Invoke(m_value);
                }
            }
        }

        public event Action<TValueType> OnValueChanged;
    }
}