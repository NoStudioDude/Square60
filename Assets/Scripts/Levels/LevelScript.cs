using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {


    public Sprite[] spriteLevel;
    public string LevelPath;
    public int mylevel;
    public bool isEnable;
    public int numberStars = 0;

    Image btnImg;

	void Start () {
        if (spriteLevel == null)
        {
            Debug.LogError("spriteLevel is null");
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
        int levelToCheck = getlevelToCheck();

        Level lvl = ReadSaveXML.LoadDataFromLevel(LevelPath, levelToCheck);
        if (lvl.Points >= (lvl.Unlock3StarsPoints / 2) || isEnable)
        {
            if (mylevel == 1)
                numberStars = lvl.UnlockedStars;
            else
            {
                lvl = ReadSaveXML.LoadDataFromLevel(LevelPath, mylevel);
                numberStars = lvl.UnlockedStars;
            }

            btnImg.sprite = spriteLevel[1];
            isEnable = true;
        }

        if (!isEnable)
            btnImg.sprite = spriteLevel[0];
        
    }

    int getlevelToCheck()
    {
        if (mylevel > 1)
            return mylevel - 1;
        else
            return mylevel;
    }
}
