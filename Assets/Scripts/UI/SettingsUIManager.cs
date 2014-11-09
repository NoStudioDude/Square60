using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SettingsUIManager : MonoBehaviour {

    public Toggle tutorialCheck;
    public Toggle soundsCheck;


    void Start()
    {
        tutorialCheck.isOn = Convert.ToBoolean(PlayerPrefs.GetString(PlayerPrefsHelper.setting_Tutorial));
        soundsCheck.isOn = Convert.ToBoolean(PlayerPrefs.GetString(PlayerPrefsHelper.setting_Music));
    }

    public void OnTutorialCheck()
    {
        PlayerPrefs.SetString(PlayerPrefsHelper.setting_Tutorial, Convert.ToString(tutorialCheck.isOn));
    }
    public void OnSoundsCheck()
    {
        PlayerPrefs.SetString(PlayerPrefsHelper.setting_Music, Convert.ToString(soundsCheck.isOn));
    }

    public void OnMainMenu()
    {
        Application.LoadLevel(ScenesNames.SceneMainMenu);
    }
}
