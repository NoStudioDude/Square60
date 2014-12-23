using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class UITimerSoundScript : MonoBehaviour
{
    public GameBoardManager gbManager;

    bool isSoundRunning = false;
    AudioSource audioSource;

    void Start()
    {
        audioSource = transform.GetComponent<AudioSource>();
    }
    void Update()
    {

        if (gbManager.isStart && gbManager.timeLeft <= 10 && gbManager.isSoundOn)
        {
            if (!isSoundRunning)
            {
                isSoundRunning = true;
                InvokeRepeating("PlayTimerSound", 1f, 1);
            }
        }

        if (gbManager.isGameOver && isSoundRunning)
            CancelInvoke();

    }


    void PlayTimerSound()
    {
        if (gbManager.isTimeRunning() && gbManager.isSoundOn)
            audioSource.Play();
    }
}

