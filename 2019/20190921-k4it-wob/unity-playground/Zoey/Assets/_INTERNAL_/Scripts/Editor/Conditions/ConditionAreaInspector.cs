using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConditionArea))]
public class ConditionAreaInspector : ConditionInspectorBase
{
	private string explanation = _("Perform actions when a GameObject enters, exits, or stays inside the trigger collider (in this last case you get to choose the frequency).");

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		var eventTypeProp = serializedObject.FindProperty(nameof(ConditionArea.eventType));
		var filterTagProp = serializedObject.FindProperty(nameof(ConditionArea.filterTag));
		var frequencyProp = serializedObject.FindProperty(nameof(ConditionArea.frequency));

		chosenTag = filterTagProp.stringValue;

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		// Show a tag selector to then use for the public property filterTag
		GUILayout.Space(10);
		DrawTagsGroup();


		//discern the event type, and show the frequency if needed
		EditorTranslation.PropertyField(eventTypeProp);
		int eventType = eventTypeProp.intValue;
		if(eventType == 2)
		{
			EditorTranslation.PropertyField(frequencyProp);
		}

		GUILayout.Space(10);
		DrawActionLists();

		CheckIfTrigger(true);

		if (GUI.changed)
		{
			filterTagProp.stringValue = chosenTag;
			serializedObject.ApplyModifiedProperties();
		}
	}
}
