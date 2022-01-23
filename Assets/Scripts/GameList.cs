using UnityEngine;
using Mirror;
using TMPro;
using System.Text.RegularExpressions;
public class GameList : MonoBehaviour
{
    string ip = "127.0.0.1";
    [SerializeField] TMP_InputField inputField;
    Regex regex;
    public void StartHost()
    {
        MultiNetworkManager.singleton.StartHost();
    }
    public void JoinGame()
    {
        regex = new Regex("^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$");

        if (regex.Match(ip).Success)
        {
            MultiNetworkManager.singleton.networkAddress = ip;
            MultiNetworkManager.singleton.StartClient();
        }
        else
            print("Error: Wrong IP " + ip);
        
    }
    public void JoinWebGame()
    {
        ip = inputField.text;
        JoinGame();
    }

}
