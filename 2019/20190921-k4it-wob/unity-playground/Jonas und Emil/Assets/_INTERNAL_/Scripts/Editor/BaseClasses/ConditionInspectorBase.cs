using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using System;
using System.IO;
using UnityEditor.Globalization;
using UnityEngine.Events;
using static UnityEngine.Globalization.Translation;


[CanEditMultipleObjects]
public class ConditionInspectorBase : InspectorBase
{

	protected ReorderableList list;
	protected string chosenTag;
	protected bool filterByTag;


	protected void OnEnable()
	{
		list = new ReorderableList(serializedObject, serializedObject.FindProperty(nameof(ConditionBase.actions)), true, true, true, true);

		//called for every element that has to be drawn in the ReorderableList
		list.drawElementCallback =  (Rect rect, int index, bool isActive, bool isFocused) => {
			SerializedProperty element = list.serializedProperty.GetArrayElementAtIndex(index);
			rect.y += 2;
			Rect r = new Rect(rect.x, rect.y, rect.width - 20, EditorGUIUtility.singleLineHeight);
			EditorGUI.PropertyField(r, element, GUIContent.none, false);

			/*
			TODO: would be great to have but doesn't work for now
			//Add button at the end to unlink the Action?
			Rect buttonRect = new Rect(rect.width + 7, rect.y, 25, EditorGUIUtility.singleLineHeight);
			bool b = GUI.Button(buttonRect, "-");
			if(b)
			{
				//RemoveElement(index);
			}
			*/
		};


		//draws the header of the ReorderableList
		list.drawHeaderCallback = (Rect rect) => {
			EditorGUI.LabelField(rect, _("Gameplay Actions"));
		};

		list.onAddDropdownCallback = (Rect buttonRect, ReorderableList l) => {
    		var menu = new GenericMenu();
			var guids = AssetDatabase.FindAssets("", new[]{"Assets/Scripts/Conditions/Actions"});
			foreach (var guid in guids) {
				var path = AssetDatabase.GUIDToAssetPath(guid);
				string p = Path.GetFileNameWithoutExtension(path);
				menu.AddItem(new GUIContent(p), false, ClickHandler, p);
			}
			menu.AddItem(new GUIContent(_("- Empty slot -")), false, ClickHandler, "");
			menu.ShowAsContext();
		};

		list.onRemoveCallback += RemoveElement;
	}

	private void RemoveElement(ReorderableList l)
	{
		SerializedProperty element = l.serializedProperty.GetArrayElementAtIndex(l.index);

		if(element.objectReferenceValue != null)
		{
			Type t = element.objectReferenceValue.GetType();
			Undo.DestroyObjectImmediate(Selection.activeGameObject.GetComponent(t));
			element.objectReferenceValue = null;
		}

		ReorderableList.defaultBehaviours.DoRemoveButton(l);
	}

	public void ClickHandler(object actionName)
	{
		Component newComponent = null;
		if(actionName.ToString() != "")
		{
			//Assign the new Component
			Type t = Type.GetType(actionName + ",Assembly-CSharp");
			newComponent = Selection.activeGameObject.AddComponent(t);
		}

		//Add the list element
		var index = list.serializedProperty.arraySize;
		list.serializedProperty.arraySize++;
		list.index = index;
		var element = list.serializedProperty.GetArrayElementAtIndex(index);
		element.objectReferenceValue = newComponent; //connect the newly assigned component to it
		serializedObject.ApplyModifiedProperties();
	}

	//draws the list ReorderableList of GameplayActions, the useCustomActions toggle and (if this is enabled) the default list of UnityEvents
	protected void DrawActionLists()
	{
		list.DoLayoutList();

		var useCustomActionsProp = serializedObject.FindProperty(nameof(ConditionBase.useCustomActions));

		useCustomActionsProp.boolValue = EditorTranslation.PropertyField<bool>(useCustomActionsProp);
		if(useCustomActionsProp.boolValue)
		{
			var e = new UnityEvent();
			EditorGUILayout.PropertyField(serializedObject.FindProperty(nameof(ConditionBase.customActions)));
		}
	}


	//draws the tags as a dropdown only if the Filter by Tag toggle is enabled
	protected void DrawTagsGroup()
	{
		var happenOnlyOnceProp = serializedObject.FindProperty(nameof(ConditionBase.happenOnlyOnce));
		var filterByTagProp = serializedObject.FindProperty(nameof(ConditionBase.filterByTag));

		EditorTranslation.PropertyField(happenOnlyOnceProp);
		filterByTag = EditorTranslation.PropertyField<bool>(filterByTagProp);
		if(filterByTag)
		{
			chosenTag = EditorGUILayout.TagField(_("Tag to check for"), chosenTag);
		}
		filterByTagProp.boolValue = filterByTag;
	}
}
