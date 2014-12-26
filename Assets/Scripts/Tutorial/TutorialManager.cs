using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {

	string[] tutorialSteps = { 
		"Welcome to Colors. Before we start let me show you around" ,
		"In the middel you have the game board", 
		"Here you have the time left to play, your current score and your highscore" ,
		"Below you have a few 'power-ups'" , 
		"First 'power-up' will freeze de time for 10 seconds, you can only use this 'power-up' once every game" ,
		"The second 'power-up' can be used to remove one block from the board, this 'power-up' can be used as many times as you want",
		"However, it will use points(25) from your score, and can only be used once every 30 seconds" ,
		"The last 'power-up' will reset the board and spawn new blocks and can be used once every 60 seconds" ,
		"To play, you have to touch one block and drag your finger on top of another block of the same color" ,
		"Releasing the touch will remove the selected blocks giving you points" ,
		"Try to make longer chains for more points" , 
		"If you make a square all others blocks of the same color on the board will be removed" ,
		"Giving you extra points" ,
		"And incrementing the time left",
		"You can always read this tutorial again from the main menu",
		"Click anywhere to go back"
	};

	public Text tutorialInfo;
	int currentTutorialIndex = 0;

	public GameObject board;
	public GameObject[] arrows_score_time;
	public GameObject[] arrows_powerups;
	public RectTransform tutorial_Painel;
	public GameObject powerup_Painel;
	public GameObject ui_Finger;
	Animator fingerAnim;
	
	public Text score;
	public Text time;
	public Text highScore;


	bool waitForAnimation
	{
		get
		{
			return fingerAnim != null ? fingerAnim.GetCurrentAnimatorStateInfo(0).IsName("finger_move_right") : false;
		}
	}
	bool isViaMenu
	{
		get
		{
			return Convert.ToBoolean(PlayerPrefs.GetString(PlayerPrefsHelper.tutorial_via_mainmenu));
		}
	}

	// Use this for initialization
	void Awake () {
		//SetDefaults
		PlayerPrefs.SetString(PlayerPrefsHelper.setting_Tutorial, "False");

		tutorialInfo.text = tutorialSteps[currentTutorialIndex];

		SetArrowsTimeScore(false);

		score.text = Convert.ToString(0);
		time.text = Convert.ToString(60);
		highScore.text = Convert.ToString(PlayerPrefs.GetInt(PlayerPrefsHelper.playerHighScore));

		ui_Finger.SetActive(false);
		if(ui_Finger != null)
			fingerAnim = ui_Finger.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0) && !waitForAnimation)
		{
			ProceedTutorial();
		}
	}

	void ProceedTutorial()
	{	
		currentTutorialIndex++;

		if(currentTutorialIndex <= tutorialSteps.Length -1)
		{
			tutorialInfo.text = tutorialSteps[currentTutorialIndex];
			DisplayArrows();
		}else
			if(currentTutorialIndex >= 15)
				if(isViaMenu)
					Application.LoadLevel(ScenesNames.SceneMainMenu);
				else
					Application.LoadLevel(ScenesNames.SceneMainLevel);

	}

	void DisplayArrows()
	{
		SetArrowsTimeScore(false);

		switch(currentTutorialIndex)
		{
		case 1:
			board.SetActive(true);
			break;
		case 2:
			SetArrowsTimeScore(true);
			break;
		case 3:
			tutorial_Painel.anchoredPosition = new Vector2(0f, 255f);
			powerup_Painel.SetActive(true);
			break;
		case 4:
			SetArrowsPowerups_TimeFreeze(true);
			break;
		case 5:
			SetArrowsPowerups_TimeFreeze(false);
			SetArrowsPowerups_RemoveBlock(true);
			break;
		case 7:
			SetArrowsPowerups_RemoveBlock(false);
			SetArrowsPowerups_ResetBoard(true);
			break;
		case 8:
			SetArrowsPowerups_ResetBoard(false);
			ui_Finger.SetActive(true);
			if(fingerAnim != null) fingerAnim.SetTrigger("movefinger");

			break;
		case 9:
			ui_Finger.GetComponent<TutorialFingerMove>().DestroyFinger();
			break;

		default:
			break;

		}

	}

	void SetArrowsTimeScore(bool _active)
	{
		if(arrows_score_time.Length > 0)
		{
			for(int i = 0; i <= arrows_score_time.Length -1; i++)
			{
				arrows_score_time[i].SetActive(_active);
			}	
		}else
			Debug.LogError("Time/Score arrows gameObject not found");

	}

	void SetArrowsPowerups_TimeFreeze(bool _active)
	{
		arrows_powerups[0].SetActive(_active);
	}
	void SetArrowsPowerups_RemoveBlock(bool _active)
	{
		arrows_powerups[1].SetActive(_active);
	}
	void SetArrowsPowerups_ResetBoard(bool _active)
	{
		arrows_powerups[2].SetActive(_active);
	}

}
