using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectorManager : MonoBehaviour {

	class spawnElementClass
	{
		public float posX = 0;
		public int amount = 0;
	}

    bool isSquare = false;
	List<spawnElementClass> helperSpawner = new List<spawnElementClass>();
	List<BlockElement> selectedBlockElements = new List<BlockElement>();
	int selectElementWithThisID = 0;
	bool isMouseDown = false;
	
	BlockElement lastElementSelected = null;
	BlockElement firstSelection = null;
	GameBoardManager gameBoardManager;

	void Start()
	{
		gameBoardManager = transform.GetComponent<GameBoardManager>();
	}

	RaycastHit GetMouseToScreenRayInfo()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 100))
		{
			return hit;
		}

		return hit;
	}

    void Update () {

        if (gameBoardManager.isGameOver)
        {
            if (selectedBlockElements.Count > 0)
                CleanSelectedElements();
                
            return;
        }
			

		if(Input.GetMouseButtonDown(0) && !isMouseDown)
		{
            if (!gameBoardManager.isStart)
                gameBoardManager.isStart = true;

			isMouseDown = true;
			RaycastHit hit = GetMouseToScreenRayInfo();
			if(hit.collider != null)
			{
				if(hit.collider.tag == "Element")
				{
					BlockElement bEle = hit.transform.GetComponent<BlockElement>();
					selectElementWithThisID = bEle.ID;
					firstSelection = bEle;
					return;
				}
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			if(selectedBlockElements.Count >=2)
			{
				setScore();
			}else
				CleanSelectedElements();

			isMouseDown = false;
		}

		if(isMouseDown)
		{
			CheckMouseOverElements();
		}
	}

	void setScore()
	{
		//Check if we made a square
        isSquare = false;
		if(selectedBlockElements.Count >= 4)
		{
			foreach(var n in lastElementSelected.Neighbors)
			{
				if(n.Equals(firstSelection))
				{
					isSquare = true;
					break;
				}
			}
		}

		if(isSquare)
		{
			AddAllSameElementsIDsToCollection();
		}

		SetScoreSingleSelection();

		CleanSelectedElements();
	}
	void AddAllSameElementsIDsToCollection()
	{
		gameBoardManager.UpdateBoardCollection();

		for(int e = 0; e <= gameBoardManager.board.Length -1; e++)
		{
			if(!IsOnSelectedList(gameBoardManager.board[e]) && gameBoardManager.board[e].ID == selectElementWithThisID)
			{
				selectedBlockElements.Add(gameBoardManager.board[e]);
			}
		}
	}

	void SetScoreSingleSelection()
	{
		int totalScore = 0;
        int numberOfSelectedBlocks = selectedBlockElements.Count;

		for(int e = selectedBlockElements.Count -1; e >= 0; e--)
		{
			float x = selectedBlockElements[e].transform.position.x;
            SetHelperSpawnerClass(x);

			totalScore += selectedBlockElements[e].scoreValue;
            RemoveNeighbors(selectedBlockElements[e]);

			Destroy(selectedBlockElements[e].transform.gameObject);
		}

        if (numberOfSelectedBlocks >= 4)
            totalScore *= 2;

		gameBoardManager.currentScore += totalScore;
        InstatiateMissingElements();

        if (gameBoardManager.isTimeAttack)
        {
            if (isSquare)
            {
                gameBoardManager.timeLeft += 2;
            }
            else
            {
                var timeToAdd = numberOfSelectedBlocks * 0.25f;
                gameBoardManager.timeLeft += timeToAdd;
            }
        }
	}
    void RemoveNeighbors(BlockElement eM)
    {
        foreach (BlockElement n in eM.Neighbors)
        {
            n.removeNeighbor(eM);
        }
    }
	void SetHelperSpawnerClass(float x)
	{
        bool isInCollection = false;
		foreach(var hS in helperSpawner)
		{
            if (hS.posX == x)
            {
                isInCollection = true;
                hS.amount += 1;
                break;
            }
		}
        if (!isInCollection)
        {
            helperSpawner.Add(new spawnElementClass { posX = x, amount = 1 });
        }
		
	}

	void InstatiateMissingElements()
	{
        float posY = GameObject.FindGameObjectWithTag("Spawn").transform.position.y;
        GameObject parent = gameBoardManager.parentBoard;
        foreach (var helper in helperSpawner)
        { 
            for(int t = 1; t <= helper.amount; t++)
            {
                int rnd = Random.Range(0, gameBoardManager.blocks.Length);
                Transform instObj = gameBoardManager.blocks[rnd] as Transform;
                float posX = helper.posX;
                Transform newBlock = Instantiate(instObj, new Vector3(posX, posY + t, 0), Quaternion.identity) as Transform;
                
                newBlock.parent = parent.transform;
                newBlock.gameObject.layer = parent.gameObject.layer;
                newBlock.name = "Block[" + posX + "," + posY + "," + "0" + "]ID: " + rnd; ;

                newBlock.GetComponent<BlockElement>().ID = rnd;

            }
        }
	}
	void CheckMouseOverElements()
	{
		RaycastHit hit = GetMouseToScreenRayInfo();
		
		if(hit.collider != null)
		{
			if(hit.collider.tag == "Element")
			{
				BlockElement bEle = hit.collider.transform.GetComponent<BlockElement>();
				if(bEle.ID == selectElementWithThisID)
				{
					SetSelectedElement(bEle);
				}else
				{
					UnSelectElement(bEle);
				}
			}
		}
	}
	void SetSelectedElement(BlockElement eM)
	{
		bool isNeighbor = false; //bool to check if mouse over element is neighbor os last select element
		bool keepSelection = true; //bool to check if we mouse over the correct element but is not a neighor of the last selected element

		if(lastElementSelected != null && lastElementSelected != eM)
		{
			foreach(var e in lastElementSelected.Neighbors)
			{
				if(e.Equals(eM))
				{
					isNeighbor = true;
					keepSelection = false;
					break;
				}
			}

		}else
			isNeighbor = true;

		if(isNeighbor && !IsOnSelectedList(eM))
		{
			eM.SelectItem();
			selectedBlockElements.Add(eM);

			lastElementSelected = eM;
		}else
		{
			foreach(var e in selectedBlockElements)
			{
				if(e.Equals(eM))
				{
					keepSelection = false;
					break;
				}
					
			}

			if(!keepSelection)
				CheckIfWeHaveToUnselect(eM);
		}
	}

	void CheckIfWeHaveToUnselect(BlockElement eM)
	{
		int ourPosition = 0;
		for(int i = selectedBlockElements.Count -1; i >= 0; i--)
		{
			ourPosition = i;

			if(selectedBlockElements[i].Equals(eM))
				break;
		}

		if(ourPosition < selectedBlockElements.Count -1)
		{
			UnselectAllAfterSelected(ourPosition);
		}
	}

	bool IsOnSelectedList(BlockElement eM)
	{
		if(selectedBlockElements.Count == 0)
			return false;

		for(int i = 0; i <= selectedBlockElements.Count -1; i++)
		{
			if(selectedBlockElements[i].Equals(eM) && eM.isSelected)
				return true;
		}

		return false;
	}

	void UnselectAllAfterSelected(int pos)
	{
		for(int c = selectedBlockElements.Count -1; c > pos; c--)
		{
			selectedBlockElements[c].UnselectItem();
			selectedBlockElements.Remove(selectedBlockElements[c]);
		}

		lastElementSelected = selectedBlockElements[pos];
	}

	void UnSelectElement(BlockElement eM)
	{
		eM.UnselectItem();
		selectedBlockElements.Remove(eM);
	}

	void CleanSelectedElements()
	{
		foreach(var e in selectedBlockElements)
		{
			e.UnselectItem();
		}

		selectElementWithThisID = 0;
		lastElementSelected = null;
		firstSelection = null;
		helperSpawner.Clear();
		selectedBlockElements.Clear();
		helperSpawner = new List<spawnElementClass>();
		selectedBlockElements = new List<BlockElement>();
	}
}

