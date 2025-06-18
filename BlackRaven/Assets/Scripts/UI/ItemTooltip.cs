using DG.Tweening;
using UnityEngine;

public class ItemTooltip : BaseTooltip
{
    [SerializeField] private Item itemData;
    [SerializeField] private string tip = "(E)";
    public Item ItemData => itemData;
    protected override string TooltipText => itemData != null ? (itemData.Title + " " + tip): string.Empty;
}