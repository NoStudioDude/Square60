using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ElementCollidersScript : MonoBehaviour {

	public BlockElement owner;

    void OnTriggerStay(Collider col)
    {

        if (owner.Neighbors.Count < 4)
        {
            if (col.tag == "Element")
            {
                BlockElement bEle = col.collider.transform.GetComponent<BlockElement>();
                if(!owner.Neighbors.Contains(bEle))
                    owner.Neighbors.Add(bEle);
            }
        }
    }

    //void OnTriggerEnter(Collider col)
    //{
    //    if (col.tag == "Element")
    //    {
    //        BlockElement bEle = col.collider.transform.GetComponent<BlockElement>();
    //        owner.addNeighbor(bEle);
    //    }
    //}

	void OnTriggerExit(Collider col)
	{
		if(col.tag == "Element")
		{
			BlockElement bEle = col.collider.transform.GetComponent<BlockElement>();
			owner.removeNeighbor(bEle);
		}
	}

    void Update()
    {
        
        bool isMissingElement = owner.Neighbors.Where(m => m == null).Count() > 0 ? true : false;

        if (isMissingElement)
            RemoveMissingElement();

    }

    void RemoveMissingElement()
    {
        Debug.Log("Element missing on Neighbors collection.");

        for (int i = owner.Neighbors.Count - 1; i >= 0; i--)
        {
            if (owner.Neighbors[i] == null)
            {
                Debug.Log("Removing missing element");
                owner.Neighbors.Remove(owner.Neighbors[i]);
                break;
            }
        }
    }
}