using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roundManager : MonoBehaviour
{
    GameObject Charlie;
    interaction interactionS;
    public int round;
    public Text roundText;
    public Image fond;
    public bool fini;
    // Start is called before the first frame update
    void Start()
    {
        round = 1;
       
        fond.enabled = false;
        roundText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Charlie = GameObject.Find("EventSystem");
        interactionS = (interaction)FindObjectOfType(typeof(interaction));
        if (interactionS.transition != false)
        {
            round += 1;
            roundText.text = "Round " + round.ToString();
            fond.enabled = true;
            roundText.enabled = true;
            StartCoroutine(Attente());
            interactionS.transition = false;
            Debug.Log("2222");
        }
        
    }
    IEnumerator Attente()
    {
        Debug.Log("3333");
        yield return new WaitForSeconds(2f);
        fini = true;
        
        
        Debug.Log("???");
        yield return new WaitForSeconds(0.01f);
        fond.enabled = false;
        roundText.enabled = false;
    }
}
