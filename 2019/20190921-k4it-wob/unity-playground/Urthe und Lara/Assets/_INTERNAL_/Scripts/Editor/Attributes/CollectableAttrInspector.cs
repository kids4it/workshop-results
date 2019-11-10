using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(CollectableAttribute))]
public class CollectableAttrInspector : InspectorBase
{
	private string explanation = _("When the Player touches this object, it will be awarded one or more points.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(CollectableAttribute.pointsWorth)));

		CheckIfTrigger(true);

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
