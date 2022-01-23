using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Mirror;
public class RunnerController : NetworkBehaviour
{
    CinemachineVirtualCamera Vcam;
    public Rigidbody rb;
    public float speed;
    public float jumpForce;
    float moveY;
    bool wasGrounded;
    void Start()
    {
        if (isLocalPlayer)
        {
            Vcam = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
            Vcam.Follow = gameObject.transform;
            Vcam.LookAt = gameObject.transform;
            Vcam.GetCinemachineComponent<CinemachineOrbitalTransposer>().m_FollowOffset = new Vector3(0, 0.15f, -0.5f);
        }
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            moveY = Input.GetAxisRaw("Vertical");
            if (wasGrounded && Input.GetKeyDown(KeyCode.Space))
            {
                //Jump
                rb.AddForce(Vector3.up * jumpForce);
                wasGrounded = false;
            }
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.ClosestPointOnBounds(this.transform.position).y < this.transform.position.y)
            wasGrounded = true;
    }
}
