using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class PlayerScript : NetworkBehaviour
{
    [SyncVar(hook = nameof(setCamera))]
    public bool isBall = false;
    public Rigidbody rb;
    public float speed, jumpPower, turnSpeed;
    float moveX, moveY;
    [SerializeField] KeyCode jumpButton;
    Vector3 yVelocity;
    public override void OnStartLocalPlayer()
    {
        //isBall = false;
       if(!isBall)
        {
            rb.freezeRotation = true;
        }
        CameraForPlay cam = Camera.main.GetComponent<CameraForPlay>();
        cam.target = this.transform;
        cam.isBall = isBall;
        cam.StartCam();
    }

    void Update()
    {
        if (isLocalPlayer) {
            //Move based on rigidbody
            moveX = Input.GetAxisRaw("Horizontal");
            moveY = Input.GetAxisRaw("Vertical");
            
            if(!isBall)
            {
                if (Input.GetKeyDown(jumpButton))
                {
                    yVelocity = Vector3.up * jumpPower;
                    rb.AddForce(yVelocity, ForceMode.VelocityChange);

                }
            }
        }        
    }

    private void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            Vector3 camDir = Camera.main.transform.forward;
            rb.velocity = new Vector3(speed * moveY * camDir.x, rb.velocity.y, speed * moveY * camDir.z);
        }
    }
    void setCamera(bool old, bool newbool)
    {
        Camera.main.GetComponent<CameraForPlay>().isBall = newbool;
    }
}
