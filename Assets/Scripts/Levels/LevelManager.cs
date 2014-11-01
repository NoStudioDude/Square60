using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public Levels lvls;
	// Use this for initialization
	void Start () {
        var _lvls = Levels.Load();
        lvls = _lvls;
	}
}
