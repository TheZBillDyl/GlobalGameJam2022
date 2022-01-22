using UnityEngine;
using Mirror;
using TMPro;
using System.Text.RegularExpressions;
public class GameList : MonoBehaviour
{
    string ip = "localhost";
    [SerializeField] TMP_InputField inputField;
    Regex regex;
    public void StartHost()
    {
        NetworkManager.singleton.StartHost();
    }
    public void JoinGame()
    {
        regex = new Regex("^(?:[0-9]{1,3}\\.){3}[0-9]{1,3}$");

        if (regex.Match(ip).Success)
        {
            NetworkManager.singleton.networkAddress = ip;
            NetworkManager.singleton.StartClient();
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
