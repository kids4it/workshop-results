using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(AutoMove))]
public class AutoMoveInspector : InspectorBase
{
	private string explanation = _("The GameObject moves automatically in a specific direction.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(AutoMove.direction)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(AutoMove.relativeToRotation)));
	}
}
