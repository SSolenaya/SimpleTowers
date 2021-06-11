using UnityEditor;
using UnityEngine;

namespace Assets.Editor {
    [CustomPropertyDrawer(typeof(ShowOnlyAttribute))]
    public class ShowOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position,
            SerializedProperty property,
            GUIContent label) {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, false);
            GUI.enabled = true;
        }
    }
}
