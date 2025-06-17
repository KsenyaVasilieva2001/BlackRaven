using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientPlacementStep : MiniGameStep
{
    [Header("Тарелки")]
    [SerializeField] private List<Plate> plates;
    [SerializeField] private HairDyeMiniGameManager manager;

    public int placedCount = 0;

    public IngredientPlacementStep(HairDyeMiniGameManager mgr) : base(mgr) { }

    public override void Enter()
    {
        DragItem.Instance.OnDropAttempt += HandleDragDrop;
    }

    public override void Exit()
    {
        DragItem.Instance.OnDropAttempt -= HandleDragDrop;
    }

    private void HandleDragDrop(GameObject itemGO, Item itemData, Plate plate)
    {
        if (!plate.CanAccept())
        {
            GameObject.Destroy(itemGO);
            return;
        }

        plate.Accept(itemGO);
        placedCount++;
        
        for(int i = 0; i < manager.inventoryViews.Count; i++)
        {
            manager.inventoryViews[i].TryRemove(itemData);
        }
        //manager.Inventory.TryRemoveItem(itemData); // Удаляем из инвентаря
    }

    public override void HandleItem(GameObject item, IItemSlot slot)
    {
        if (placedCount >= plates.Count)
        {
            CompleteStep();
        }
    }

    private void CompleteStep()
    {
        manager.NextStep();
    }
}
