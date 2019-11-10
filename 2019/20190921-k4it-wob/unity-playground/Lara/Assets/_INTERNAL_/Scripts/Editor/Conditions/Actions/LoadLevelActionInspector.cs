using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using static UnityEngine.Globalization.Translation;

[CanEditMultipleObjects]
[CustomEditor(typeof(LoadLevelAction))]
public class LoadLevelActionInspector : InspectorBase
{
	private string explanation = _("Use this script to restart the level, or load another one (load another Unity scene).");
	private string sceneWarning = _("WARNING: Make sure the scene is enabled in the Build Settings scenes list.");
	private string sceneInfo = _("WARNING; To add a new level, save a Unity scene and then go to File > Build Settings... and add the scene to the list.");

	public override void OnInspectorGUI()
	{
		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		GUILayout.Space(10);
		bool displayWarning = false;
		if(EditorBuildSettings.scenes.Length > 0)
		{
			int sceneId = 0;
			var levelNameProp = serializedObject.FindProperty(nameof(LoadLevelAction.levelName));
			string sceneNameProperty = levelNameProp.stringValue;

			//get available scene names and clean the names
			string[] sceneNames = new string[EditorBuildSettings.scenes.Length + 1];
			sceneNames[0] = _("RELOAD LEVEL");
			int i = 1;
			foreach(EditorBuildSettingsScene s in EditorBuildSettings.scenes)
			{
				var shortPath = Path.GetFileNameWithoutExtension(s.path);
				sceneNames[i] = shortPath;

				if(shortPath == sceneNameProperty)
				{
					sceneId = i;

					if(!s.enabled)
					{
						displayWarning = true;
					}
				}

				i++;
			}


			//Display the selector
			sceneId = EditorGUILayout.Popup(_("Scene to load"), sceneId, sceneNames);

			if(displayWarning)
			{
				EditorGUILayout.HelpBox(sceneWarning, MessageType.Warning);
			}

			if(sceneId == 0)
			{
				levelNameProp.stringValue = LoadLevelAction.SAME_SCENE; //this means same scene
			}
			else
			{
				levelNameProp.stringValue = sceneNames[sceneId];
			}
		}
		else
		{
			EditorGUILayout.Popup(_("Scene to load"), 0, new string[]{_("No scenes available!")});
			EditorGUILayout.HelpBox(sceneInfo, MessageType.Warning);
		}

		if (GUI.changed)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
