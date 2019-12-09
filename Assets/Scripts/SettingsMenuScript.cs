using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    public GameObject gameplayPanel;
    public GameObject volumePanel;
    public GameObject cam;


    static Animator anim;

    private void Start()
    {
        anim = cam.GetComponent<Animator>();
    }
    public void GameplayButton()
    {
        volumePanel.SetActive(false);
        gameplayPanel.SetActive(true);
    }

    public void AudioButton()
    {
        gameplayPanel.SetActive(false);
        volumePanel.SetActive(true);
    }

    public void ReturnButton()
    {
        gameplayPanel.SetActive(false);
        volumePanel.SetActive(false);
        anim.SetTrigger("ReturnButton");
    }


}
