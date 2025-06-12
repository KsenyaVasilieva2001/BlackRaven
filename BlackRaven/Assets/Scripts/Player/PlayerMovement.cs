using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private CharacterController characterController;
    [SerializeField] private Transform playerCameraTransform;
    private PlayerInput input;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        input = GetComponent<PlayerInput>();
    }
    public void Move()
    {
        Vector3 move = new Vector3(input.MovementInput.x, 0, input.MovementInput.y);
        move = playerCameraTransform.forward * move.z + playerCameraTransform.right * move.x;
        move.y = 0;

        characterController.Move(move.normalized * moveSpeed * Time.deltaTime);
    }
}
