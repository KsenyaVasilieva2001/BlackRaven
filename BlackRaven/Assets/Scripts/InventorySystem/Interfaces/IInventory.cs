using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    IReadOnlyList<IInventorySlot> Slots { get; }
    event Action OnInventoryChangsed;
    bool TryAdd(Item item);
    Item TryRemoveAt(int slotIndex);
}
