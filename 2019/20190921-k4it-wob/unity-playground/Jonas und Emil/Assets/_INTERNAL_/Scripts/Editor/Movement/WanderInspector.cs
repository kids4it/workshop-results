using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(Wander))]
public class WanderInspector : InspectorBase
{
	private string explanation = _("The GameObject will move around randomly. Use keepNearStartingPoint if you want it to keep near its starting position.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Label(_("Movement"), EditorStyles.boldLabel);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Wander.speed)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Wander.directionChangeInterval)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Wander.keepNearStartingPoint)));

		GUILayout.Space(5);
		GUILayout.Label(_("Orientation"), EditorStyles.boldLabel);
		var orientToDirectionProp = serializedObject.FindProperty(nameof(Wander.orientToDirection));
		var orientToDirectionTemp = EditorTranslation.PropertyField<bool>( orientToDirectionProp);
		if(orientToDirectionTemp)
		{
			EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Wander.lookAxis)));
		}
		orientToDirectionProp.boolValue = orientToDirectionTemp;

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
