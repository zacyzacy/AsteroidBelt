using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float rotationSpeed = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    [SerializeField]
    private Transform gimbal;

    void Update()
    {
        //TODO need to check if upside down and reverse pitch.
        yaw = Input.GetAxis("Mouse X");
        pitch = Input.GetAxis("Mouse Y");
        transform.RotateAround(transform.position, transform.right, -pitch * rotationSpeed);
        gimbal.RotateAround(gimbal.position, gimbal.up, yaw * rotationSpeed);
    }
}