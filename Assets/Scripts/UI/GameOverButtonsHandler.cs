using UnityEngine;
using System.Collections;

public class GameOverButtonsHandler : MonoBehaviour {

    public void OnMainMenu()
    {
        Application.LoadLevel(ScenesNames.SceneMainMenu);
    }
    public void OnPlayAgain()
    {
        Application.LoadLevel(ScenesNames.SceneMainLevel);
    }
}
