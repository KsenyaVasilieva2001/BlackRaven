using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] private Item itemData;
    private bool _isSubscribed = false;
    public Item ItemData => itemData;

    public bool _isPlayerInRange;
    [SerializeField] List<Inventory> invetoryViews;

    private ItemTooltip tooltip;

    private void Start()
    {
        tooltip = GetComponent<ItemTooltip>();
        if (invetoryViews == null || invetoryViews.Count == 0)
        {
            invetoryViews = FindObjectsOfType<Inventory>().ToList();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = true;
            tooltip?.ShowTooltip();
            if (!_isSubscribed)
            {
                InputManager.Instance.OnInteractKeyPressed += TryPickup;
                _isSubscribed = true;
            }  
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = false;
            tooltip?.HideTooltip();
            if (_isSubscribed)
            {
                InputManager.Instance.OnInteractKeyPressed -= TryPickup;
                _isSubscribed = false;
            }

        }
    }

    private void TryPickup()
    {
        if (!_isPlayerInRange) return;
        Debug.Log("Pick");
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
