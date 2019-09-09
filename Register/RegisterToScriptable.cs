using UnityEngine;

namespace SimplyTools.Scriptables
{
    /// <summary>
    /// Registers an instance of type <see cref="TValueType"/> to a given <see cref="SOVariable{TValueType}"/>
    /// </summary>
    /// <typeparam name="TScriptable">The type of the <see cref="ScriptableObject"/> that takes <see cref="TValueType"/>
    /// in it's definition</typeparam>
    /// <typeparam name="TValueType">The type stored in the instance of <see cref="TScriptable"/></typeparam>
    public abstract class RegisterToSOVariable<TScriptable, TValueType> : RegsiterToBase<TScriptable, TValueType>
        where TScriptable : SOVariable<TValueType>
    {        
        /// <summary>
        /// Initialises <see cref="m_scriptable"/> to <see cref="Value"/>
        /// </summary>
        protected override void OnEnable() => scriptable.Value = Value;

        /// <summary>
        /// Sets <see cref="m_scriptable"/>'s value to it's default value
        /// </summary>
        protected override void OnDisable() => scriptable.Value = default;
    }
}