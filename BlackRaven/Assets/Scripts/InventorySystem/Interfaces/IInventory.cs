using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    event Action OnInventoryChanged;
    bool TryAdd(Item item);
    Item TryRemoveAt(int slotIndex);
}
