using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialUIManager : MonoBehaviour {

    public Text tutText;
    public GameBoardManager gManager;
    public GameObject getReadyComponent;
    public GameObject tutorialComponent;
    public GameObject _Game;

    int tutorialStepsIndex = 0;
    string[] tutorialSteps = { 
                                 "Welcome to Colors. Before we start let me show you around" ,
                                 "Above you have the time left to play and your score" ,
                                 "Below you have a few 'power-ups'" , 
                                 "First 'power-up' will freeze de time for 10 seconds, you can only use this 'power-up' once every game" ,
                                 "The second 'power-up' can be used to remove one block from the board, this 'power-up' can be used as many times as you want",
                                 "However, it will use points(25) from your score, and can only be used every 30 seconds" ,
                                 "The last 'power-up' will reset the board and spawn new blocks and can be used once every 60 seconds" ,
                                 "To play, you have to touch one block and drag your finger on top of another block of the same color" ,
                                 "Releasing the touch will remove the selected blocks giving you points" ,
                                 "Try to make longer chains for more points" , 
                                 "If you make a square all others blocks of the same color on the board will be removed" ,
                                 "Giving you extra points" ,
                                 "Blocks with a number inside will increase your time left by the number inside of the block"
                             };

    bool displayTutorial = false;
	// Use this for initialization
	void Awake () {
	    
        if (PlayerPrefs.HasKey(PlayerPrefsHelper.setting_Tutorial))
            displayTutorial = Convert.ToBoolean(PlayerPrefs.GetString(PlayerPrefsHelper.setting_Tutorial));

        if (displayTutorial)
        {
            tutorialComponent.SetActive(true);

            tutText.text = tutorialSteps[tutorialStepsIndex];
            tutorialStepsIndex++;
        }
        else
        {
            InstatiateGetReady();
        }
	}
	
    void InstatiateGetReady()
    {
        GameObject getReadyPrefab = (GameObject)Instantiate(getReadyComponent, new Vector3(0, 0, 0), Quaternion.identity);
        getReadyPrefab.transform.GetComponent<GetReadyScript>().gManager = gManager;

        _Game.SetActive(true);

        Destroy(tutorialComponent);
        Destroy(gameObject);
    }
    public void OnNext()
    {
        if (tutorialStepsIndex > tutorialSteps.Length - 1)
        {
            InstatiateGetReady();
        }
        else
        {
            tutText.text = tutorialSteps[tutorialStepsIndex];
            tutorialStepsIndex++;
        }
    }
}
