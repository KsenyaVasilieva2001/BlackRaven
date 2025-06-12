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
        //plates.ForEach(s => s.EnableReception());
    }
    public override void HandleItem(GameObject item, IItemSlot slot)
    {
        placedCount++;
        if (placedCount >= plates.Count)
            manager.NextStep();
    }
    public override void Exit()
    {
        //plates.ForEach(s => s.DisableReception());
    }
}
