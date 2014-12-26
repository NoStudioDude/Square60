using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class MainMenuManager : MonoBehaviour {

	bool isSound = true;
	bool showTutorial = true;

	public Image sound_img;


	public Sprite soundON;
	public Sprite soundOFF;

	void Start () {
        //Set Default Settings
        if (!PlayerPrefs.HasKey(PlayerPrefsHelper.setting_Music))
			PlayerPrefs.SetString(PlayerPrefsHelper.setting_Music, Convert.ToString(isSound));

		isSound = Convert.ToBoolean(PlayerPrefs.GetString(PlayerPrefsHelper.setting_Music));

		SetSoundSprite();

        if (!PlayerPrefs.HasKey(PlayerPrefsHelper.setting_Tutorial))
			PlayerPrefs.SetString(PlayerPrefsHelper.setting_Tutorial, Convert.ToString(showTutorial));
        
        if (!PlayerPrefs.HasKey(PlayerPrefsHelper.playerHighScore))
            PlayerPrefs.SetInt(PlayerPrefsHelper.playerHighScore, 0);
        
        if (!PlayerPrefs.HasKey(PlayerPrefsHelper.playerPlayTime))
            PlayerPrefs.SetInt(PlayerPrefsHelper.playerPlayTime, 0);

		if (!PlayerPrefs.HasKey(PlayerPrefsHelper.playerTimesplayed))
			PlayerPrefs.SetInt(PlayerPrefsHelper.playerTimesplayed, 0);

	}

	void SetSoundSprite()
	{
		if(isSound)
			sound_img.sprite = soundON;
		else
			sound_img.sprite = soundOFF;
	}

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void OnPlayDown()
    {
        Application.LoadLevel(ScenesNames.SceneMainLevel);
		PlayerPrefs.SetString(PlayerPrefsHelper.tutorial_via_mainmenu, "False");
    }

    public void OnHighScoresDown()
    {
        Application.LoadLevel(ScenesNames.SceneScoreMenu);
    }

	public void OnSoundDown()
	{
		isSound = !isSound;
		PlayerPrefs.SetString(PlayerPrefsHelper.setting_Music, Convert.ToString(isSound));

		SetSoundSprite();
	}

	public void OnTutorialDown()
	{
		PlayerPrefs.SetString(PlayerPrefsHelper.tutorial_via_mainmenu, "True");

		Application.LoadLevel(ScenesNames.SceneTutorialLevel);
	}


}
