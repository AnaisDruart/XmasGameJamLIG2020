using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text timeText;
    public float targetTime = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        //timeText = GetComponent<Text>() as Text;
    }

    // Update is called once per frame
    void Update()
    {
        
        targetTime -= Time.deltaTime;
        timeText.text = targetTime.ToString("00");
        //Debug.Log(targetTime);
        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }
    void timerEnded()
    {
        Debug.Log("fini");
    }
}
