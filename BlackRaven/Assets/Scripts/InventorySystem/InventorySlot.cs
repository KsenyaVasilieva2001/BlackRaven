using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IInventorySlot, IPointerClickHandler, IPointerDownHandler
{
    [SerializeField] private Image iconImage;

    public static event Action<InventorySlot> OnAnySlotSelected;
    public static event Action<Item> OnItemSelected;
    public bool IsEmpty => item == null;

    public ItemType requiredItemType;
    public Item StoredItem => item;
    private Item item;
    private bool isSelected = false;

    void Awake()
    {
        iconImage = GetComponentInChildren<Image>();
    }
    private void OnEnable()
    {
        OnAnySlotSelected += HandleOtherSlotSelected;
    }

    private void OnDisable()
    {
        OnAnySlotSelected -= HandleOtherSlotSelected;
    }

    public void AddItem(Item item)
    {
        this.item = item;
        UpdateUI();
    }
    
    private void UpdateUI()
    {
        if (item != null)
        {
            iconImage.sprite = item.Icon;
            iconImage.enabled = true;
        }
        else
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
        }
    }
    public Item RemoveItem()
    {
        var tmp = item;
        item = null;
        UpdateSelectionVisual();
        UpdateUI();
        return tmp;
    }

    public Item ChooseItem()
    {
        if (item == null) return null;
        isSelected = true;
        UpdateSelectionVisual();
        OnAnySlotSelected?.Invoke(this); 
        OnItemSelected?.Invoke(item);

        return item;
    }

    private void HandleOtherSlotSelected(InventorySlot selectedSlot)
    {
        if (selectedSlot != this)
        {
            isSelected = false;
            UpdateSelectionVisual();
        }
    }

    private void UpdateSelectionVisual()
    {

        iconImage.color = isSelected ? new Color(17, 255, 0) : Color.white;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        ChooseItem();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item == null || item.Prefab == null) return;

        var worldItem = Instantiate(item.Prefab);
        DragItem.Instance.BeginDrag(worldItem, item);
    }
}
