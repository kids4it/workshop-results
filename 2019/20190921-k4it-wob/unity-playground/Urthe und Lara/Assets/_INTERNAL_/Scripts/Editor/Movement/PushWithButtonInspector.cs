using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(Push))]
public class PushInspector : InspectorBase
{
	private string explanation = _("The GameObject will move at the push of a button, as if a thruster or an invisible force was pushing it.");
	private string absoluteTip = _("TIP: The GameObject will always move in the direction chosen regardless of its orientation.");
	private string relativeTip = _("TIP: The GameObject will move in the direction chosen relative to its orientation.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Label(_("Input Keys"), EditorStyles.boldLabel);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Push.key)));

		GUILayout.Label(_("Direction and Strength"), EditorStyles.boldLabel);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Push.pushStrength)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Push.axis)));

		var relativeAxisProp = serializedObject.FindProperty(nameof(Push.relativeAxis));
		relativeAxisProp.boolValue = EditorTranslation.PropertyField<bool>(relativeAxisProp);

		var tip = relativeAxisProp.boolValue ? relativeTip : absoluteTip;
		EditorGUILayout.HelpBox(tip, MessageType.Info);

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
