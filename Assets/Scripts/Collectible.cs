﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private bool isCollected;
    // Start is called before the first frame update
    void Start()
    {
        isCollected = FindObjectOfType(typeof(GameManager));
        if (isCollected)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
