using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private Item itemData;
    public Item ItemData => itemData;

    public bool _isPlayerInRange;
    [SerializeField] List<Inventory> invetoryViews;

    private ItemTooltip tooltip;

    private void Start()
    {
        tooltip = GetComponent<ItemTooltip>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = true;
            tooltip?.ShowTooltip();
            InputManager.Instance.OnInteractKeyPressed += TryPickup;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = false;
            tooltip?.HideTooltip();
            InputManager.Instance.OnInteractKeyPressed -= TryPickup;
            
        }
    }

    private void TryPickup()
    {
        if (!_isPlayerInRange) return;
        for(int i = 0; i < invetoryViews.Count; i++)
        {
            if (invetoryViews[i].TryAdd(itemData))
            {
                InputManager.Instance.OnInteractKeyPressed -= TryPickup;
                Destroy(gameObject);
                tooltip?.HideTooltip();
            }
        }
    }
}
