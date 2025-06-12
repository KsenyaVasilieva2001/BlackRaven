using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 3, -6);
    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] private float minAngle = 0f;
    [SerializeField] private float maxAngle = 60f;


    private float yaw;
    private float angle;

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * rotationSpeed;
        angle -= Input.GetAxis("Mouse Y") * rotationSpeed;
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        Quaternion rotation = Quaternion.Euler(angle, yaw, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        transform.position = desiredPosition;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}