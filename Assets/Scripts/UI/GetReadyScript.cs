using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetReadyScript : MonoBehaviour {

    public GameBoardManager gManager;

    public void OnPlayDown()
    {
        gManager.genPlayBoard();
        gManager.isStart = true;

        Destroy(transform.gameObject);
    }
}
