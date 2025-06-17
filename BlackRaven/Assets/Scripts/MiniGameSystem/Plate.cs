using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour, IItemSlot
{
    [SerializeField] private Transform dropPoint;
    [SerializeField] private Highlighter highlighter;
    public bool IsFilled;
    public static event Action<Plate, PickableItem> OnItemEnteredPlate;
    public static event Action<Plate, PickableItem> OnPlateMouseDown;

    public bool CanAccept() => !IsFilled;

    public void Accept(GameObject itemInstance)
    {
        itemInstance.transform.SetParent(dropPoint);
        itemInstance.transform.localPosition = Vector3.zero;
        itemInstance.GetComponent<Collider>().enabled = false;
        MiniGameManager.Instance.OnItemDropped(itemInstance, this);
        IsFilled = true;
        highlighter.Unhighlight();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PickableItem>(out var item))
        {
            if (CanAccept())
            {
                highlighter.Highlight();
                OnItemEnteredPlate?.Invoke(this, item);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PickableItem>(out var item))
        {
            highlighter.Unhighlight();
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouse");
        if (dropPoint.childCount > 0)
        {
            Debug.Log("child count");
            var item = dropPoint.GetComponentInChildren<PickableItem>();
            Debug.Log("item" + item);
            if (item != null)
            {
                OnPlateMouseDown?.Invoke(this, item);
            }
        }
    }
}
