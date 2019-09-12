using UnityEditor;
using UnityEngine;

namespace SimplyTools.Scriptables.Extras
{
    public class SOVariableRefEditor<TVarType, TScriptableType> : PropertyDrawer
        where TScriptableType : SOVariable<TVarType>
    {
        /// <summary> Options to display in the popup to select variable or ScriptableObject. </summary>
        private readonly static string[] m_options = { "Use Variable", "Use Scriptable" };

        /// <summary> Cached style to use to draw the popup button. </summary>
        private static GUIStyle m_popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions")) { imagePosition = ImagePosition.ImageOnly };

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Get properties
            SerializedProperty useConstant = property.FindPropertyRelative("UseScriptable");
            SerializedProperty variable = property.FindPropertyRelative("Variable");
            SerializedProperty scriptable = property.FindPropertyRelative("Scriptable");

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += m_popupStyle.margin.top;
            buttonRect.width = m_popupStyle.fixedWidth + m_popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, m_options, m_popupStyle);
            useConstant.boolValue = result == 0;

            EditorGUI.PropertyField(position,
                useConstant.boolValue ? variable : scriptable,
                GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();
            
            EditorGUI.EndProperty();
        }
    }
}