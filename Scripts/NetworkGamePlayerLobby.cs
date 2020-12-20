using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class NetworkGamePlayerLobby : NetworkBehaviour
{
     
    [SyncVar]
    private string displayName = "Loading...";


    private NetworkManagerLobby room;

    private NetworkManagerLobby Room
    {
        get
        {
            if(room != null) { return room; }
            return room = NetworkManagerLobby.singleton as NetworkManagerLobby;
        }
    }


    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject);
        Room.GamePlayers.Add(this);
    }

    public override void OnStopServer()
    {
        Room.GamePlayers.Remove(this);
    }

    [Server]
    public void SetDisplayName(string displayName)
    {
        this.displayName = displayName;
    }

}

