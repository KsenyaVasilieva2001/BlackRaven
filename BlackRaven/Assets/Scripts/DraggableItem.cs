using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DraggableItem : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Canvas canvas;
    private RectTransform rect;
    private CanvasGroup group;
    private InventorySystem inventory;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        rect = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
        inventory = FindObjectOfType<InventorySystem>();
    }

    public void OnPointerDown(PointerEventData e) {}

    public void OnBeginDrag(PointerEventData e)
    {
        group.blocksRaycasts = false;
        // прицепить 3D-префаб к курсору
       // var worldItem = Instantiate(itemSO.Prefab);
      //  Drag3D.Instance.StartDragging(worldItem);
    }

    public void OnDrag(PointerEventData e)
    {
        //Drag3D.Instance.UpdateDrag(e);
    }

    public void OnEndDrag(PointerEventData e)
    {
        group.blocksRaycasts = true;
        /*
        if (!Drag3D.Instance.TryDrop(out IItemSlot slot))
        {
            Destroy(Drag3D.Instance.Current);
            // вернуть в инвентарь
        }
        */
    }
}
