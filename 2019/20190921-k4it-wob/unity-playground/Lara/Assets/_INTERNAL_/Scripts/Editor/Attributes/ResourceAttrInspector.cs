using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(ResourceAttribute))]
public class ResourceAttrInspector : InspectorBase
{
	private string explanation = _("When the Player touches this object, they will collect the specified amount of this type of resource.");
	private InventoryResources repository;

	private void OnEnable()
	{
		repository = Resources.Load<InventoryResources>("ScriptableObjects/InventoryResources");
	}

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		//draw the popup that displays the names of Resource types, taken from the "InventoryResources" ScriptableObject
		var resourceIndexProp = serializedObject.FindProperty(nameof(ResourceAttribute.resourceIndex));
		int chosenType = resourceIndexProp.intValue; //take the int value from the property

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.PrefixLabel(_("Type of Resource"));
		chosenType = EditorGUILayout.Popup(chosenType, repository.GetResourceTypes(), GUILayout.ExpandWidth(false));
		EditorGUILayout.EndHorizontal();

		resourceIndexProp.intValue = chosenType; //put the value back into the property

		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ResourceAttribute.amount)));

		GUILayout.Space(10);
		//Display a button to jump to the "InventoryResources" ScriptableObject
		if(GUILayout.Button(_("Add/Remove types")))
		{
			Selection.activeObject = repository;
		}

		CheckIfTrigger(true);

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
