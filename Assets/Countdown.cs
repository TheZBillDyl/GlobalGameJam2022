using UnityEngine;
using TMPro;
public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    MultiNetworkManager networkManager;
    private void Start()
    {
        networkManager = GameObject.FindObjectOfType<MultiNetworkManager>();
    }
    // Update is called once per frame
    void Update()
    {
        float num = networkManager.ballCounter;
        float maxNum = networkManager.maxBallCounter;

        text.text = (Mathf.Round(maxNum) - Mathf.Round(num)).ToString();
    }
}
