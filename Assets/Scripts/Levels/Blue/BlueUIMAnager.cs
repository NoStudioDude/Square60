using UnityEngine;
using System.Collections;

public class BlueUIMAnager : MonoBehaviour {

    public void OnLevelDown(LevelScript lvlScript)
    {
        if (lvlScript.isEnable)
        {
            switch (lvlScript.LevelPath)
            {
                case "Blue":
                    switch (lvlScript.mylevel)
                    {
                        case 1:
                            Application.LoadLevel(ScenesNames.SceneBlueLevel1);
                            break;
                        case 2:
                            Application.LoadLevel(ScenesNames.SceneBlueLevel2);
                            break;
                        case 3:
                            Application.LoadLevel(ScenesNames.SceneBlueLevel3);
                            break;
                        case 4:
                            Application.LoadLevel(ScenesNames.SceneBlueLevel4);
                            break;
                        case 5:
                            Application.LoadLevel(ScenesNames.SceneBlueLevel5);
                            break;
                        case 6:
                            Application.LoadLevel(ScenesNames.SceneBlueLevel6);
                            break;
                        case 7:
                            Application.LoadLevel(ScenesNames.SceneBlueLevel7);
                            break;
                        case 8:
                            Application.LoadLevel(ScenesNames.SceneBlueLevel8);
                            break;
                        case 9:
                            Application.LoadLevel(ScenesNames.SceneBlueLevel9);
                            break;
                        case 10:
                            Application.LoadLevel(ScenesNames.SceneBlueLevel10);
                            break;

                        default:
                            break;
                    }

                    break;

                default:
                    break;

            }
        }
    }
}
