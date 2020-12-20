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
    public bool transition;
    float x;
    float y;
    float z;
    int move;
    float time;

    // Start is called before the first frame update
    public float speed = 1.0f;
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        transition = false;
        move = Random.Range(0, 4);

    }
    void OnMouseDown()
    {
        // this object was clicked - do something
        Debug.Log("touché");
        DestroyWithTag("Respawn");

        StartCoroutine(EventFind());
        win = true;
        move = Random.Range(0, 4);

    }

    IEnumerator EventFind()
    {
        Debug.Log("BOOOMM");
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        yield return new WaitForSeconds(0.1f);
        sprite.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = false;
        yield return new WaitForSeconds(0.15f);
        sprite.enabled = true;
        yield return new WaitForSeconds(1f);
        transition = true;
        yield return new WaitForSeconds(0.5f);
        Repop();

    }

    // Update is called once per frame
    void Update()
    {
        if (win == false)
        {
            if (move == 1)
            {
                DiagonaleDown();
            }
            if (move == 2)
            {
                DiagonaleUp();
            }
            if (move == 3)
            {
                GoUp();
            }
        }
        
    }

    void DestroyWithTag(string destroyTag)
    {
        GameObject[] destroyObject;
        destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
    }
    void Repop()
    {
        float x = Random.Range(-7.03f, 7.03f);
        float z = 10;
        float y = Random.Range(-4.75f, 4.75f);
        Vector3 pos = new Vector3(x, y, z);
        transform.position = pos;
    }

    void GoUp()
    {


        time += Time.deltaTime;
        transform.position = new Vector3(Mathf.Cos(time) * 1.5f + x, Mathf.Sin(time) * 1.5f + y, 4f);
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
            transform.position = new Vector3(-9.5f, 5.23f - transform.position.y, 4f);
        }

    }
}
