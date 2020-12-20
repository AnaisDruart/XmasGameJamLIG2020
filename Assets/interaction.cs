using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class interaction : MonoBehaviour
{
    SpriteRenderer sprite;

    GameObject EventSystem;
    timer timerScript;
    public bool win;

    // Start is called before the first frame update
    void Start()
    {
    }
    void OnMouseDown()
    {
        // this object was clicked - do something
        Debug.Log("touché");
        DestroyWithTag("Respawn");

        StartCoroutine(EventFind());
        win = true;


    }

    IEnumerator EventFind()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.15f);
        sprite.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyWithTag(string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }
}
