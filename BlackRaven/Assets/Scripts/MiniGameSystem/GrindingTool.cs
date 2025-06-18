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

    public event Action OnClicked;

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
            float angle = timer * Mathf.PI * 4f; // скорость
            Vector3 offset = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * moveRadius;
            grinder.transform.position = grindPoint.position + offset;

            yield return null;
        }
        onComplete?.Invoke();
    }

    public void PlayPourAnimation(Action onComplete)
    {
        StartCoroutine(PourRoutine(onComplete));
    }

    private IEnumerator PourRoutine(Action onComplete)
    {
        grinder.gameObject.SetActive(false);
        transform.position += new Vector3(0f, 0.6f, 0f); 
        transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        float duration = 1.5f;
        float timer = 0f;
        Vector3 start = transform.position;
        Vector3 end = transform.position + new Vector3(0.1f, 0f, 0f);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.Lerp(start, end, Mathf.PingPong(timer * 2, 1));
            yield return null;
        }

        transform.position -= new Vector3(0f, 0.6f, 0f);
        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        grinder.gameObject.SetActive(true);
        onComplete?.Invoke();
    } 
}
