using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLineScript : MonoBehaviour {

	public LineRenderer line;

	List<LineRenderer> lines = new List<LineRenderer>();
	bool isDrawning = false;
	Transform startPosition;
	//Transform endPosition;

	List<Vector3> pointsList = new List<Vector3>();


	void Update()
	{
		if(Input.GetMouseButtonDown(0) & isDrawning == false)
		{
			isDrawning = true;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit))
			{
				if(hit.collider.tag == "Element")
				{
					Transform hitTransform = hit.transform;
					startPosition = hitTransform;
					SetDrawningLine();
				}
			}
		}else if (Input.GetMouseButtonUp(0))
		{
			isDrawning = false;
			startPosition = null;
			pointsList = new List<Vector3>();
			DestroyCloneLines();
		}

		Vector3 curMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 correctMousePos = new Vector3(curMousePos.x, curMousePos.y, -5);

		if (isDrawning && !pointsList.Contains(correctMousePos))
		{
			if (pointsList.Count == 2)
				pointsList.Remove(pointsList[1]);

			pointsList.Add(correctMousePos);
			KeepDrawningLine();
		}
	}

	void SetDrawningLine()
	{	
		LineRenderer lineClone;
		Vector3 correctLoc = new Vector3(startPosition.position.x, startPosition.position.y, -5);

		lineClone = Instantiate(line, correctLoc, Quaternion.identity) as LineRenderer;
		lineClone.transform.tag = "LineClone";

		lineClone.SetVertexCount(0);
		BlockElement bElement = startPosition.transform.GetComponent<BlockElement>();
		switch(bElement.ID)
		{
		case 0:
			//green
			lineClone.SetColors(Color.green, Color.green);
			lineClone.materials[0].color = Color.green;
			break;
		case 1:
			//red
			lineClone.SetColors(Color.red, Color.red);
			lineClone.materials[0].color = Color.red;
			break;
		case 2:
			//yellow
			lineClone.SetColors(Color.yellow, Color.yellow);
			lineClone.materials[0].color = Color.yellow;
			break;

		default:
			lineClone.SetColors(Color.black, Color.black);
			lineClone.materials[0].color = Color.white;
			break;
		}


		lines.Add(lineClone);
	}
	void KeepDrawningLine()
	{
		lines[lines.Count -1].SetVertexCount(pointsList.Count);
		lines[lines.Count -1].SetPosition(pointsList.Count -1, (Vector3)pointsList[pointsList.Count -1]);
	}


	void DestroyCloneLines()
	{
		GameObject[] cloneLines = GameObject.FindGameObjectsWithTag("LineClone");
		Debug.Log(cloneLines.Length);

		foreach (GameObject gO in cloneLines)
		{
			Destroy(gO.gameObject);
		}

		lines = new List<LineRenderer>();
	}


}
