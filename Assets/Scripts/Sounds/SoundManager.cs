using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour {

    public List<AudioClip> bgMusics = new List<AudioClip>();

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);

	}

	
	
}
