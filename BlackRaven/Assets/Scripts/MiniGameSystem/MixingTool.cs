using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixingTool : Tool
{
    protected override IEnumerator Use(GameObject target, Action onComplete)
    {
        Debug.Log("Mix!");
        // ���� �������� "����������"
        yield return new WaitForSeconds(actionDuration);
        onComplete?.Invoke();
    }
}
