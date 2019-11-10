using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(PickUpAndHold))]
public class PickUpAndHoldInspector : InspectorBase
{
	private string explanation = _("The Player can pick up and drop objects by pressing a key.");
	private string warning = _("The Pickup object must be tagged 'Pickup' and have component Rigidbody2D");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);
		GUILayout.Space(10);

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(PickUpAndHold.pickupKey)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(PickUpAndHold.dropKey)));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(PickUpAndHold.pickUpDistance)));

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(warning, MessageType.Warning);

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
