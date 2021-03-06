﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameButtonsHandler : MonoBehaviour {

    public Button stopTimeButton;
    public Button removeBlockButton;
    public Button resetBlocksButton;
    
    public GameObject gOManager;
    GameBoardManager gManager;
    SelectorManager sManager;

	public bool DEGUG_MODE = false;

    void Start()
    {
        gManager = gOManager.GetComponent<GameBoardManager>();
        sManager = gOManager.GetComponent<SelectorManager>();
    }
    void LateUpdate()
    {
        
        if (gManager.isGameOver)
            setDisable();
        
    }
    void setDisable()
    {
        stopTimeButton.interactable = false;
        removeBlockButton.interactable = false;
        resetBlocksButton.interactable = false;
    }
    public void OnTimeStop()
    {
        stopTimeButton.interactable = false;
        gManager.StartCoroutine("StopTime");
    }
    public void OnRemoveBlock()
    {
        if (gManager.currentScore - 25 < 0)
            return;
        else
            gManager.currentScore -= 25;

        StartCoroutine("CountDownRemoveBlock");
    }
    IEnumerator CountDownRemoveBlock()
    {
        sManager.removeNextBlock = true;
        removeBlockButton.interactable = false;

        yield return new WaitForSeconds(30f);
        removeBlockButton.interactable = true;
    }
    public void OnResetBlocks()
    {
		if(!DEGUG_MODE) resetBlocksButton.interactable = false;
        gManager.isResetBoard = true;
    }
    

}
