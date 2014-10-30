using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public Animator playAnimator;
    public Animator playModesAnimator;

	// Use this for initialization
	void Start () {
        
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
        playAnimator.SetTrigger("Pressed");
        playModesAnimator.SetTrigger("showModes");
    }

    public void OnArcadeDown()
    {
        Application.LoadLevel("Square_timeAttack");
    }

    public void OnNormalDown()
    {
        Application.LoadLevel("Square_60seconds");
    }

    public void OnHighScoresDown()
    {
        Application.LoadLevel("square60_highScore");
    }

    public void OnBackDown()
    {
        playModesAnimator.SetTrigger("hideModes");
        playAnimator.SetTrigger("slideIn");
        
    }

}
