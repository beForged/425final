using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameplayMenuScript : MonoBehaviour
{
    GameManager gm;
    private GameObject timer;
    public Button yes;
    public Button no;
    // Start is called before the first frame update
    void Awake()
    {
        no.Select();
    }

    void Start()
    {
        gm = (GameManager)FindObjectOfType(typeof(GameManager));
        timerNo();
    }

    public void timerYes()
    {
        gm.speedrun = true;
        EventSystem.current.SetSelectedGameObject(null);
        yes.Select();
    }

    public void timerNo()
    {
        gm.speedrun = false;
        EventSystem.current.SetSelectedGameObject(null);
        no.Select();
    }
}
