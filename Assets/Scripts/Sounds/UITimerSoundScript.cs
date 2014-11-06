using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class UITimerSoundScript : MonoBehaviour
{
    public GameBoardManager gbManager;

    bool isSoundRunning = false;
    bool isTimerLevel = false;
    AudioSource audioSource;

    void Start()
    {
        audioSource = transform.GetComponent<AudioSource>();
        isTimerLevel = gbManager.isTime;
    }
    void Update()
    {
        if (!isTimerLevel)
            return;

        if (gbManager.isStart && gbManager.timeLeft <= 10)
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
        if (gbManager.isSoundOn) 
            audioSource.Play();
    }
}

