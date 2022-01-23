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
    float moveY;
    void Start()
    {
        if (isLocalPlayer)
        {
            Vcam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            Vcam.Follow = gameObject.transform;
            Vcam.LookAt = gameObject.transform;
        }        
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            moveY = Input.GetAxisRaw("Vertical");            
        }
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            Vector3 camDir = Vector3.zero;
            if (Vcam != null)
                 camDir = Vcam.transform.forward;

            rb.velocity = new Vector3(speed * moveY * camDir.x, rb.velocity.y, speed * moveY * camDir.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            GameObject.FindObjectOfType<MultiNetworkManager>().CheckWinner();
        }
    }
}
