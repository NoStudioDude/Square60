using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopBarColorScript : MonoBehaviour {

    public Image redImage;
    public Image greenImage;

    public GameBoardManager gbManager;

    Level currentLevel;
	// Use this for initialization
	void Start () {
        redImage.enabled = false;
        greenImage.enabled = false;

        int currentLevelNumber = PlayerPrefs.GetInt(PlayerPrefsHelper.currentLevel);
        string currentFolderLevel = PlayerPrefs.GetString(PlayerPrefsHelper.currentFolderLevel);

        currentLevel = ReadSaveXML.LoadDataFromLevel(currentFolderLevel, currentLevelNumber);
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (!gbManager.isGameOver)
        {
            if (gbManager.timeLeft <= 10)
            {
                redImage.enabled = true;
            }
            if (gbManager.currentScore >= (currentLevel.Unlock3StarsPoints / 2))
            { 
                greenImage.enabled = true;
            }
        }

	}
}
