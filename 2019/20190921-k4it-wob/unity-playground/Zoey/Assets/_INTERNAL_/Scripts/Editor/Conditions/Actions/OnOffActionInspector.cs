using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(OnOffAction))]
public class OnOffActionInspector : InspectorBase
{
	private string explanation = _("Use this script to turn an object on or off.");
	private string invisibleTip = _("TIP: The object will be made invisible, but it will still collide with others.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(OnOffAction.objectToAffect)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(OnOffAction.justMakeInvisible)));

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}

		if(serializedObject.FindProperty("justMakeInvisible").boolValue)
		{
			EditorGUILayout.HelpBox(invisibleTip, MessageType.Info);
		}
	}
}
