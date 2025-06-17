using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotDragItem : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private InventorySlot slot;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (slot.StoredItem == null || slot.StoredItem.Prefab == null) return;

        var worldItem = Instantiate(slot.StoredItem.Prefab);
        DragItem.Instance.BeginDrag(worldItem, slot.StoredItem);
    }
}
