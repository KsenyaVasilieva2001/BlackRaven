using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingStep : MiniGameStep 
{
    [Header("����������� ����������")]
    //[SerializeField] private BowlSlot bowl;
   // [SerializeField] private WaterJug waterJug;
    [SerializeField] private Tool mixingTool;
   // [SerializeField] private SpoonSlot spoon;

    public MixingStep(MiniGameManager mgr) : base(mgr) { }
    public override void Enter()
    {
      //  waterJug.EnablePouring();
       // spoon.EnableReception();
    }
    public override void HandleItem(GameObject item, IItemSlot slot)
    {
        // ������ ����� ����/����� � ����� mixingTool.Use()
    }

    public override void Exit()
    {
      //  waterJug.DisablePouring();
       // spoon.DisableReception();
    }
}
