using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrindingTool : Tool
{
    [SerializeField] private GameObject grinder;
    [SerializeField] private Transform grindPoint;
    [SerializeField] private float duration = 3f;
    [SerializeField] private float moveRadius= 0.5f;
    public void ProcessItem(Action onComplete)
    {
        StartCoroutine(GrindAnimation(onComplete));
    }

    private IEnumerator GrindAnimation(System.Action onComplete)
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            // ѕример простого кругового движени€
            float angle = timer * Mathf.PI * 4f; // скорость
            Vector3 offset = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * moveRadius;
            grinder.transform.position = grindPoint.position + offset;

            yield return null;
        }
        onComplete?.Invoke();
    }
}
