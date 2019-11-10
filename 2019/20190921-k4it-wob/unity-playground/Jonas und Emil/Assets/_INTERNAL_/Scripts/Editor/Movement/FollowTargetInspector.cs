using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(FollowTarget))]
public class FollowTargetInspector : InspectorBase
{
	private string explanation = _("This GameObject will pursue a target constantly.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(5);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(FollowTarget.target)));

		//Draw custom inspector
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(FollowTarget.speed)));

		GUILayout.Space(10);

		SerializedProperty lookAtTargetProperty = serializedObject.FindProperty(nameof(FollowTarget.lookAtTarget));

		lookAtTargetProperty.boolValue = EditorGUILayout.BeginToggleGroup(_("Look at target"), lookAtTargetProperty.boolValue);
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(FollowTarget.useSide)));
		EditorGUILayout.EndToggleGroup();

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
