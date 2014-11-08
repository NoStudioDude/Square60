using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {
    
    public Image newScore;

    public Text textInfo;
    public Text textHighscore;
    public Text textCurrentscore;

    public GameBoardManager gManager;

    int prevHighscore = 0;
    int timeSurvived = 0;
    
	// Use this for initialization
	void Start () {
        prevHighscore = PlayerPrefs.GetInt(PlayerPrefsHelper.playerHighScore);
        textHighscore.text = Convert.ToString(prevHighscore);
        
        if (gManager != null)
        {
            timeSurvived = gManager.totalTimeSurvived;

            textInfo.text = string.Format("Total time played: {0} seconds", timeSurvived);
            textCurrentscore.text = "" + gManager.currentScore;

            if (prevHighscore < gManager.currentScore)
            {
                newScore.enabled = true;
                PlayerPrefs.SetInt(PlayerPrefsHelper.playerHighScore, gManager.currentScore);

                PlayerPrefs.SetInt(PlayerPrefsHelper.playerPlayTime, (PlayerPrefs.GetInt(PlayerPrefsHelper.playerPlayTime) + timeSurvived));
            }
        }
	}
}
