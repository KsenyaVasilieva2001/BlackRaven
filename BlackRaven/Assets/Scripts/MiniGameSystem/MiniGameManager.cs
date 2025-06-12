using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public static MiniGameManager Instance { get; private set; }
    [SerializeField] private List<MiniGameStep> stepsInOrder;
    private int currentIndex = 0;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        foreach (var step in stepsInOrder)
        {
            step.gameObject.SetActive(false);
        }
        ActivateStep(0);
    }

    private void ActivateStep(int idx)
    {
        if (idx < stepsInOrder.Count)
        {
            currentIndex = idx;
            stepsInOrder[idx].gameObject.SetActive(true);
            stepsInOrder[idx].Enter();
        }
    }

    public void NextStep()
    {
        var old = stepsInOrder[currentIndex];
        old.Exit();
        old.gameObject.SetActive(false);

        ActivateStep(currentIndex + 1);
    }

    public void OnItemDropped(GameObject item, IItemSlot slot)
    {
        stepsInOrder[currentIndex].HandleItem(item, slot);
    }
}
