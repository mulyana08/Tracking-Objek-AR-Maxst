using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSound : MonoBehaviour
{
    public string SourceBacksound;

    public static bool BackSoundStatus = true;
    void Start()
    {
        Debug.Log("Strat Backsound :" + BackSoundStatus);

        AudioSource backsound = GameObject.Find(SourceBacksound).GetComponent<AudioSource>();

        if (BgSound.BackSoundStatus == true)
        {
            backsound.mute = false;
        }
        else
        {
            backsound.mute = true;
        }
    }
}
