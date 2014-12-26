using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    //int myLevel;
    //string LevelPath;
    public Level thisLevel;

    public Sprite[] soundSprites;
    public Image soundButton;

    public GameBoardManager gManager;

	// Use this for initialization
	void Start () {
        //myLevel = PlayerPrefs.GetInt(PlayerPrefsHelper.currentLevel);
        //LevelPath = PlayerPrefs.GetString(PlayerPrefsHelper.currentFolderLevel);

        //thisLevel = ReadSaveXML.LoadDataFromLevel(LevelPath, myLevel);

	}

    public void OnSoundDown()
    {
        if (gManager.isSoundOn)
        {
            gManager.isSoundOn = false;
            soundButton.sprite = soundSprites[1];
        }
        else
        {
            gManager.isSoundOn = true;
            soundButton.sprite = soundSprites[0];
        }

    }
}
