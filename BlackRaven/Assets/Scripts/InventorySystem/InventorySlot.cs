using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour, IInventorySlot
{
    public bool IsEmpty => _item == null;

    public ItemType requiredItemType;
    public Item StoredItem => _item;
    private Item _item;

    public void AddItem(Item item) => _item = item;
    public Item RemoveItem()
    {
        var tmp = _item;
        _item = null;
        return tmp;
    }
}
