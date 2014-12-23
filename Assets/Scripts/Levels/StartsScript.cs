using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class StartsScript : MonoBehaviour {

    public LevelScript parent;
    public Sprite[] StarSprites;
    SpriteRenderer sr;

    void Start()
    {
        if (parent == null)
        {
            Debug.LogError("Can't find parent for level starsScript");
            return;
        }

        sr = transform.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("Can't find spriterender for StarScript");
            return;
        }

        setStars();

    }
    void setStars()
    {

        switch (parent.numberStars)
        { 
            case 0:
                sr.sprite = StarSprites[0];
                break;
            case 1:
                sr.sprite = StarSprites[1];
                break;
            case 2:
                sr.sprite = StarSprites[2];
                break;
            case 3:
                sr.sprite = StarSprites[3];
                break;
            default:
                sr.sprite = StarSprites[0];
                break;
        }

    }

}

