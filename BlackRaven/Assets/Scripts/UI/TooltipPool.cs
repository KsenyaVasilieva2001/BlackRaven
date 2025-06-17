using System.Collections.Generic;
using UnityEngine;

public class TooltipPool : MonoBehaviour
{
    [SerializeField] private Tooltip tooltipPrefab;
    [SerializeField] private int poolSize = 10;

    private readonly Queue<Tooltip> pool = new Queue<Tooltip>();

    public static TooltipPool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        for (int i = 0; i < poolSize; i++)
        {
            var tooltip = Instantiate(tooltipPrefab, transform);
            tooltip.gameObject.SetActive(false);
            pool.Enqueue(tooltip);
        }
    }

    public Tooltip Get()
    {
        if (pool.Count == 0)
        {
            var tooltip = Instantiate(tooltipPrefab, transform);
            tooltip.gameObject.SetActive(false);
            return tooltip;
        }

        return pool.Dequeue();
    }

    public void Return(Tooltip tooltip)
    {
        tooltip.Release();
        pool.Enqueue(tooltip);
    }
}