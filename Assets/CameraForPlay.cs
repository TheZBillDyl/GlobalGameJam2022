using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraForPlay : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool isBall;
    public float rotationSpeed = 10;
    public float smoothFactor = .2f;
    public void StartCam()
    {
        if (isBall)
        {
            transform.localPosition = new Vector3(0, 10, -1);
            transform.LookAt(target);
        }
        else
        {
            transform.position = target.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isBall && target != null)
        {
            transform.position = target.position + offset;

            //Do rotation
            float moveX = Input.GetAxis("Mouse X");
            Quaternion camTurnAngle = Quaternion.AngleAxis(moveX * rotationSpeed, Vector3.up);
            offset = camTurnAngle * offset;
            Vector3 newPos = target.position + offset;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
            transform.LookAt(target);
        }
    }
}
