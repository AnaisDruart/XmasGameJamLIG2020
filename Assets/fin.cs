using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fin : MonoBehaviour
{
    public Text roundText;
    public Image fond;
    public Text Message;


    GameObject EventManager;
    timer timerS;
    roundManager roundManagerS;
    // Start is called before the first frame update
    void Start()
    {

        fond.enabled = false;
        roundText.enabled = false;
        Message.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timerS = (timer)FindObjectOfType(typeof(timer));
        roundManagerS = (roundManager)FindObjectOfType(typeof(roundManager));
        if (timerS.fin != false)
        {
            Message.enabled = true;
            roundText.text = "Score " + roundManagerS.round.ToString();
            fond.enabled = true;
            roundText.enabled = true;
            Debug.Log("finfin");
        }
    }
}
