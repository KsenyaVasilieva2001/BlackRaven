using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    public static DragItem Instance { get; private set; }

    [SerializeField] private GameObject draggingObject;
    [SerializeField] private Item currentItem;
    [SerializeField] private Camera cam;

    public event Action<GameObject, Item> OnDropAttempt;

    private void Awake()
    {
        Instance = this;
    }

    public void BeginDrag(GameObject obj, Item item)
    {
        draggingObject = obj;
        currentItem = item;
    }

    private void Update()
    {
        if (draggingObject == null) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            draggingObject.transform.position = hit.point;
        }
        if (Input.GetMouseButtonUp(0))
        {
            TryDrop();
        }
    }

    private void TryDrop()
    {

        /*
        if (draggingObject == null) return;
        Ray rayDown = new Ray(draggingObject.transform.position + Vector3.up * 0.1f, Vector3.down);
        if (Physics.Raycast(rayDown, out RaycastHit hit, 2f))
        {
            var slot = hit.collider.GetComponent<IItemSlot>();
            if (slot != null && slot.CanAccept(currentItem))
            {
                slot.Accept(draggingObject);
                draggingObject = null;
                currentItem = null;
                return;
            }
        }

        // Если не попали — вернуть или уничтожить предмет
        Destroy(draggingObject); // или Pool.Return(), если используешь пул
        draggingObject = null;
        currentItem = null;
        */
    }

}