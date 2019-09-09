using UnityEngine;

namespace SimplyTools.Scriptables
{
    /// <summary>
    /// Registers an instance of type <see cref="TValueType"/> as being part of a collection
    /// </summary>
    /// <typeparam name="TScriptable">The type of the <see cref="ScriptableObject"/> that takes <see cref="TValueType"/>
    /// in it's definition</typeparam>
    /// <typeparam name="TValueType">The type stored in the instance of <see cref="TScriptable"/></typeparam>
    public abstract class RegisterToSOList<TVariableType, TValueType> : RegsiterToBase<TVariableType, TValueType>
        where TVariableType : SOList<TValueType>
    {
        /// <summary>
        /// Adds <see cref="Value"/> to the collection
        /// </summary>
        protected override void OnEnable() => scriptable?.Add(Value);

        /// <summary>
        /// Removes <see cref="Value"/> from the collection
        /// </summary>
        protected override void OnDisable() => scriptable?.Remove(Value);
    }
}