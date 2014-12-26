using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TutorialFingerMove : MonoBehaviour {

	public Text _score;
	public Transform[] blocks;

	List<BlockElement> selectedBlockElements = new List<BlockElement>();
	Transform _point;

	void Start()
	{
		_point = GameObject.FindGameObjectWithTag("pointToRay").GetComponent<Transform>();
	}

	void Update()
	{

		Ray ray = Camera.main.ScreenPointToRay(_point.position);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100))
		{
			if(hit.collider.tag == TagNames.TagElements)
			{
				BlockElement bEle = hit.collider.transform.GetComponent<BlockElement>();
				bEle.SelectItem();

				if(!selectedBlockElements.Contains(bEle))
					selectedBlockElements.Add(bEle);
			}
		}
	}
	public void DestroyFinger()
	{
		int score = 0;
		List<float> posX = new List<float>();

		for(int i = selectedBlockElements.Count -1; i >= 0; i--)
		{
			score += selectedBlockElements[i].scoreValue;
			posX.Add(selectedBlockElements[i].transform.position.x);

			Destroy(selectedBlockElements[i].gameObject);
		}

		_score.text = Convert.ToString(score);

		//Instatiate new blocks
		for(int t = 0; t <= posX.Count -1; t++)
		{
			int rnd = UnityEngine.Random.Range(0, blocks.Length);
			Transform instObj = blocks[rnd] as Transform;
			float positionX = posX[t];
			Transform newBlock = Instantiate(instObj, new Vector3(positionX, 4.0f, 0), Quaternion.identity) as Transform;

			GameObject _parent = GameObject.FindGameObjectWithTag("GameBoard") as GameObject;
			newBlock.parent = _parent.transform ;
			newBlock.gameObject.layer = _parent.layer;

			newBlock.name = "Block[" + positionX + "," + 4.0 + "," + "0" + "]ID: " + rnd; ;
			
			newBlock.GetComponent<BlockElement>().ID = rnd;
		}

		Destroy(this.gameObject);
	}
}
