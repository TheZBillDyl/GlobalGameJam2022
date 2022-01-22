using UnityEngine;
using Mirror;
using TMPro;
public class GameList : MonoBehaviour
{
    string ip = "localhost";
    [SerializeField] TMP_InputField inputField;
    public void StartHost()
    {
        NetworkManager.singleton.StartHost();
    }
    public void JoinGame()
    {
        NetworkManager.singleton.networkAddress = ip;
        NetworkManager.singleton.StartClient();
    }
    public void JoinWebGame()
    {
        ip = inputField.text;
        JoinGame();
    }
}
