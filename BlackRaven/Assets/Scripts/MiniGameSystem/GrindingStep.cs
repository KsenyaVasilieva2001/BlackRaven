using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindingStep : MiniGameStep
{
    [SerializeField] private List<Plate> plates;
    [SerializeField] private GrindingTool grindingTool;
    [SerializeField] private new HairDyeMiniGameManager manager;

    private Plate selectedPlate;
    private PickableItem selectedItem;
    private int processed = 0;

    public GrindingStep(MiniGameManager mgr) : base(mgr) { }

    public override void Enter()
    {
        Plate.OnPlateMouseDown += OnPlateClicked;
        grindingTool.OnToolClicked += OnToolClicked;
    }

    public override void Exit()
    {
        Plate.OnPlateMouseDown -= OnPlateClicked;
        grindingTool.OnToolClicked -= OnToolClicked;
        grindingTool.Unhighlight(); 
    }

    private void OnPlateClicked(Plate plate, PickableItem item)
    {
        if (selectedPlate != null || !plate.IsFilled) return;

        selectedPlate = plate;
        selectedItem = item;
        grindingTool.Highlight();
    }

    private void OnToolClicked()
    {
        if (selectedPlate == null || selectedItem == null) return;

        /*
        GameObject.Destroy(selectedItem.gameObject); // удал€ем предмет с тарелки
        selectedPlate.IsFilled = false;
        selectedPlate = null;
        selectedItem = null;
        grindingTool.Unhighlight();
        processed++;
        if (processed >= plates.Count)
        {
            manager.NextStep();
        }
        */
        grindingTool.ProcessItem(() => {
            GameObject.Destroy(selectedItem.gameObject);
            selectedPlate.IsFilled = false;
            selectedPlate = null;
            selectedItem = null;
            grindingTool.Unhighlight();
            processed++;
            if (processed >= plates.Count)
            {
                manager.NextStep();
            }
        });
    }

    public override void HandleItem(GameObject item, IItemSlot slot)
    {
        //перенести сюда потом
    }
}
