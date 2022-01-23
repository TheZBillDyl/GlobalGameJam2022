using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;
public class timer : NetworkBehaviour
{
    MultiNetworkManager mnm;
    TextMeshProUGUI tmp;
    [SyncVar]
    float timeRemaining = 300f;
    [SyncVar]
    bool TimeUp = false;
    void Start()
    {
        mnm = GameObject.FindObjectOfType<MultiNetworkManager>();
        tmp = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0f && TimeUp)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            TimeUp = true;
        }
        tmp.text = Mathf.Round(timeRemaining).ToString() + " Seconds";        
    }
}
