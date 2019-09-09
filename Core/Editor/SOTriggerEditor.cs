using UnityEditor;
using UnityEngine;

namespace SimplyTools.Scriptables
{
    /// <summary>
    /// Custom Inspector for <see cref="SOTrigger"/>
    /// </summary>
    [CustomEditor(typeof(SOTrigger))]
    public class SOTriggerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var trigger = target as SOTrigger;

            using (var change = new EditorGUI.ChangeCheckScope())
            {
                // TriggerOnce toggle
                using (new GUILayout.HorizontalScope())
                {
                    GUILayout.Label("Trigger Once");
                    GUILayout.FlexibleSpace();
                    trigger.TriggerOnce = GUILayout.Toggle(trigger.TriggerOnce, GUIContent.none);
                }

                using (new GUILayout.HorizontalScope())
                {
                    // Trigger Button
                    GUI.enabled = !trigger.Triggered;
                    if (GUILayout.Button("Trigger"))
                        trigger.Trigger();

                    // Reset Button
                    GUI.enabled = !GUI.enabled;
                    if (GUILayout.Button("Reset"))
                        trigger.Reset();
                }

                // Apply Changes
                if (change.changed)
                    new SerializedObject(target).ApplyModifiedProperties();
            }
        }
    }
}