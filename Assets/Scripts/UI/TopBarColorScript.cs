using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TopBarColorScript : MonoBehaviour {

    public Image redImage;
    public Image greenImage;

    public Sprite[] soundSprites;
    public Image soundButton;

    public GameBoardManager gbManager;

    
    int highscore = 0;
    // Use this for initialization
	void Start () {
        redImage.enabled = false;
        greenImage.enabled = false;

        highscore = PlayerPrefs.GetInt(PlayerPrefsHelper.playerHighScore);
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (!gbManager.isGameOver)
        {
            if (gbManager.timeLeft <= 10)
            {
                redImage.enabled = true;
            }
            if (gbManager.currentScore >= highscore)
            { 
                greenImage.enabled = true;
            }
        }

	}

    public void OnSoundDown()
    {
        if (gbManager.isSoundOn)
        {
            gbManager.isSoundOn = false;
            soundButton.sprite = soundSprites[1];
        }
        else
        {
            gbManager.isSoundOn = true;
            soundButton.sprite = soundSprites[0];
        }

    }
}
