using UnityEngine;
using Mirror;
using TMPro;
public class DisplayWInner : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        MultiNetworkManager manager = GameObject.FindObjectOfType<MultiNetworkManager>();
        BallController ballController = GameObject.FindObjectOfType<BallController>();
        string winner = manager.winner;

        if (winner == "Ball" && ballController.isLocalPlayer)
            text.text = "You Win!";
        else if (winner == "Runner" && ballController.isLocalPlayer)
            text.text = "You Lose";
        else if (winner == "Runner" && !ballController.isLocalPlayer)
            text.text = "You Win!";
        else if (winner == "Ball" && !ballController.isLocalPlayer)
            text.text = "You Lose!";
    }

}
