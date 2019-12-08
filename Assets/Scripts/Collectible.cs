using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour {
    public int id; // 0 .. num collectibles - 1
    private bool isCollected;

    public float amplitude = 0.5f;
    public float frequency = 1f;
    private float t;
    private float offset;

    private GameManager gm;
    private Material mat;

    // Start is called before the first frame update
    void Start() {
        mat = GetComponentInChildren<Renderer>().material;

        gm = (GameManager) FindObjectOfType(typeof(GameManager)); // I think returns the script
        // Debug.Log(gm.collectibles[0]);
        isCollected = gm.collectibles[id] == 1;
        if (isCollected) {
            // shade the collectible
            shade();
        } // else
        t = Random.Range(0, 2 * Mathf.PI);
        offset = amplitude + transform.lossyScale.y + transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x, Mathf.Sin(Time.fixedTime * Mathf.PI * frequency + t) * amplitude + offset, transform.position.z);
    }

    void shade() {
        // todo
        //mat.DisableKeyword("_EMISSION");
        //GetComponentInChildren<Light>().enabled = false;
        mat.SetColor("_EmissionColor", mat.color * .5f);
    }

    public void collect() {
        // Debug.Log("I was collected!");
        // player collected us
        gm.collectibles[id] = 1;
        shade();
    }
}
