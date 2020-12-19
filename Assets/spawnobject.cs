using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnobject : MonoBehaviour
{

    public int difficulty;
    public Transform[] SpawnPoints;
    public GameObject[] ElementSpawn;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        Debug.Log("spawn");
        for(int i = 0; i < difficulty; i++)
        {
            Debug.Log("bubububub");
            int type = Random.Range(0, ElementSpawn.Length);
            int coordspawn = Random.Range(0, SpawnPoints.Length - 1);
            float x = Random.Range(-9.17f, 9.09f);
            float z = 5;
            float y = Random.Range(-4.75f, 4.75f);
            Vector3 pos = new Vector3(x, y, z);
            Debug.Log(type);
            Instantiate(this.ElementSpawn[type], pos, Quaternion.identity);
            
        }
        

    }
}
