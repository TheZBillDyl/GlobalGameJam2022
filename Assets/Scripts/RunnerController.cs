using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Mirror;
public class RunnerController : NetworkBehaviour
{
    public float mouseSensitivity = 800f;
    GameObject Vcam;

    float xRotation = 0f;
    public CharacterController controller;
    public float speed = 12f;

    public float jumpHeight = 3f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask ground;
    public bool isGrounded;
    void Start()
    {
        if (isLocalPlayer)
        {
            Camera.main.transform.SetParent(gameObject.transform);
            Camera.main.GetComponent<CinemachineBrain>().enabled = false;
            Camera.main.transform.localPosition = new Vector3(0, 0.8f, 0);
            Camera.main.transform.localEulerAngles = new Vector3(0,0,0);
            Vcam = GameObject.Find("CM vcam1");
            Vcam.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocalPlayer)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);
            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;            

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            
            transform.Rotate(Vector3.up * mouseX);            

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            if (!pauseMenu.singleton.isPaused)
            {
                controller.Move(move * speed * Time.deltaTime);
                Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }
        }        
    }
}
