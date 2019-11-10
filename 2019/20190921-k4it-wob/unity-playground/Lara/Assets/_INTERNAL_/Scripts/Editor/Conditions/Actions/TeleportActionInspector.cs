using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(TeleportAction))]
public class TeleportActionInspector : InspectorBase
{
	private string explanation = _("Use this script to teleport this or another object to a new location.");
	private string objectWarning = _("WARNING: If you don't assign a GameObject, this GameObject will be teleported!");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(TeleportAction.objectToMove)));

		if(!CheckIfAssigned(nameof(TeleportAction.objectToMove), false))
		{
			EditorGUILayout.HelpBox(objectWarning, MessageType.Warning);
		}

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(TeleportAction.newPosition)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(TeleportAction.stopMovements)));

		if (GUI.changed)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
