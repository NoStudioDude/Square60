using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
public class ElementManager : MonoBehaviour {

	public List<Sprite> spriteList = new List<Sprite>();
	public List<ElementManager> AdjacentElements = new List<ElementManager>();

	public Vector3 velocity;
	public Vector3 gravity;
	public float maxSpeed;
	bool isStarted = false;


	// Use this for initialization
	void Start () {
		SelectSpriteElement();
	}
	
	void SelectSpriteElement()
	{
		Sprite elementSprite = spriteList[Random.Range(0, spriteList.Count -1)] as Sprite;
		gameObject.GetComponent<SpriteRenderer>().sprite = elementSprite;
	}

	void FixedUpdate()
	{
		//Vector3 pos = transform.position;
		velocity += gravity * Time.deltaTime;
		
		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
		
		transform.position += velocity * Time.deltaTime;
	}
	
	void OnMouseDown()
	{
		if (!isStarted)
			isStarted = true;

		//Start a linearRenderer

	}

	/*public void AddAdjacent(ElementManager eM)
	{
		if (!eM == null)
			AdjacentElements.Add(eM);
	}
	public void RemoveAdjacent(ElementManager eM)
	{
		if (!eM == null)
			AdjacentElements.Remove(eM);
	}*/



}
