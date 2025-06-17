using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    private Material originalMaterial;
    [SerializeField] private Material highlightMaterial;
    private Renderer rend;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originalMaterial = rend.material;
    }

    public void Highlight()
    {
        rend.material = highlightMaterial;
    }

    public void Unhighlight()
    {
        rend.material = originalMaterial;
    }
}
