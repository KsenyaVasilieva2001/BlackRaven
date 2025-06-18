using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorStep : MiniGameStep
{
    [Header("Игрок")]
    [SerializeField] private PlayerColor playerReceiver;
    [SerializeField] private new ColorMiniGameManager manager;

    public int placedCount = 0;

    public ColorStep(HairDyeMiniGameManager mgr) : base(mgr) { }

    public override void Enter()
    {
        DragItem.Instance.OnDropAttemptPlayer += HandleDragDrop;
    }

    public override void Exit()
    {
        DragItem.Instance.OnDropAttemptPlayer -= HandleDragDrop;
    }

    public void HandleDragDrop(GameObject itemGO, Item itemData, PlayerColor player)
    {
        Debug.Log("Handle Drag");
        Destroy(itemGO);
        placedCount++;
        
        for (int i = 0; i < manager.inventoryViews.Count; i++)
        {
            manager.inventoryViews[i].TryRemove(itemData);
        }
        DragItem.Instance.enabled = false;
        CompleteStep();
    }

    public override void HandleItem(GameObject item, IItemSlot slot)
    {
    }

    private void CompleteStep()
    {
        manager.NextStep();
    }
}
