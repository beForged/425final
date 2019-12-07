using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int[] collectibles = new int[5];
    void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameController");
        // singleton pattern
        if (objs.Length > 1) {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    }
}
