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
}