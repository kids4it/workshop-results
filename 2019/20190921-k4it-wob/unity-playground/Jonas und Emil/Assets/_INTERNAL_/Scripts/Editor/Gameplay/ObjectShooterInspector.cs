using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(ObjectShooter))]
public class ObjectShooterInspector : InspectorBase
{
	private string explanation = _("Spawns an object at the press of a button and it applies a force to it in the direction chosen.");
	//private string hint = "TIP: If you want to shoot in another direction, apply this script to a child object and rotate it in the direction you want.";
	private string warning = _("WARNING: Don't forget to apply a Rigidbody2D to your projectiles, or they won't move!");

	public override void OnInspectorGUI()
	{
		GUILayout.Space (10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		bool prefabSelected = ShowPrefabWarning("prefabToSpawn");

		if(prefabSelected)
		{
			if(!CheckIfObjectUsesComponent<Rigidbody2D>("prefabToSpawn"))
			{
				EditorGUILayout.HelpBox(warning, MessageType.Warning);
			}
		}

		GUILayout.Label(_("Object creation"), EditorStyles.boldLabel);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ObjectShooter.prefabToSpawn)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ObjectShooter.keyToPress)));

		GUILayout.Label(_("Other options"), EditorStyles.boldLabel);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ObjectShooter.creationRate)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ObjectShooter.shootSpeed)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ObjectShooter.shootDirection)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ObjectShooter.relativeToRotation)));

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
		//removed because it's not possible to choose the direction
		//EditorGUILayout.HelpBox(hint, MessageType.Info);
	}
}
