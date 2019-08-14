using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptBackSound : MonoBehaviour
{
    public string SourceBacksound;

    void Awake()
    {
        Toggle toggleBacksound = this.gameObject.GetComponent<Toggle>();

        if (BgSound.BackSoundStatus == true)
        {
            toggleBacksound.isOn = true;
        }
        else
        {
            toggleBacksound.isOn = false;
        }

        AudioSource backsound = GameObject.Find(SourceBacksound).GetComponent<AudioSource>();

        if (toggleBacksound.isOn == true)
        {
            backsound.mute = false;
            BgSound.BackSoundStatus = true;
        }
        else
        {
            backsound.mute = true;
            BgSound.BackSoundStatus = false;
        }

    }

    public void BackSoundOnOff()
    {
        AudioSource backsound = GameObject.Find(SourceBacksound).GetComponent<AudioSource>();

        if (backsound.mute == true)
        {
            backsound.mute = false;
            BgSound.BackSoundStatus = true;
            Debug.Log("Backsound : " + BgSound.BackSoundStatus);
        }
        else
        {
            backsound.mute = true;
            BgSound.BackSoundStatus = false;
            Debug.Log("Backsound : " + BgSound.BackSoundStatus);
        }

    }
}
