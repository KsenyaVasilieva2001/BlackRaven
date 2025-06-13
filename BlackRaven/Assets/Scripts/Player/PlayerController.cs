using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMovement), typeof(PlayerRotation))]
public class PlayerController : MonoBehaviour
{
    private PlayerMovement movement;
    private PlayerRotation rotation;

    void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        rotation = GetComponent<PlayerRotation>();
    }

    void Update()
    {
        movement.Move();
        rotation.Rotate();
    }
   
}
