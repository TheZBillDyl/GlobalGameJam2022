using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraForPlay : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool isBall;
    public float rotationSpeed = 10;
    public float smoothFactor = .2f;
    bool resetFirstPerson = true;
    float rotationY;
    [SerializeField] float minimumY, maximumY;
    [SerializeField] CinemachineVirtualCamera c;
    public void StartCam()
    {
        if (!isBall)
        {
            transform.position = target.position;
        }
        else
        {
            //transform.position = target.position;
            c.Follow = target;
            c.LookAt = target;
        }
    }
}
