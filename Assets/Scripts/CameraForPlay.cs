using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForPlay : MonoBehaviour
{
    public Transform target;
    public Vector3 offset, cameraTargetOffset;
    public bool isBall;
    public float rotationSpeed = 10;
    public float smoothFactor = .2f;
    bool resetFirstPerson = true;
    float rotationY;
    [SerializeField] float minimumY, maximumY;
    public void StartCam()
    {
        if (!isBall)
        {
            transform.position = target.position;
            transform.LookAt(target);
        }
        else
        {
            transform.position = target.position;
            transform.SetParent(target);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isBall && target != null)
        {
            transform.position = target.position + offset;

            //Do rotation
            float moveX = Input.GetAxis("Mouse X");
            Quaternion camTurnAngle = Quaternion.AngleAxis(moveX * rotationSpeed, Vector3.up);
            offset = camTurnAngle * offset;
            Vector3 newPos = target.position + offset;
            transform.localPosition = Vector3.Slerp(transform.localPosition, newPos, smoothFactor);
            transform.LookAt(cameraTargetOffset + target.position);

            resetFirstPerson = true;
        }else if(!isBall && target!= null)
        {
            transform.position = target.position;
            if (resetFirstPerson)
            {
                transform.rotation = Quaternion.Euler(Vector3.zero);
                resetFirstPerson = false;
            }
            float moveX = Input.GetAxis("Mouse X");
            float moveY = Input.GetAxis("Mouse Y");
            rotationY += moveY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.Rotate(0, moveX * rotationSpeed, 0);
            transform.localEulerAngles = new Vector3(-rotationY * rotationSpeed, transform.localEulerAngles.y, 0);
        }
    }
}
