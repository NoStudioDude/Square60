using UnityEngine;
using System.Collections;

public class DeactivatePhysicsScript : MonoBehaviour {

	public GameObject owner;

	void OnTriggerEnter(Collider col)
	{
		if(owner != null)
		{
			owner.transform.GetComponent<Rigidbody>().isKinematic = true;
		}
	}
	void OnTriggerExit(Collider col)
	{
		if(owner != null)
		{
			owner.transform.GetComponent<Rigidbody>().isKinematic = false;
		}
	}
}
