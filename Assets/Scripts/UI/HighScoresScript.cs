using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoresScript : MonoBehaviour {
    
    public Text arcadeText;
    public Text timeText;

	// Use this for initialization
	void Start () {

        var arcadeValue = PlayerPrefs.GetInt("highScoreArcade");
        var timeValue = PlayerPrefs.GetInt("highScoreTime");

        arcadeText.text = "" + arcadeValue;
        timeText.text = "" + timeValue;
	}
	
	// Update is called once per frame
	public void OnPlayDown () {
        Application.LoadLevel("main_menu");
	}
}
