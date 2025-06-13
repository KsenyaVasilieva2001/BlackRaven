using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventorySlot
{
    bool IsEmpty { get; }
    Item StoredItem { get; }
    void AddItem(Item item);
    Item RemoveItem();

    Item ChooseItem();
}
