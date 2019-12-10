using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPanelScript : MonoBehaviour
{
    public AudioMixer audioComponent;

    public void SetSFX(float volume)
    {
        float db = ftodb(volume);
        audioComponent.SetFloat("SFX", db);
    }

    public void SetBGM(float volume)
    {
        float db = ftodb(volume);
        audioComponent.SetFloat("Menu", db);
        audioComponent.SetFloat("BGM", db);
    }

    private float ftodb(float volume) {
        return 20 * Mathf.Log(volume, 10);
    }
}
