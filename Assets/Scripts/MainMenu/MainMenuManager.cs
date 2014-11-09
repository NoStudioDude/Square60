using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class MainMenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Set Default Settings
        if (!PlayerPrefs.HasKey(PlayerPrefsHelper.setting_Music))
            PlayerPrefs.SetString(PlayerPrefsHelper.setting_Music, "true");

        if (!PlayerPrefs.HasKey(PlayerPrefsHelper.setting_Tutorial))
            PlayerPrefs.SetString(PlayerPrefsHelper.setting_Tutorial, "true");
        
        if (!PlayerPrefs.HasKey(PlayerPrefsHelper.playerHighScore))
            PlayerPrefs.SetInt(PlayerPrefsHelper.playerHighScore, 0);
        
        if (!PlayerPrefs.HasKey(PlayerPrefsHelper.playerPlayTime))
            PlayerPrefs.SetInt(PlayerPrefsHelper.playerPlayTime, 0);

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
    }

    public void OnSettingsDown()
    {
        Application.LoadLevel(ScenesNames.SceneSettings);
    }
    public void OnHighScoresDown()
    {
        Application.LoadLevel(ScenesNames.SceneScoreMenu);
    }
}
