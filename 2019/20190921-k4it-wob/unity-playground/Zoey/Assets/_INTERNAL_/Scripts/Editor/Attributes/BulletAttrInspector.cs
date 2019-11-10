using UnityEngine;
using System.Collections;
using UnityEditor;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(BulletAttribute))]
public class BulletAttrInspector : InspectorBase
{
	private string explanation = _("When this object touches another that has the script DestroyForPoints, the Player will get a point.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);
	}
}
