using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using UnityEngine.UI;

//https://stackoverflow.com/questions/49158121/create-a-speedrun-timer-in-unity-c-sharp
public class timer : MonoBehaviour
{
    DateTime startTime;
    public TimeSpan timeElapsed { get; private set; }
    GameManager gm;
    Text t;
    // Start is called before the first frame update
    void Start()
    {
        t = this.gameObject.GetComponent<Text>();
        gm = (GameManager) FindObjectOfType(typeof(GameManager)); // I think returns the script
        if (gm.speedrun) {
            startTime = DateTime.Now;
        }
        else
        {
            t.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.timeElapsed = DateTime.Now - startTime;

    }
    private void OnGUI()
    {
        string time = timeElapsed.ToString();
        t.text = time.Substring(3,9);
    }
}
