using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerLobby networkManager = null;

    [Header("UI")]
    [SerializeField] private GameObject landingPagePanel = null;

    public void HostLobby() // When we press the host button
    {
        networkManager.StartHost();

        landingPagePanel.SetActive(false); //Disable the landing page panel
    }
}
