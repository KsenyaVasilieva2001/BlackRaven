using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDyeMiniGameManager : MiniGameManager
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] public List<Inventory> inventoryViews;


    public override void InitMiniGame()
    {
        IsInit = true;
        inventoryPanel.SetActive(true);
    }
    public override void DisableMiniGame()
    {
        IsInit = false;
        inventoryPanel.SetActive(false);
    }
}
