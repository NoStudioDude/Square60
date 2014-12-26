using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialUIManager : MonoBehaviour {

	bool displayTutorial;

	public GameBoardManager gManager;
	public GameObject getReadyComponent;
	public GameObject _Game;


	void Awake () {
		
		if (PlayerPrefs.HasKey(PlayerPrefsHelper.setting_Tutorial))
			displayTutorial = Convert.ToBoolean(PlayerPrefs.GetString(PlayerPrefsHelper.setting_Tutorial));
		
		if (displayTutorial)
		{
			PlayerPrefs.SetString(PlayerPrefsHelper.tutorial_via_mainmenu, "false");
			Application.LoadLevel(ScenesNames.SceneTutorialLevel);
		}else
			InstatiateGetReady();
	}
	void InstatiateGetReady()
	{
		GameObject getReadyPrefab = (GameObject)Instantiate(getReadyComponent, new Vector3(0, 0, 0), Quaternion.identity);
		getReadyPrefab.transform.GetComponent<GetReadyScript>().gManager = gManager;
		
		_Game.SetActive(true);
		Destroy(gameObject);
	}
}
