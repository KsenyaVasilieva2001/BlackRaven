using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour, IItemSlot
{
    [SerializeField] private Transform dropPoint;
    private bool isActive;
    [SerializeField] private Highlighter highlighter;

    public bool CanAccept(Item item) { return true; }
       // => isActive && item.Type == ItemType.Ingredient;

    public void Accept(GameObject itemInstance)
    {
        itemInstance.transform.SetParent(dropPoint);
        itemInstance.transform.localPosition = Vector3.zero;
        MiniGameManager.Instance.OnItemDropped(itemInstance, this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PickableItem>(out var item))
        {
            highlighter.Highlight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PickableItem>(out var item))
        {
            highlighter.Unhighlight();
        }
    }

}
