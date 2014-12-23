using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreMenuManager : MonoBehaviour {

    public Text highscoreValue;
    public Text timeValue;

    int playerHighscore = 0;
    int playerPlayTime = 0;

	// Use this for initialization
	void Start () {
        playerHighscore = PlayerPrefs.GetInt(PlayerPrefsHelper.playerHighScore);
        playerPlayTime = PlayerPrefs.GetInt(PlayerPrefsHelper.playerPlayTime);

        highscoreValue.text = Convert.ToString(playerHighscore);
        timeValue.text = Convert.ToString(playerPlayTime);
	}
	
    public void OnSubmitScore()
    { 
        
    }
    public void OnMainMenu()
    {
        Application.LoadLevel(ScenesNames.SceneMainMenu);
    }
}
