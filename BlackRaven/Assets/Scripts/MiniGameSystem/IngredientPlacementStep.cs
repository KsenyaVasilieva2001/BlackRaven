using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientPlacementStep : MiniGameStep
{
    [Header("Тарелки")]
    [SerializeField] private List<Plate> plates;

    private int placedCount = 0;

    public IngredientPlacementStep(MiniGameManager mgr) : base(mgr) { }

    public override void Enter()
    {
        DragItem.Instance.OnDropAttempt += HandleDragDrop;
        //plates.ForEach(p => p.EnableReception());
    }

    public override void Exit()
    {
        DragItem.Instance.OnDropAttempt -= HandleDragDrop;
        //plates.ForEach(p => p.DisableReception());
    }

    private void HandleDragDrop(GameObject itemGO, Item itemData)
    {
        Collider[] hits = Physics.OverlapSphere(itemGO.transform.position, 0.3f);

        foreach (var col in hits)
        {
            var plate = col.GetComponent<Plate>();
            if (plate != null && plate.CanAccept(itemData))
            {
                plate.Accept(itemGO);
                HandleItem(itemGO, plate);
                return;
            }
        }

        // Если не попал — удалить или вернуть в инвентарь
        UnityEngine.Object.Destroy(itemGO);
    }

    public override void HandleItem(GameObject item, IItemSlot slot)
    {
        placedCount++;
        if (placedCount >= plates.Count)
            manager.NextStep();
    }
}