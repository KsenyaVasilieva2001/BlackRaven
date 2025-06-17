using DG.Tweening;
using UnityEngine;

public class ItemTooltip : BaseTooltip
{
    [SerializeField] private Item itemData;
    public Item ItemData => itemData;
    protected override string TooltipText => itemData != null ? itemData.Title : string.Empty;
}