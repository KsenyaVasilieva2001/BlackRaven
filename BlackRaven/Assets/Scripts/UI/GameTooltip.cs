using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTooltip : BaseTooltip
{
    [SerializeField] private string text;
    protected override string TooltipText => text;
}
