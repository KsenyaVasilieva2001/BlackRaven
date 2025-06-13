using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class PlayerItemInteractor : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private LayerMask pickableLayer;
    [SerializeField] private PickableItem item;

    void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, pickableLayer))
        {
            Debug.Log("Can interact");
            if (hit.collider.GetComponent<PickableItem>())
            {
                item = hit.collider.GetComponent<PickableItem>();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    item?.Interact();
                }
            }
        }
        else
        {
            item = null;
        }
    }
}
*/
