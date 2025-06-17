using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private Transform target;
    private Vector3 offset;
    private Camera cam;

    public void Init(Transform target, string message, Vector3 offset)
    {
        this.target = target;
        this.offset = offset;
        text.text = message;
        cam = Camera.main;
        gameObject.SetActive(true);
    }

    public void Release()
    {
        gameObject.SetActive(false);
        target = null;
    }

    private void LateUpdate()
    {
        if (target == null) return;
        transform.position = target.position + offset;
        transform.LookAt(cam.transform);
        transform.Rotate(0, 180f, 0);
    }
}
