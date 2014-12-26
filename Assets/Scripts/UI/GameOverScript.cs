using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {
    
    public Text _score;
    public Text _highscore;
    public Text _totalplays;
	public Text _totaltimeplayed;

    public GameBoardManager gManager;

	int currentHighscore = 0;
	int playerTotalTimeplayed = 0;
	// Use this for initialization
	void Start () {
		currentHighscore = PlayerPrefs.GetInt(PlayerPrefsHelper.playerHighScore);
		playerTotalTimeplayed = PlayerPrefs.GetInt(PlayerPrefsHelper.playerPlayTime);

		_score.text = Convert.ToString(gManager.currentScore);
		_highscore.text = Convert.ToString(currentHighscore);
		_totalplays.text = Convert.ToString(PlayerPrefs.GetInt(PlayerPrefsHelper.playerTimesplayed) + 1);

		int timeplayed = playerTotalTimeplayed + gManager.totalTimePlayed;

		double hours = TimeSpan.FromSeconds(timeplayed).TotalHours;
		double minutes =  TimeSpan.FromHours(hours).TotalMinutes;
		double seconds =  TimeSpan.FromMinutes(minutes).TotalSeconds;

		_totaltimeplayed.text = Convert.ToString(string.Format("{0}h {1}m {2}s", Convert.ToInt32(hours), Convert.ToInt32(minutes), Convert.ToInt32(seconds)));

		SavePlayerData();
	}

	void SavePlayerData()
	{
		PlayerPrefs.SetInt(PlayerPrefsHelper.playerTimesplayed, PlayerPrefs.GetInt(PlayerPrefsHelper.playerTimesplayed) + 1);
		PlayerPrefs.SetInt(PlayerPrefsHelper.playerPlayTime, (playerTotalTimeplayed + gManager.totalTimePlayed));


		if(gManager.currentScore > currentHighscore)
			PlayerPrefs.SetInt(PlayerPrefsHelper.playerHighScore, gManager.currentScore);
	}
}
