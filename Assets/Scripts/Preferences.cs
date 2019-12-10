using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preferences : MonoBehaviour
{
    [SerializeField]
    private Times toggle;

    public class Times
    {
        public float[] times;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (!PlayerPrefs.HasKey("times"))
        {
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
