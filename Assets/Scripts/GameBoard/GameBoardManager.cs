using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameBoardManager : MonoBehaviour {

    public Transform[] blocks;
	public BlockElement[] board;
	public int currentScore = 0;
	public GameObject parentBoard;
    
    public bool isTimeAttack;

    public GameObject gameObj;
    public GameObject gameOverObject;

    public Text tipText;
    public Text timeLeftText;
    public Text scoreValues;
    public float timeLeft = 0;
    
    public bool isStart = false;
    public bool isGameOver = false;

    int sizeX = 5;
    int sizeY = 5;

    int tipTimeLeft = 10;
    int lastTip = 0;
    string[] tips = new string[] {"Tip: Join at least two cubes to score.", "Tip: Try to make longer chains for more points", "Tip: Make a square to remove all cubes of the same color"};

	void Awake()
	{
		genPlayBoard();
	}

	void Start () {
        timeLeftText.text = "" + timeLeft.ToString();

        if (tipText != null)
            InvokeRepeating("DisplayTips", tipTimeLeft, tipTimeLeft);
	}

	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("main_menu");
        }

        if (isStart && !isGameOver)
        {
            float timePassed = Time.deltaTime;

            if (timeLeft > 0)
            {
                timeLeft -= timePassed;
            }
        }
        
        timeLeftText.text = "" + Mathf.FloorToInt(timeLeft);
        scoreValues.text = "" + currentScore;


        //Check if time is over
        if (Mathf.FloorToInt(timeLeft) == 0 && !isGameOver)
        {
            timeLeft = 0;
            isGameOver = true;

            removeBoardCollection();

            gameObj.SetActive(false);
            gameOverObject.SetActive(true);
        }
	}

    void DisplayTips()
    {
        if (lastTip > tips.Length -1)
        {
            lastTip = 0;
        }

        tipText.text = tips[lastTip];

        lastTip += 1;
    }

	void genPlayBoard()
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
        return GameObject.FindGameObjectsWithTag("Element");
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
