using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConditionRepeat))]
public class ConditionRepeatInspector : ConditionInspectorBase
{
	private string explanation = _("Use this script to perform an action repeatedly.");

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ConditionRepeat.initialDelay)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ConditionRepeat.frequency)));

		GUILayout.Space(10);
		DrawActionLists();

		serializedObject.ApplyModifiedProperties();
	}
}
