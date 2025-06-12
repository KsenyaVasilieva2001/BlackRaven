using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MiniGameStep : MonoBehaviour
{
    protected MiniGameManager manager;
    public MiniGameStep(MiniGameManager mgr) => manager = mgr;
    public abstract void Enter();
    public abstract void HandleItem(GameObject item, IItemSlot slot);
    public abstract void Exit();
}
