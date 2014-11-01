using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {


    public Sprite[] spriteLevel;
    public int mylevel;
    public LevelManager lvlManager;
    public bool isEnable;
    public int numberStars = 0;

    Image btnImg;

	void Start () {
        if (lvlManager == null || spriteLevel == null)
        {
            Debug.LogError("Check public properties on LevelScript something is null");
            return;
        }
        btnImg = transform.GetComponent<Image>();
        if (btnImg == null)
        {
            Debug.LogError("Can't find spriterender for level: " + mylevel);
            return;
        }

        amIEnabled();
	}

    void amIEnabled()
    {
        for (int lvl = 0; lvl >= lvlManager.lvls.Level.Length; lvl++ )
        {
            if (lvlManager.lvls.Level[lvl].number == mylevel)
            {
                if (lvlManager.lvls.Level[lvl].Points == lvlManager.lvls.Level[lvl].Unlock3StarsPoints || isEnable)
                {
                    btnImg.sprite = spriteLevel[1];
                    isEnable = true;
                    numberStars = lvlManager.lvls.Level[lvl].UnlockedStars;
                }

                break;
            }
        }

        if (!isEnable)
            btnImg.sprite = spriteLevel[0];
        
    }
}
