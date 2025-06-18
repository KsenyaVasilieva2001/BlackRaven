using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(PlayerMovement), typeof(PlayerRotation))]
public class PlayerController : MonoBehaviour
{
    public Collider currentTrigger { get; private set; }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger)
        {
            currentTrigger = other;
            Debug.Log(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other == currentTrigger)
        {
            currentTrigger = null;
        }
    }

}
