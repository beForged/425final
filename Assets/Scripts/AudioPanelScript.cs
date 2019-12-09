using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPanelScript : MonoBehaviour
{
    public AudioMixer audioComponent;

    public void SetSFX(float volume)
    {
        audioComponent.SetFloat("SFX", volume);
    }

    public void SetBGM(float volume)
    {
        audioComponent.SetFloat("Menu", volume);
        audioComponent.SetFloat("BGM", volume);
    }
}
