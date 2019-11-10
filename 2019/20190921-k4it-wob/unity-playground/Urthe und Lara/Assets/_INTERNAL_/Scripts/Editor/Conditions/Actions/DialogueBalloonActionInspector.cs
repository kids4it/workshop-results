using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(DialogueBalloonAction))]
public class DialogueBalloonActionInspector : InspectorBase
{
	private string explanation = _("Use this script to create a dialogue ballon on a character's head.");
	private string tipMessage = _("TIP: Connect another DialogueBalloonAction in the last slot to create a continuous conversation.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		//Contents
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(DialogueBalloonAction.textToDisplay)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(DialogueBalloonAction.backgroundColor)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(DialogueBalloonAction.textColor)));

		//Options
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(DialogueBalloonAction.targetObject)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(DialogueBalloonAction.disappearMode)));
		int isUsingKey = serializedObject.FindProperty(nameof(DialogueBalloonAction.disappearMode)).intValue;
		if(isUsingKey == 1)
		{
			EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(DialogueBalloonAction.keyToPress)));
		}
		else
		{
			EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(DialogueBalloonAction.timeToDisappear)));
		}

		//Continue dialogue
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(DialogueBalloonAction.followingText)));

		EditorGUILayout.HelpBox(tipMessage, MessageType.Info);

		if (GUI.changed)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
