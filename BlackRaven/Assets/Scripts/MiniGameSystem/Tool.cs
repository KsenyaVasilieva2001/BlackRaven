using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using System;

public class Tool : MonoBehaviour
{
    [SerializeField] private Highlighter highlighter;
    public event Action OnToolClicked;

    public bool isActive = false;

    public void Highlight()
    {
        isActive = true;
        highlighter.Highlight();
    }

    public void Unhighlight()
    {
        isActive = false;
        highlighter.Unhighlight();
    }

    private void OnMouseDown()
    {
        if (!isActive) return;
        OnToolClicked?.Invoke();
    }
}

