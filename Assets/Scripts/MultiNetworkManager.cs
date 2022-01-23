using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class MultiNetworkManager : NetworkManager
{
    public GameObject runner, ball, countDownCanvas;
    private NetworkConnection ballConnection = null;
    public float ballCounter = 0f;
    public float maxBallCounter = 10f;
    private GameObject currentCountDownCanvas;
    public string winner = "";
    public int impactCount = 0;
    List<GameObject> playerList = new List<GameObject>();
    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<CreateCharacterMessage>(OnCreateCharacter);
    }
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect();
        CreateCharacterMessage characterMessage;
        if (NetworkServer.connections.Count == 1)
        {
            ballConnection = conn;

            currentCountDownCanvas = Instantiate(countDownCanvas, Vector3.zero, Quaternion.identity);
        }
        else
        {
            characterMessage = new CreateCharacterMessage { ball = false };
            conn.Send(characterMessage);
        }            
    }
    void OnCreateCharacter(NetworkConnection conn, CreateCharacterMessage message)
    {
        GameObject thePlayer;
        if (!message.ball)
        {
            thePlayer = (GameObject)Instantiate(runner, Vector3.zero, Quaternion.identity);
        }
        else
        {
            thePlayer = (GameObject)Instantiate(ball, Vector3.zero, Quaternion.identity);
        }
        playerList.Add(thePlayer);
        // This spawns the new player on all clients
        NetworkServer.AddPlayerForConnection(conn, thePlayer);
    }
    private void Update()
    {
        if(ballConnection != null)
        {
            if (ballCounter < maxBallCounter)
            {
                ballCounter += Time.deltaTime;
            }
            else
            {
                ballCounter = 0f;
                CreateCharacterMessage characterMessage = new CreateCharacterMessage { ball = true };
                ballConnection.Send(characterMessage);
                ballConnection = null;
                currentCountDownCanvas.SetActive(false);
            }
        }        
    }
    public void SetWinner(string win)
    {
        winner = win;
    }

    public void CheckWinner()
    {
        impactCount++;
        if(impactCount >= NetworkServer.connections.Count - 1)
        {
            SetWinner("Ball");
            for (int i = 0; i < playerList.Count; i++)
            {
                if(playerList[i].TryGetComponent<BallController>(out BallController c))
                {
                    DontDestroyOnLoad(playerList[i]);
                }
                else
                {
                    Destroy(playerList[i]);
                    playerList.RemoveAt(i);
                    i--;
                }
            }
            ServerChangeScene("EndOfGame");
        }
    }

    public override void OnStopServer()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i] != null)
            {
                Destroy(playerList[i]);
            }
        }
        playerList.Clear();
        base.OnStopServer();
    }
}
public struct CreateCharacterMessage : NetworkMessage
{
    public bool ball;
}
