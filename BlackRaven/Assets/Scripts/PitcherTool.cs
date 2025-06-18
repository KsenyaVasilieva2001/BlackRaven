using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitcherTool : Tool 
{

    public void PlayPourAnimation(Action onComplete)
    {
        StartCoroutine(PourRoutine(onComplete));
    }

    private IEnumerator PourRoutine(Action onComplete)
    {
        transform.position += new Vector3(0f, 0.5f, 0f);
        float duration = 1.5f;
        float timer = 0f;
        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, -45f);

        while (timer < duration)
        {
            timer += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(startRot, endRot, timer / duration);
            yield return null;
        }
        transform.position -= new Vector3(0f, 0.5f, 0f);
        transform.rotation = startRot;
        onComplete?.Invoke();
    }
}
