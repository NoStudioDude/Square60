using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeColorScript : MonoBehaviour {


	Text _time;
    public GameBoardManager gbManager;

	void Start()
	{
		_time = gameObject.GetComponent<Text>();
		_time.color = Color.green;
	}

    // Update is called once per frame
	void Update () {

        if(gbManager.timeLeft <= 10 && !gbManager.isGameOver)
			_time.color = Color.red;
    }
}
