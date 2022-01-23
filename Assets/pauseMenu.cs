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
        singleton = this;
        manager = GameObject.FindObjectOfType<MultiNetworkManager>();
        if(pauseMenuCanvas != null)
            pauseMenuCanvas.SetActive(false);
    }
    private void Update()
    {
        if (pauseMenuCanvas != null && Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenuCanvas.activeInHierarchy)
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
        }else if(pauseMenuCanvas == null)
        {
            Cursor.lockState = CursorLockMode.None;
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
        if(NetworkClient.localPlayer == null)
        {
            NetworkClient.Disconnect();
        }
        else
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
    }
    public void Quit()
    {
        Application.Quit();
    }
}
