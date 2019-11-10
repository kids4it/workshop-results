using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(Jump))]
public class JumpInspector : InspectorBase
{
	private string explanation = _("Makes the GameObject jump at the press of a button.");
	private bool checkGround;
	private string checkGroundTip = _("Enable ground check to restrict the Player from jumping while in the air.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Jump.key)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(Jump.jumpStrength)));


		GUILayout.Label(_("Ground setup"), EditorStyles.boldLabel);
		var checkGroundProp = serializedObject.FindProperty(nameof(Jump.checkGround));
		checkGround = EditorTranslation.PropertyField<bool>(checkGroundProp);
		if(checkGround)
		{
			EditorTranslation.PropertyTagField(serializedObject.FindProperty(nameof(Jump.groundTag)));
		}
		else
		{
			EditorGUILayout.HelpBox(checkGroundTip, MessageType.Info);
		}
		checkGroundProp.boolValue = checkGround;

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
