﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SountdManager : MonoBehaviour
{
    public AudioSource audioSourceBGM;
    public AudioClip[] audioClipsBGM;

    public AudioSource audioSourceSE;
    public AudioClip[] audioClipsSE;

    public static SountdManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBGM(string sceneName)
    {
        audioSourceBGM.Stop();

        switch (sceneName)
        {
            default:
            case "Title":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;
            case "Town":
                audioSourceBGM.clip = audioClipsBGM[1];
                break;
            case "Quest":
                audioSourceBGM.clip = audioClipsBGM[2];
                break;
            case "Battle":
                audioSourceBGM.clip = audioClipsBGM[3];
                break;
        }

        audioSourceBGM.Play();
    }

    public void StopBGM()
    {
        audioSourceBGM.Stop();
    }

    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]);
    }
}
