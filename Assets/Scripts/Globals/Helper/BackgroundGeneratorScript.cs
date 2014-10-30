using UnityEngine;
using System.Collections;

public class BackgroundGeneratorScript : MonoBehaviour {

	public GameObject sprite;
	public GameObject[] foregroundSprites;
	public int numberOfForegroundObjects;
	int numberOfInstatiateForegroundObjects = 0;

	// Use this for initialization
	void Awake () {
		if (sprite == null)
		{
			Debug.LogError("No background sprite found!!");
			return;
		}

		float sWorldHeight = Camera.main.orthographicSize * 2.0f;
		float sWorlWidth = sWorldHeight / Screen.height * Screen.width;

		float leftValue = ((sWorlWidth /2) + 1f) * -1;
		float rightValue = leftValue * -1;

		float sWidth = sprite.transform.GetComponent<SpriteRenderer>().bounds.size.x;

		//Spawn background element
		for (float x = leftValue; x <= rightValue; x+= sWidth)
		{
			GameObject bgSprite;
			bgSprite = Instantiate(sprite, new Vector3(x, 0, transform.position.z), Quaternion.identity) as GameObject;

			//set sprite height
			float sHeight = bgSprite.transform.GetComponent<SpriteRenderer>().bounds.size.y;
			Vector3 yHeight = bgSprite.transform.localScale;
			yHeight.y = (sWorldHeight / sHeight);
			bgSprite.transform.localScale = yHeight;

			// organise hierarchy view
			bgSprite.transform.parent = transform;
		}

		//StartCoroutine(StartForegroundSpawner(leftValue, sWorldHeight));

	}
	IEnumerator StartForegroundSpawner(float leftValue, float sWorldHeight)
	{
		//Spawn Foreground elements
		if (foregroundSprites.Length == 0)
		{
			Debug.LogError("No Foreground sprites found!!");
			yield break;
		}
		if (numberOfForegroundObjects == numberOfInstatiateForegroundObjects)
			yield break;

		GameObject foregroundObj;
		foregroundObj = Instantiate(foregroundSprites[Random.Range(0, foregroundSprites.Length)], 
		                            new Vector3(leftValue - 1.0f, Random.Range(1, (sWorldHeight/2)), -5), 
		                            Quaternion.identity) as GameObject;

		foregroundObj.transform.parent = transform;
		numberOfInstatiateForegroundObjects +=1;

		yield return new WaitForSeconds(2);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
