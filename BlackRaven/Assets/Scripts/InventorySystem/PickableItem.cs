using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private Item itemData;
    public Item ItemData => itemData;

    public bool _isPlayerInRange;
    [SerializeField] private Inventory inventory;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = true;
            InputManager.Instance.OnInteractKeyPressed += TryPickup;
            //UI_Prompt.Show("Нажмите [E], чтобы подобрать " + itemData.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = false;
            InputManager.Instance.OnInteractKeyPressed -= TryPickup;
            //UI_Prompt.Hide();
        }
    }


    private void TryPickup()
    {
        if (!_isPlayerInRange) return;
        if (inventory.TryAdd(itemData))
        {
            //UI_Prompt.Hide();\
            InputManager.Instance.OnInteractKeyPressed -= TryPickup;
            Destroy(gameObject);
        }
        else
        {
            //UI_Prompt.Show("Инвентарь полон");
        }
    }
}
