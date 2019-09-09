using UnityEditor;
using UnityEngine;

namespace SimplyTools.Scriptables
{
    [CustomPropertyDrawer(typeof(TriggerRef))]
    public class TriggerRefEditor : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);
            position.height = EditorGUIUtility.singleLineHeight;

            EditorGUI.BeginChangeCheck();

            // Get properties
            SerializedProperty expanded = property.FindPropertyRelative("Expanded");
            SerializedProperty scriptable = property.FindPropertyRelative("Trigger");
            SerializedProperty unityEvent = property.FindPropertyRelative("Event");

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(position.x, position.y, 20, position.height);
            position.xMin = buttonRect.xMax;

            // Expanded
            expanded.boolValue = EditorGUI.Toggle(buttonRect, expanded.boolValue, EditorStyles.foldout);

            // SOTrigger
            EditorGUI.PropertyField(position, scriptable, GUIContent.none);

            // UnityEvent
            position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            if (expanded.boolValue)
                EditorGUI.PropertyField(position, unityEvent, GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty expanded = property.FindPropertyRelative("Expanded");
            SerializedProperty unityEvent = property.FindPropertyRelative("Event");
            SerializedProperty eventCount = unityEvent.FindPropertyRelative("m_PersistentCalls.m_Calls");

            const float eventHeight = 84, elementHeight = 43;

            float defaultHeight = base.GetPropertyHeight(property, label);            
            float numberOfElements = eventCount.arraySize;

            return expanded.boolValue
                ? defaultHeight + eventHeight + (numberOfElements == 0 ? 0 : ((numberOfElements - 1) * elementHeight))
                : defaultHeight;
        }
    }
}