using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(HealthSystemAttribute))]
public class PlayerHealthInspector : InspectorBase
{
	private string explanation = _("This scripts allows the Players or other objects to receive damage.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(HealthSystemAttribute.health)));

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
