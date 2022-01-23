using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class MultiNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<CreateCharacterMessage>(OnCreateCharacter);
    }
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        CreateCharacterMessage characterMessage;
        if (NetworkServer.connections.Count == 1)
            characterMessage = new CreateCharacterMessage { ball = true };
        else
            characterMessage = new CreateCharacterMessage { ball = false };
        NetworkClient.connection.Send(characterMessage);
    }
    void OnCreateCharacter(NetworkConnection conn, CreateCharacterMessage message)
    {
        GameObject gameobject = Instantiate(playerPrefab);
        PlayerScript player = gameobject.GetComponent<PlayerScript>();
        player.isBall = message.ball;        
        NetworkServer.AddPlayerForConnection(conn, gameobject);
    }
    public struct CreateCharacterMessage : NetworkMessage
    {
        public bool ball;
    }
}
