using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(Move))]
public class MoveInspector : InspectorBase
{
	private string explanation = _("The GameObject moves when pressing specific keys. Choose between Arrows or WASD.");
	private string constraintsReminder = _("If you want, you can constrain movement on the X/Y axes in the Rigidbody2D's properties.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		//base.OnInspectorGUI();
		EditorGUILayout.LabelField(_("Input Keys"), EditorStyles.boldLabel);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Move.typeOfControl)));

		EditorGUILayout.LabelField(_("Movement"), EditorStyles.boldLabel);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Move.speed)), "Speed of movement");
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Move.movementType)));

		GUILayout.Space(5);
		GUILayout.Label(_("Orientation"), EditorStyles.boldLabel);
		var orientationToDirectionProp = serializedObject.FindProperty(nameof(Move.orientToDirection));
		bool orientToDirection = EditorTranslation.PropertyField<bool>(orientationToDirectionProp);
		if(orientToDirection)
		{
			EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Move.lookAxis)));
		}
		orientationToDirectionProp.boolValue = orientToDirection;


		if(serializedObject.FindProperty(nameof(Move.movementType)).intValue != 0)
		{
			EditorGUILayout.HelpBox(constraintsReminder, MessageType.Info);
		}

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
