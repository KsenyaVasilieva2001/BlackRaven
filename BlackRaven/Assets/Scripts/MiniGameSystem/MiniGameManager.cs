using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameManager : MonoBehaviour
{
    [SerializeField] private List<MiniGameStep> stepsInOrder;
    private int currentIndex = 0;
    private bool isInit;
    public bool IsFinished;
    public bool IsInit
    {
        get => isInit;
        set => isInit = value;
    }


    public virtual void InitMiniGame() { }

    public virtual void DisableMiniGame() { }

    void Start()
    {
        foreach (var step in stepsInOrder)
        {
            step.gameObject.SetActive(false);
        }
        ActivateStep(0);
    }

    public void ActivateStep(int idx)
    {
        Debug.Log("Activate Step");
        if (idx < stepsInOrder.Count)
        {
            currentIndex = idx;
            stepsInOrder[idx].gameObject.SetActive(true);
            stepsInOrder[idx].Enter();
        }
        else
        {
            Finish();
        }
    }

    public virtual void Finish()
    {
        
    }

    public void NextStep()
    {
        Debug.Log("Next step");
        var old = stepsInOrder[currentIndex];
        Debug.Log("Old: " + old.name);
        old.Exit();
        old.gameObject.SetActive(false);
        ActivateStep(currentIndex + 1);
    }

    public void OnItemDropped(GameObject item, IItemSlot slot)
    {
        stepsInOrder[currentIndex].HandleItem(item, slot);
    }
}
