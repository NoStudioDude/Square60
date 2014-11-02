using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

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
        Application.LoadLevel(ScenesNames.SceneLevelSelector);
    }

    public void OnSettingsDown()
    { 
        
    }
    public void OnHighScoresDown()
    {
        
    }

    public void OnBackDown()
    {
        
        
    }

}
