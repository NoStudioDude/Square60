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
    public int movesLeft = 0;

    public bool isSoundOn = true;

    public bool isTime;
    public bool isStart = false;
    public bool isGameOver = false;

    int sizeX = 5;
    int sizeY = 5;

    void Start () {
        if(isTime)
            LeftText.text = "" + timeLeft.ToString();
        else
            LeftText.text = "" + movesLeft.ToString();
	}

	void Update () {

        if (isGameOver && !isEndGameShowing)
        {
            return;
        }
        else if(isGameOver && isEndGameShowing)
            return;



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(ScenesNames.SceneMainMenu);
        }

        if (isStart && !isGameOver)
        {
            if (isTime)
                checkForPassedTime();
            else
                checkForMoves();

        }

        scoreValues.text = "" + currentScore;
	}
    void LateUpdate()
    {
        if (isGameOver && !isEndGameShowing)
        {
            isEndGameShowing = true;
            GameObject endgame = Instantiate(EndGame, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            endgame.transform.GetComponent<LevelFinishedScript>().gManager = this;
        }
    }


    void checkForPassedTime()
    {
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
    void checkForMoves()
    {
        if (movesLeft == 0)
        {
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
				int rnd = Random.Range(0, blocks.Length);
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
