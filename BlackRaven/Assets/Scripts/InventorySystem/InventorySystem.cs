using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private List<Item> items = new List<Item>();
    public event Action OnInventoryUpdated;

    public void AddItem(Item item)
    {
        items.Add(item);
        OnInventoryUpdated?.Invoke();
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        OnInventoryUpdated?.Invoke();
    }

    public IEnumerable<Item> GetItems() => items;

}
