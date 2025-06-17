using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour, IInventory
{
    public static Inventory Instance { get; private set; }
    [SerializeField] private GameObject inventoryPanel; 
    public List<InventorySlot> Slots => slots;
    [SerializeField] private List<InventorySlot> slots;
    public event Action OnInventoryChanged;
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        InventorySlot[] foundSlots = GetComponentsInChildren<InventorySlot>(includeInactive: true);
        slots.AddRange(foundSlots);
    }

    public bool TryAdd(Item item)
    {
        var slot = slots.FirstOrDefault(s => s.IsEmpty && s.StoredItem == null);
        if (slot == null) return false;
        slot.AddItem(item);
        OnInventoryChanged?.Invoke();
        return true;
    }

    public Item TryRemoveAt(int index)
    {
        if (index < 0 || index >= slots.Count) return null;
        var removed = slots[index].RemoveItem();
        if (removed != null) OnInventoryChanged?.Invoke();
        return removed;
    }

    public void ShowOrHideInventory()
    {
        Debug.Log("Show");
        inventoryPanel.SetActive(!inventoryPanel.active);
    }
}
