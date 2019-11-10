using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(CreateObjectAction))]
public class CreateObjectActionInspector : InspectorBase
{
	private string explanation = _("Use this script to create a new GameObject from a Prefab in a specific position.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(CreateObjectAction.prefabToCreate)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(CreateObjectAction.newPosition)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(CreateObjectAction.relativeToThisObject)));

		ShowPrefabWarning("prefabToCreate");

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
