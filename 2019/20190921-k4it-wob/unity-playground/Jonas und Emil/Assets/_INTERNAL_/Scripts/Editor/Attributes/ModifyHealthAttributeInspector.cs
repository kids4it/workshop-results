using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(ModifyHealthAttribute))]
public class ModifyHealthAttributeInspector : InspectorBase
{
	private string explanation = _("This GameObject will damage or heal other GameObjects on impact (only if they use the HealthSystemAttribute). Negative values mean damage, positive values mean healing (like a medipack).");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		var healthChangeProp = serializedObject.FindProperty(nameof(ModifyHealthAttribute.healthChange));
		EditorTranslation.PropertyField(serializedObject.FindProperty(nameof(ModifyHealthAttribute.destroyWhenActivated)));
		EditorTranslation.PropertyField(healthChangeProp);

		//print a message to explain better that values can be positive or negative
		GUIStyle style = new GUIStyle(EditorStyles.label);

		if(healthChangeProp.intValue < 0)
		{
			style.normal.textColor = Color.red;
			EditorGUILayout.LabelField(_("This object will damage on impact"), style);
		}
		else if(healthChangeProp.intValue > 0)
		{
			style.normal.textColor = Color.blue;
			EditorGUILayout.LabelField(_("This object will heal on impact"), style);
		}
		else
		{
			EditorGUILayout.LabelField(_("This object will have no effect"));
		}

		if (serializedObject.hasModifiedProperties)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
