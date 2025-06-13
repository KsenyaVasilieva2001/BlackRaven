using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private TMP_Text itemTitle;
    [SerializeField] private TMP_Text itemDescription;
    [SerializeField] private Image itemIcon;
    private void OnEnable()
    {
        InventorySlot.OnItemSelected += DisplayItemInfo;
    }

    private void OnDisable()
    {
        InventorySlot.OnItemSelected -= DisplayItemInfo;
    }

    private void DisplayItemInfo(Item item)
    {
        if (item == null) return;

        itemTitle.text = item.Title;
        itemDescription.text = item.Description;
        itemIcon.sprite = item.Icon;
        itemIcon.enabled = true;
    }

}
