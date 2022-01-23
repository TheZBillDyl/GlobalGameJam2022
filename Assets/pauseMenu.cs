using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;
using kcp2k;
public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public static pauseMenu singleton;
    public bool isPaused = false;
    MultiNetworkManager manager;
    private void Start()
    {
        singleton = gameObject.GetComponent<pauseMenu>();
        manager = GameObject.Find("NetworkManager").GetComponent<MultiNetworkManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuCanvas.activeSelf)
            {
                Cursor.lockState = CursorLockMode.Locked;
                isPaused = false;
                pauseMenuCanvas.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                isPaused = true;
                pauseMenuCanvas.SetActive(true);
            }
        }
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuCanvas.SetActive(false);
        isPaused = false;
    }
    public void Disconnect()
    {
        if (NetworkClient.localPlayer.isClientOnly)
        {
            NetworkClient.Disconnect();
        }
        else
        {
            NetworkServer.DisconnectAll();
            NetworkClient.Disconnect();
            manager.gameObject.GetComponent<KcpTransport>().ServerStop();
        }        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
