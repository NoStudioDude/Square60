﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameBoardManager : MonoBehaviour {

    public GameObject EndGame;
    bool isEndGameShowing;

    public Transform[] blocks;
	public BlockElement[] board;
	public int currentScore = 0;
	public GameObject parentBoard;
    
    public Text LeftText;
    public Text scoreValues;
    public float timeLeft = 0;
    
    public int totalTimeSurvived = 0;
    public bool isSoundOn = true;

    public bool isStart = false;
    public bool isGameOver = false;

    public int blocksWithTime = 0;

    int sizeX = 5;
    int sizeY = 5;

    bool isTimeFrozed = false;

    void Start () {
        LeftText.text = "" + timeLeft.ToString();
        isSoundOn = Convert.ToBoolean(PlayerPrefs.GetString(PlayerPrefsHelper.setting_Music));

        totalTimeSurvived = Mathf.FloorToInt(timeLeft);
	}

	void Update () {

        if(isGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(ScenesNames.SceneMainMenu);
        }

        if (isStart && !isGameOver)
        {
            checkForPassedTime();
        }

        scoreValues.text = "" + currentScore;
	}
    void LateUpdate()
    {
        if (isGameOver && !isEndGameShowing)
        {
            isEndGameShowing = true;
            GameObject endgame = Instantiate(EndGame, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            endgame.transform.GetComponent<GameOverScript>().gManager = this;
        }
    }

    public IEnumerator StopTime()
    {
        isTimeFrozed = true;
        yield return new WaitForSeconds(10f);

        isTimeFrozed = false;
    }
    public bool isTimeRunning()
    {
        return isTimeFrozed ? false : true;
    }

    void checkForPassedTime()
    {
        if (isTimeFrozed)
            return;
            
        float timePassed = Time.deltaTime;

        if (timeLeft > 0)
        {
            timeLeft -= timePassed;
        }

        LeftText.text = "" + Mathf.FloorToInt(timeLeft);

        //Check if time is over
        if (Mathf.FloorToInt(timeLeft) == 0 && !isGameOver)
        {
            timeLeft = 0;
            isGameOver = true;

            removeBoardCollection();
        }
        
    }

	public void genPlayBoard()
	{
		float incrementValue = 0.8f;

		for(float x = 0; x < sizeX; x+=incrementValue)
		{
			for(float y = 0; y < sizeY; y+=incrementValue)
			{
				int rnd = UnityEngine.Random.Range(0, blocks.Length);
				Transform block = Instantiate(blocks[rnd], new Vector3(x, y, 0), Quaternion.identity) as Transform;
				block.parent = parentBoard.transform;
                block.gameObject.layer = parentBoard.gameObject.layer;
                block.name = "Block[" + x + "," + y + "," + "0" + "]ID: " + rnd;

                block.GetComponent<BlockElement>().ID = rnd;

			}
		}

        Vector3 centerPOS = new Vector3(-2.4f, .7f, 0f);
        parentBoard.transform.position = centerPOS;

		UpdateBoardCollection();
	}
    GameObject[] GetAllBlockElements()
    {
        return GameObject.FindGameObjectsWithTag(TagNames.TagElements);
    }
	public void UpdateBoardCollection()
	{
        GameObject[] allElements = GetAllBlockElements();
        if (allElements == null)
            return;

        int elementAmount = allElements.Length;
        board = new BlockElement[elementAmount];

		for(int e = 0; e <= elementAmount -1; e++)
			board[e] = allElements[e].transform.GetComponent<BlockElement>();
		
	}
    public void removeBoardCollection()
    {
        GameObject[] allElements = GetAllBlockElements();
        if (allElements == null)
            return;

        int elementAmount = allElements.Length;
        for (int e = 0; e <= elementAmount - 1; e++)
            Destroy(allElements[e].gameObject);

        board = null;
    }
}
