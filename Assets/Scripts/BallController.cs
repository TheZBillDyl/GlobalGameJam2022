using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Mirror;
public class BallController : NetworkBehaviour
{
    CinemachineVirtualCamera Vcam;
    public Rigidbody rb;
    public float speed;
    float moveX, moveY;
    Vector3 yVelocity;
    void Start()
    {
        if (isLocalPlayer)
        {
            //TODO MAKE SURE CAMERA IS PARENTLESS AND HaS CMBRAIN ENABLED AND VCAM IS ACTIVE
            Vcam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            Vcam.Follow = gameObject.transform;
            Vcam.LookAt = gameObject.transform;
            Cursor.lockState = CursorLockMode.Locked;
        }        
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");            
        }
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            Vector3 camDir = Vcam.transform.forward;
            rb.velocity = new Vector3(speed * moveY * camDir.x, rb.velocity.y, speed * moveY * camDir.z);
        }
    }
}
