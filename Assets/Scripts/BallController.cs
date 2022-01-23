using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Mirror;
public class BallController : NetworkBehaviour
{
    GameObject Vcam;
    void Start()
    {
        if (isLocalPlayer)
        {
            Vcam = GameObject.Find("CM vcam1");
            CinemachineVirtualCamera Cvcam = Vcam.GetComponent<CinemachineVirtualCamera>();
            Cvcam.Follow = gameObject.transform;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        //tps controls here
    }
}
