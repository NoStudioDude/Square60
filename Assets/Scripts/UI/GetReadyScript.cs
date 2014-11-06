using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetReadyScript : MonoBehaviour {

    public int getThisPoints = 0;
    public Text text;
    public GameBoardManager gManager;

    int UnderMoves = 0;
    int UnderTime = 0;

	// Use this for initialization
	void Start () {

        UnderMoves = gManager.movesLeft;
        UnderTime = Convert.ToInt32(gManager.timeLeft);

        if (gManager.isTime)
            text.text = "To complete this level get " + getThisPoints + " points under " + UnderTime + " seconds";
        else
            text.text = "To complete this level get " + getThisPoints + " points under " + UnderMoves + " moves";
	}

    public void OnPlayDown()
    {
        gManager.genPlayBoard();
        gManager.isStart = true;

        Destroy(transform.gameObject);
    }
}
