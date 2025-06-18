using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private Transform dropPoint;
    [SerializeField] private Highlighter highlighter;
    [SerializeField] private Renderer playerRenderer;
    [SerializeField] private ColorMiniGameManager manager;
    [SerializeField] private ColorStep step;
    [SerializeField] private Texture changedTexture;
    public bool IsFilled = true;

    public static event Action<PlayerColor, PickableItem> OnItemEnteredPlayer;

    public bool CanAccept() => !IsFilled;

    public void Accept(PickableItem itemInstance)
    {
        Debug.Log("Accept");
        highlighter.Unhighlight();
        //manager.OnItemDropped(itemInstance, this);
        step.HandleDragDrop(itemInstance.gameObject, itemInstance.ItemData, this);
        IsFilled = true;
        highlighter.Unhighlight();
        Texture texture = changedTexture;
        if (texture != null)
        {
            playerRenderer.material.mainTexture = texture;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PickableItem>(out var item) && CanAccept())
        {
            highlighter.Highlight();
            Accept(other.gameObject.GetComponent<PickableItem>());
            OnItemEnteredPlayer?.Invoke(this, item);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PickableItem>(out var item))
        {
            highlighter.Unhighlight();
        }
    }
}
