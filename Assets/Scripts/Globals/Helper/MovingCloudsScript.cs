using UnityEngine;
using System.Collections;

public class MovingCloudsScript : MonoBehaviour {

	float cloudSpeed = 0;

	float maxHeightValue = 0f;
	float farLeftValue = 0f;
	float farRightValue = 0f;

	// Use this for initialization
	void Awake () {
		cloudSpeed = Random.Range(0.5f, 1.5f);

		maxHeightValue = Camera.main.orthographicSize * 2.0f;
		float sWidth = maxHeightValue / Screen.height * Screen.width;
		
		farLeftValue = (sWidth /2) * -1;
		farRightValue = farLeftValue * -1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos = transform.position;

		if (pos.x > (farRightValue + 1.5f))
		{
			cloudSpeed = Random.Range(0.5f, 1.5f);
			pos.x = farLeftValue - 1.0f;
			pos.y = Random.Range(1, ((maxHeightValue/2) - 1.0f));
		}else
		{
			pos.x += cloudSpeed * Time.deltaTime;
		}

		transform.position = pos;
	}
}
