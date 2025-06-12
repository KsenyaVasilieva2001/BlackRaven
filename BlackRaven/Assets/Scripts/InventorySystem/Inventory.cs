using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory
{
    public IReadOnlyList<IInventorySlot> Slots => _slots;
    private readonly List<IInventorySlot> _slots;
    public event Action OnInventoryChanged;
    public event Action OnInventoryChangsed;

    public bool TryAdd(Item item)
    {
        var slot = _slots.FirstOrDefault(s => s.IsEmpty && s.StoredItem == null);
        if (slot == null) return false;
        slot.AddItem(item);
        OnInventoryChanged?.Invoke();
        return true;
    }

    public Item TryRemoveAt(int index)
    {
        if (index < 0 || index >= _slots.Count) return null;
        var removed = _slots[index].RemoveItem();
        if (removed != null) OnInventoryChanged?.Invoke();
        return removed;
    }
}
