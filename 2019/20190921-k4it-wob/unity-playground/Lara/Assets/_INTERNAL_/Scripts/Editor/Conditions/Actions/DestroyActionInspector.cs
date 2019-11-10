using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(DestroyAction))]
public class DestroyActionInspector : InspectorBase
{
	private string explanation = _("Destroys a GameObject instantaneously on impact. Could be this object, or the one that suffered the impact.");
	private string tip = _("TIP: You can assign a death effect, such as an explosion or another particle system.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(DestroyAction.target)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(DestroyAction.deathEffect)));

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}

		if(!CheckIfAssigned("deathEffect", true))
		{
			EditorGUILayout.HelpBox(tip, MessageType.Info);
		}
	}
}
