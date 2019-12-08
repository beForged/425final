using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {
    public bool speedrun = false;
    public int[] collectibles = new int[5];

    public AudioMixerSnapshot mainMenu;
    public AudioMixerSnapshot level01;

    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        // singleton pattern
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void snapSwitch(string sceneName, float time) {
        switch (sceneName) {
            case "Menu":
                mainMenu.TransitionTo(time);
                break;
            case "Main":
                level01.TransitionTo(time);
                break;
            default:
                break;
        }
    }
}
