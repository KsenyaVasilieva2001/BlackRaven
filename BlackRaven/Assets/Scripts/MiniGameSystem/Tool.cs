using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public float actionDuration = 1.0f;

    public void StartUse(GameObject target, Action onComplete)
    {
        StartCoroutine(Use(target, onComplete));
    }

    protected virtual IEnumerator Use(GameObject target, Action onComplete)
    {
        //тут типа анимация
        yield return new WaitForSeconds(actionDuration);
        onComplete?.Invoke();
    }
}
