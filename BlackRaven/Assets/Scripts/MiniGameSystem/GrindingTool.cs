using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindingTool : Tool
{
    protected override IEnumerator Use(GameObject target, Action onComplete)
    {
        Debug.Log("Grind with pusher");
        // Анимация перемешивания
        yield return new WaitForSeconds(actionDuration);
        Debug.Log("Mixing complete");
        onComplete?.Invoke();
    }
}
