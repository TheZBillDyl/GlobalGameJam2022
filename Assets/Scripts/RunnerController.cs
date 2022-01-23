using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Mirror;
public class RunnerController : NetworkBehaviour
{
    CinemachineVirtualCamera Vcam;
    void Start()
    {
        if (isLocalPlayer)
        {
            Vcam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            Vcam.Follow = gameObject.transform;
            Vcam.LookAt = gameObject.transform;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        //fps controls here
    }
}
