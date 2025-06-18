using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorMiniGameManager : MiniGameManager
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] public List<Inventory> inventoryViews;
    [SerializeField] private Item resultItem;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject doorPanel;
    [SerializeField] private GameObject toolTip;
    [SerializeField] private PlayerColor playerColor;
    public override void InitMiniGame()
    {
        IsInit = true;
        playerColor.IsFilled = false;
        inventoryPanel.SetActive(true);
    }

    public override void DisableMiniGame()
    {
        playerColor.IsFilled = true;
        IsInit = false;
        inventoryPanel.SetActive(false);
    }

    public override void Finish()
    {
        IsFinished = true;
        resultPanel.SetActive(true);
        doorPanel.SetActive(false);
        toolTip.SetActive(true);
        DragItem.Instance.enabled = true;
    }
}
