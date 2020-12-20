using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnobject : MonoBehaviour
{

    public int difficulty;
    public Transform[] SpawnPoints;
    public GameObject[] ElementSpawn;
    GameObject Transition;
    roundManager roundManagerS;
    interaction interactionS;
    GameObject Charlie;
    GameObject bambi;
    behavior behaviorS;
    public bool spawn;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        Charlie = GameObject.Find("Charlie");
        interactionS = (interaction)FindObjectOfType(typeof(interaction));
        Transition = GameObject.Find("Transition");
        roundManagerS = (roundManager)FindObjectOfType(typeof(roundManager));
        if(roundManagerS.fini == true && interactionS.win == true)
        {
            difficulty += difficulty / 2;
            Spawn();
            roundManagerS.fini = false;
            spawn = true;
            interactionS.win = false;
        }
    }
    public void Spawn()
    {
        Debug.Log("spawn");
        int[] movtab = new int[ElementSpawn.Length];
        for(int i = 0; i < ElementSpawn.Length; i ++)
        {
            movtab[i] = Random.Range(0, 4);
        }
        

        for(int i = 0; i < difficulty; i++)
        {
            Debug.Log("bubububub");
            int type = Random.Range(0, ElementSpawn.Length);
            float x = Random.Range(-9.17f, 9.09f);
            float z = 5;
            float y = Random.Range(-4.75f, 4.75f);
            Vector3 pos = new Vector3(x, y, z);
            Debug.Log(type);

            bambi = Instantiate(this.ElementSpawn[type], pos, Quaternion.identity);

            behaviorS = (behavior)bambi.GetComponent("behavior");
            behaviorS.move = movtab[type];

            //behaviorS.move = Random.Range(0,4);
        }
        spawn = true;
        

    }
}
