using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public int myLevel;
    public string LevelPath;
    public Level thisLevel;

    public Sprite[] soundSprites;
    public Image soundButton;

    public GameBoardManager gManager;

	// Use this for initialization
	void Start () {
        thisLevel = ReadSaveXML.LoadDataFromLevel(LevelPath, myLevel);

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
