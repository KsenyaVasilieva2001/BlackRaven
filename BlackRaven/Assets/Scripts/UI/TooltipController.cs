using System.Collections.Generic;
using UnityEngine;

public class TooltipController : MonoBehaviour
{
    [SerializeField] private BaseTooltip tooltip;


    private void OnTriggerEnter(Collider other)
    {
        InputManager.Instance.OnUseTablePressed += HandleUseTable;
        if (other.CompareTag("Player"))
        {   
            tooltip?.ShowTooltip();
            InputManager.Instance.OnUseTablePressed += HandleUseTable;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tooltip?.HideTooltip();
            InputManager.Instance.OnUseTablePressed -= HandleUseTable;
        }
    }

    private void HandleUseTable()
    {
        tooltip?.HideTooltip();
    }
}
