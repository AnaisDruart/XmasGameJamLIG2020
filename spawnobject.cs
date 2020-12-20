using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Networking;

public class spawnobject : NetworkBehaviour
{

    [SerializeField] private int difficulty;
    [SerializeField] private static  List<Transform> spawnPoints = new List<Transform>();
    public GameObject[] ElementSpawn;

    // public override void OnStartServer() => NetworkManagerLobby.OnServerReadied += Spawn;

   [Server]
    public void Spawn(NetworkConnection conn)
    {
        Debug.Log("spawn");
        for(int i = 0; i < difficulty; i++)
        {
            Debug.Log("bubububub");
            int type = Random.Range(0, ElementSpawn.Length);
            int coordspawn = Random.Range(0, spawnPoints.Count - 1);
            float x = Random.Range(-9.17f, 9.09f);
            float z = 5;
            float y = Random.Range(-4.75f, 4.75f);
            Vector3 pos = new Vector3(x, y, z);
            Debug.Log(type);
            GameObject spawnInstance = Instantiate(this.ElementSpawn[type], pos, Quaternion.identity);
            NetworkServer.Spawn(this.ElementSpawn[type], conn);

        }
        

    }
}
