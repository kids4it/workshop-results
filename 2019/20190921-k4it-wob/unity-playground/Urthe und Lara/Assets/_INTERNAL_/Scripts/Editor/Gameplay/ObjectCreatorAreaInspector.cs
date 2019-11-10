using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(ObjectCreatorArea))]
public class ObjectCreatorAreaInspector : InspectorBase
{
	private string explanation = _("Creates an object repeatedly in a square area. The size of the area is defined by the size of BoxCollider2D, while Spawn Interval defines the delay of spawning.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space (10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		ShowPrefabWarning("prefabToSpawn");

		GUILayout.Label(_("Object creation"), EditorStyles.boldLabel);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ObjectCreatorArea.prefabToSpawn)));

		GUILayout.Label(_("Other options"), EditorStyles.boldLabel);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ObjectCreatorArea.spawnInterval)));

		CheckIfTrigger(true);

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
