using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.Globalization;
using static UnityEngine.Globalization.Translation;

[CustomEditor(typeof(UIScript))]
public class UIScriptInspector : InspectorBase
{
	private string explanation = _("Use the UI to visualise points and health for the players.");
	private string lifeReminder = _("Don't forget to use the script HealthSystemAttribute on the player(s)!");

	private int nOfPlayers = 0, gameType = 0;
	private string[] readablePlayerEnum = new string[]{_("One player"), _("Two players")};
	private string[] readableGameTypesEnum = new string[]{_("Score"), _("Life"), _("Endless")};

	public override void OnInspectorGUI()
	{
		var gameTypeProp = serializedObject.FindProperty(nameof(UIScript.gameType));
		var numberOfPlayersProp = serializedObject.FindProperty(nameof(UIScript.numberOfPlayers));
		var scoreToWinProp = serializedObject.FindProperty(nameof(UIScript.scoreToWin));

		GUILayout.Space(10);
		EditorGUILayout.HelpBox(explanation, MessageType.Info);

		nOfPlayers = numberOfPlayersProp.intValue;
		gameType = gameTypeProp.intValue;

		nOfPlayers = EditorGUILayout.Popup(_("Number of players"), nOfPlayers, readablePlayerEnum);

		gameType = EditorGUILayout.Popup(_("Game type"), gameType, readableGameTypesEnum);
		if(gameType == 0) //score game
		{
			EditorTranslation.PropertyField(scoreToWinProp);
		}

		if(gameType == 1) //life
		{
			EditorGUILayout.HelpBox(lifeReminder, MessageType.Info);
		}

		//write all the properties back
		gameTypeProp.intValue = gameType;
		numberOfPlayersProp.intValue = nOfPlayers;

		if(GUI.changed)
		{
			serializedObject.ApplyModifiedProperties();
		}
	}
}
