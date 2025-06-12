using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private Item itemData;
    public Item ItemData => itemData;

    public bool _isPlayerInRange;
    [SerializeField] private Inventory inventory;

    public void Interact()
    {
        if (inventory.TryAdd(itemData))
        {
            Debug.Log("Add Item to inventory");
            //UI_Prompt.Hide();
            Destroy(gameObject);
        }
        else
        {
            //UI_Prompt.Show("Инвентарь полон");
        }
    }
}
