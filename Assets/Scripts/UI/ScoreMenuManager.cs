using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreMenuManager : MonoBehaviour {

	public Text _highscore;
	public Text _totalplays;
	public Text _totaltimeplayed;
	
	int currentHighscore = 0;
	int playerTotalTimeplayed = 0;

	void Start () {
		currentHighscore = PlayerPrefs.GetInt(PlayerPrefsHelper.playerHighScore);
		playerTotalTimeplayed = PlayerPrefs.GetInt(PlayerPrefsHelper.playerPlayTime);

		_highscore.text = Convert.ToString(currentHighscore);
		_totalplays.text = Convert.ToString(PlayerPrefs.GetInt(PlayerPrefsHelper.playerTimesplayed) + 1);
		
		int timeplayed = playerTotalTimeplayed;
		
		double hours = TimeSpan.FromSeconds(timeplayed).TotalHours;
		double minutes =  TimeSpan.FromHours(hours).TotalMinutes;
		double seconds =  TimeSpan.FromMinutes(minutes).TotalSeconds;
		
		_totaltimeplayed.text = Convert.ToString(string.Format("{0}h {1}m {2}s", Convert.ToInt32(hours), Convert.ToInt32(minutes), Convert.ToInt32(seconds)));

	}

    public void OnMainMenu()
    {
        Application.LoadLevel(ScenesNames.SceneMainMenu);
    }

	public void OnShare()
	{

	}
}
