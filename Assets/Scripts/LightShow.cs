using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightShow : MonoBehaviour
{
    private int curr;
    private int prev;
    public float pulsePause = 1.0f;
    public float rate = 0.25f;
    private Color color = new Color(0f, 191.0f/255.0f, 115.0f/255.0f);
    void Start()
    {
        InvokeRepeating("Pulse", 0.25f, rate * transform.childCount + pulsePause);
    }

    void Pulse() {
        InvokeRepeating("NextLight", 1.0f, rate);
    }
    void NextLight() {
        if (transform.childCount == 0)
        {
            return;
        }
        transform.GetChild(prev).GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", color * 0f);
        if (curr == transform.childCount) {
            prev = 0;
            curr = 0;
            CancelInvoke("NextLight");
            return;
        }
        transform.GetChild(curr).GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", color);
        prev = curr;
        curr++;
    }
}
