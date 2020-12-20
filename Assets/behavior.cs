using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class behavior : MonoBehaviour
{
    public float targetTime;
    public int move;
    GameObject EventSystem;
    timer timerScript;
    Vector3 direction;
    SpriteRenderer sprite;
    float x;
    float y;

    float time;

    spawnobject spawnobjetS;

    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        EventSystem = GameObject.Find("EventSystem");
        //targetTime = GetComponent<float>();
        timerScript = EventSystem.GetComponent<timer>();

        x = transform.position.x;
        y = transform.position.y;
    }
    void OnMouseDown()
    {
        // this object was clicked - do something
        Debug.Log("raté");
        timerScript.targetTime -= 5;
        StartCoroutine(EventFind());
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
        //move = Random.Range(0, 4);
        sprite.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        spawnobjetS = (spawnobject)FindObjectOfType(typeof(spawnobject));
        if(spawnobjetS.spawn == true)
        {
            move = Random.Range(0, 4);
            Debug.Log(move);
            spawnobjetS.spawn = false;
        }
        if(move == 1)
        {
            DiagonaleDown();
        }
        if(move == 2)
        {
            DiagonaleUp();
        }
        if(move == 3)
        {
            GoUp();
        }
        

    }
    void GoUp()
    {
        

        time += Time.deltaTime;
        transform.position = new Vector3(Mathf.Cos(time)*1.5f + x, Mathf.Sin(time)*1.5f + y, 4f);
    }

    void DiagonaleDown()
    {
        Vector3 target = new Vector3(9.09f, 4.75f, 4f);
        float step = speed * Time.deltaTime;
        Vector3 move = new Vector3(step, step, 0);

        transform.position = Vector3.MoveTowards(transform.position, transform.position - move, step);
        if (transform.position.y < -5.23)
        {
            transform.position = new Vector3(9.5f - transform.position.x, +5.23f, 4f);
        }
        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(+9.5f, 5.23f - transform.position.y, 4f);
        }
    }
    void DiagonaleUp()
    {
        Vector3 target = new Vector3(9.09f, 4.75f, 4f);
        float step = speed * Time.deltaTime;
        Vector3 move = new Vector3(step, step, 0);
        
        transform.position = Vector3.MoveTowards(transform.position, transform.position + move, step);
        if (transform.position.y > 5.23)
        {
            transform.position = new Vector3(9.5f - transform.position.x, -5.23f, 4f);
        }
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3( -9.5f , 5.23f- transform.position.y, 4f);
        }

    }
    
}
