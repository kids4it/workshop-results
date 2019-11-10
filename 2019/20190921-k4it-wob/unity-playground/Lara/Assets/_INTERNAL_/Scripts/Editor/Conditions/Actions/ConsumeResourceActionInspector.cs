using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConsumeResourceAction))]
public class ConsumeResourceActionInspector : ConditionInspectorBase
{
	private string explanation = _("Use this script to check if the player has enough of a specific resource. If they have it, it will be removed from the Player's inventory.");
	private InventoryResources repository;

	private new void OnEnable()
	{
		repository = Resources.Load<InventoryResources>("ScriptableObjects/InventoryResources");

		base.OnEnable();
	}

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		//draw the popup that displays the names of Resource types, taken from the "InventoryResources" ScriptableObject
		SerializedProperty resourceIndexProp = serializedObject.FindProperty(nameof(ConsumeResourceAction.checkFor));
		int chosenType = resourceIndexProp.intValue; //take the int value from the property

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel(_("Type of Resource"));
		chosenType = EditorGUILayout.Popup(chosenType, repository.GetResourceTypes(), GUILayout.ExpandWidth(false));
		EditorGUILayout.EndHorizontal();

		resourceIndexProp.intValue = chosenType; //put the value back into the property

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ConsumeResourceAction.amountNeeded)));

		GUILayout.Space(10);
		//Display a button to jump to the "InventoryResources" ScriptableObject
		if(GUILayout.Button(_("Add/Remove types")))
		{
			Selection.activeObject = repository;
		}

		serializedObject.ApplyModifiedProperties();
	}
}
