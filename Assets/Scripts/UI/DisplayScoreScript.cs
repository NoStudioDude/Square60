using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DisplayScoreScript : MonoBehaviour {

    public GameBoardManager gbManager;
    public Text score;
    public Text best;
    public Image newbest;

    int highScore = 0;
    bool isInfoUpdated = false;
	// Use this for initialization
	void Start () {

        if (gbManager.isTimeAttack)
            highScore = PlayerPrefs.GetInt("highScoreArcade");
        else
            highScore = PlayerPrefs.GetInt("highScoreTime");
	}
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("main_menu");
        }

        if (gbManager != null)
        {
            if (gbManager.isGameOver)
            {
                if (isInfoUpdated)
                    return;

                isInfoUpdated = true;
                setScore();
            }
        }
    }

    void setScore()
    {
        score.text = "" + gbManager.currentScore;

        if (gbManager.currentScore > highScore)
        {
            highScore = gbManager.currentScore;
            newbest.enabled = true;
        }

        if (highScore == 0)
            highScore = gbManager.currentScore;

        best.text = "" + highScore;

        if (gbManager.isTimeAttack)
            PlayerPrefs.SetInt("highScoreArcade", highScore);
        else
            PlayerPrefs.SetInt("highScoreTime", highScore);
        
    }

    public void OnPlayDown()
    {
        if (gbManager.isTimeAttack)
            Application.LoadLevel("Square_timeAttack");
        else
            Application.LoadLevel("Square_60seconds");
        
    }
    public void OnFacebookDown()
    { 
        
    }
    public void OnMenuDown()
    {
        Application.LoadLevel("main_menu");
    }
}
