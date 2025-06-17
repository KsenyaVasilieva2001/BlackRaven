using UnityEngine;
using DG.Tweening;

public abstract class BaseTooltip : MonoBehaviour
{
    [SerializeField] protected float animatedSize = 0.0004f;
    [SerializeField] protected Vector3 tooltipOffset = new Vector3(0, 2f, 0);

    protected Tooltip currentTooltip;

    protected abstract string TooltipText { get; }

    public void ShowTooltip()
    {
        if (currentTooltip != null) return;

        currentTooltip = TooltipPool.Instance.Get();
        currentTooltip.Init(transform, TooltipText, tooltipOffset);
        AnimateTooltip();
    }

    private void AnimateTooltip()
    {
        currentTooltip.transform.localScale = Vector3.zero;
        currentTooltip.transform.DOScale(animatedSize, 0.3f).SetEase(Ease.OutBack);
    }

    public void HideTooltip()
    {
        if (currentTooltip != null)
        {
            TooltipPool.Instance.Return(currentTooltip);
            currentTooltip = null;
        }
    }
}