using System;
using System.Collections;
using UnityEngine;

public class MixingStep : MiniGameStep
{
    [SerializeField] private GrindingTool grindingTool;
    [SerializeField] private CupTool cup;
    [SerializeField] private PitcherTool pitcher;
    [SerializeField] private new HairDyeMiniGameManager manager;

    public enum StepState { WaitingForGrind, WaitingForPitcher, Done }
    public StepState currentState = StepState.WaitingForGrind;

    public MixingStep(MiniGameManager mgr) : base(mgr) { }

    public override void Enter()
    {
        grindingTool.OnToolClicked += OnGrindingToolClicked;
        pitcher.OnToolClicked += OnPitcherClicked;
        cup.OnToolClicked += OnCupClicked;

        grindingTool.isActive = true;
        cup.Unhighlight();
    }

    public override void Exit()
    {
        grindingTool.OnToolClicked -= OnGrindingToolClicked;
        pitcher.OnToolClicked -= OnPitcherClicked;
        cup.OnToolClicked -= OnCupClicked;
    }

    private void OnGrindingToolClicked()
    {
        Debug.Log("Clicked on grind");
        if (currentState != StepState.WaitingForGrind) return;
        cup.Highlight();
    }

    private void OnPitcherClicked()
    {
        if (currentState != StepState.WaitingForPitcher) return;
        cup.Highlight();
    }

    private void OnCupClicked()
    {
        if (currentState == StepState.WaitingForGrind)
        {
            cup.Unhighlight();
            grindingTool.PlayPourAnimation(() =>
            {
                currentState = StepState.WaitingForPitcher;
                pitcher.isActive = true;
            });
        }
        else if (currentState == StepState.WaitingForPitcher)
        {
            cup.Unhighlight();
            cup.isActive = true;
            pitcher.PlayPourAnimation(() =>
            {
                currentState = StepState.Done;
                manager.NextStep();
            });
        }
    }

    public override void HandleItem(GameObject item, IItemSlot slot)
    {
        throw new NotImplementedException();
    }
}
