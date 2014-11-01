using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
public class BlockElement : MonoBehaviour {


    public AudioClip[] bleepSounds;
    AudioSource audioSource;
    
	public int ID;
	public bool isSelected = false;
	public int scoreValue = 0;
	public Sprite[] spriteElement;
	public List<BlockElement> Neighbors = new List<BlockElement>();

	SpriteRenderer sr;
	// Use this for initialization
	void Start () {

		sr = transform.GetComponentInParent<SpriteRenderer>();
		sr.sprite = spriteElement[0];

        audioSource = transform.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{

		//prevent bouncing when colliding
		Vector3 currentVelocity = transform.GetComponent<Rigidbody>().velocity;
		if(currentVelocity.y <= 0)
			return;

		currentVelocity.y = 0;
		transform.GetComponent<Rigidbody>().velocity = currentVelocity;
	}

	public void addNeighbor(BlockElement eM)
	{
        if (!Neighbors.Contains(eM))
            Neighbors.Add(eM);
	}

	public void removeNeighbor(BlockElement eM)
	{
        Neighbors.Remove(eM);
	}
	public void SelectItem()
	{
		sr.sprite = spriteElement[1];
		isSelected = true;
	}
	public void UnselectItem()
	{
		sr.sprite = spriteElement[0];
		isSelected = false;	
	}

    public void playSound(int index)
    {
        if (audioSource != null)
        {
            audioSource.clip = bleepSounds[index];
            audioSource.Play();
        }
    }

}
