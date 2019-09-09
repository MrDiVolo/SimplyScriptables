using System;

namespace SimplyTools.Scriptables
{
    [Serializable]
    public class SOVariableRef<TVarType, TScriptableType>
        where TScriptableType : SOVariable<TVarType>
    {
        public bool UseScriptable;
        public TVarType Variable;
        public TScriptableType Scriptable;

        private event Action<TVarType> onValueChanged;

        public event Action<TVarType> OnValueChanged
        {
            add
            {
                if (UseScriptable)
                {
                    if (Scriptable)
                        Scriptable.OnValueChanged += value;
                }
                else
                    onValueChanged += value;
            }
            remove
            {
                if (UseScriptable)
                {
                    if (Scriptable)
                        Scriptable.OnValueChanged -= value;
                }
                else
                    onValueChanged -= value;
            }
        }

        public TVarType Value
        {
            get
            {
                if (UseScriptable)
                    return Scriptable ? Scriptable.Value : default;

                return Variable;
            }
            set
            {
                if (UseScriptable)
                {
                    if (Scriptable)
                        Scriptable.Value = value;
                }
                else
                {
                    Variable = value;
                    onValueChanged?.Invoke(Variable);
                }
            }
        }
    }
}