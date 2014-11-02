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
        Level lvl = ReadSaveXML.LoadDataFromLevel(LevelPath, mylevel);
        if (lvl.Points >= lvl.Unlock3StarsPoints || isEnable)
        {
            btnImg.sprite = spriteLevel[1];
            isEnable = true;
            numberStars = lvl.UnlockedStars;
        }

        if (!isEnable)
            btnImg.sprite = spriteLevel[0];
        
    }
}
