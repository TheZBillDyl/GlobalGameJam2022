using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class MultiNetworkManager : NetworkManager
{
    public GameObject runner, ball;
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
            characterMessage = new CreateCharacterMessage { ball = true };
        else
            characterMessage = new CreateCharacterMessage { ball = false };
        conn.Send(characterMessage);
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
        // This spawns the new player on all clients
        NetworkServer.AddPlayerForConnection(conn, thePlayer);
    }
}
public struct CreateCharacterMessage : NetworkMessage
{
    public bool ball;
}
