using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairDyeMiniGameManager : MiniGameManager
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] public List<Inventory> inventoryViews;
    [SerializeField] private Item resultItem;
    [SerializeField] private GameObject resultPanel;

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

    public override void Finish()
    {
        for (int i = 0; i < inventoryViews.Count; i++)
        {
            if (inventoryViews[i].TryAdd(resultItem, resultItem.Type))
            {
                resultPanel.SetActive(true);
            }
        }
    }
}
