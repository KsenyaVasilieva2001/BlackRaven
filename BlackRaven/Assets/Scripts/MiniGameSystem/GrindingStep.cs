using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindingStep : MiniGameStep
{
    private int processed = 0;
  //  [SerializeField] private MortarSlot mortarSlot; // это что-то куда можно что-то класть, можно объединить с тарелкой
   // [SerializeField] private BowlSlot bowlSlot;
    [SerializeField] private Tool grindingTool;
    public GrindingStep(MiniGameManager mgr) : base(mgr) { }
    public override void Enter()
    {
      //  mortarSlot.EnableReception();
    }
    public override void HandleItem(GameObject item, IItemSlot slot)
    {
        /*
        mortarSlot.Accept(item);
        grindingTool.StartUse(item, () =>
        {
            bowlSlot.Accept(item);
            processed++;
            if (processed < 3)
                mortarSlot.EnableReception();
            else
                manager.NextStep();
        });
        */
    }
    public override void Exit()
    {
       // mortarSlot.DisableReception();
    }
}
