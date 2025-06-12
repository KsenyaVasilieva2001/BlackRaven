using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 10f;
    private PlayerInput input;
    private Transform playerCameraTransform;

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        playerCameraTransform = Camera.main.transform;
    }

    public void Rotate()
    {
        Vector3 direction = new Vector3(input.MovementInput.x, 0, input.MovementInput.y);
        if (direction.magnitude < 0.1f) return;

        Vector3 cameraRelativeDir = playerCameraTransform.forward * direction.z + playerCameraTransform.right * direction.x;
        cameraRelativeDir.y = 0f;

        Quaternion targetRotation = Quaternion.LookRotation(-cameraRelativeDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }
}