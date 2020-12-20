using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    GameObject EventSystem;
    timer timerScript;
    bool win;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem = GameObject.Find("EventSystem");
        timerScript = EventSystem.GetComponent<timer>();
        timerScript.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
