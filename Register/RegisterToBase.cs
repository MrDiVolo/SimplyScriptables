using UnityEngine;

namespace SimplyTools.Scriptables
{
    public abstract class RegsiterToBase<TScriptable, TValueType> : MonoBehaviour
        where TScriptable : ScriptableObject
    {
        [SerializeField] protected TScriptable m_scriptable = null;

        protected abstract void OnEnable();
        protected abstract void OnDisable();

        /// <summary>
        /// The value that the referenced <see cref="SOVariable{TValueType}"/> will be set to
        /// </summary>
        protected abstract TValueType Value { get; }
    }
}