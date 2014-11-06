using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class LevelFinishedScript : MonoBehaviour {

    public Image starImage;
    public Image newScore;

    public Text textInfo;
    public Text textHighscore;
    public Text textCurrentscore;

    public GameBoardManager gManager;

    public Sprite[] starSprites;

    string[] levelEndTexts = { "Is this game that hard?!", "Too bad, you didn't got enough points to unlock the next level", "Good, you got enough points to play the next level", "Awesome job." };

    int currentLevel = 0;
    string currentFolderLevel;
    Level thisLevel;

	void Start () {
        currentLevel = PlayerPrefs.GetInt(PlayerPrefsHelper.currentLevel);
        currentFolderLevel = PlayerPrefs.GetString(PlayerPrefsHelper.currentFolderLevel);
        
        thisLevel = ReadSaveXML.LoadDataFromLevel(currentFolderLevel, currentLevel);

        textHighscore.text = "" + thisLevel.Points;
        textCurrentscore.text = "" + gManager.currentScore;

        if (gManager.currentScore > thisLevel.Points)
        {
            thisLevel.Points = gManager.currentScore;
            newScore.enabled = true;
        }
            

        if (gManager.currentScore >= thisLevel.Unlock3StarsPoints)
        { 
            //3stars
            starImage.sprite = starSprites[3];
            thisLevel.UnlockedStars = 3;

            textInfo.text = levelEndTexts[3];
        }
        else if (gManager.currentScore >= (thisLevel.Unlock3StarsPoints / 2) && gManager.currentScore < thisLevel.Unlock3StarsPoints)
        { 
            //2stars
            starImage.sprite = starSprites[2];
            thisLevel.UnlockedStars = 2;

            textInfo.text = levelEndTexts[2];
        }
        else if (gManager.currentScore > (thisLevel.Unlock3StarsPoints / 2))
        { 
            //1star
            starImage.sprite = starSprites[1];
            thisLevel.UnlockedStars = 1;

            textInfo.text = levelEndTexts[1];
        }
        else
        {
            //0stars
            starImage.sprite = starSprites[0];
            thisLevel.UnlockedStars = 0;

            textInfo.text = levelEndTexts[0];
        }
	}

    public void OnReplayDown()
    {
        BlueUIMAnager levelSelector = new BlueUIMAnager();
        LevelScript thisLevelScript = new LevelScript();
        thisLevelScript.isEnable = true;
        thisLevelScript.mylevel = currentLevel;
        thisLevelScript.LevelPath = currentFolderLevel;

        levelSelector.OnLevelDown(thisLevelScript);
    }
    public void OnMenuDown()
    {
        if (gManager.currentScore > Convert.ToInt32(textHighscore.text))
            ReadSaveXML.SaveData(thisLevel, currentFolderLevel, currentLevel);

        Application.LoadLevel(ScenesNames.SceneLevelSelector);
    }

}
