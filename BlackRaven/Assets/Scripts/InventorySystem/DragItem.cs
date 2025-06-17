using System;
using UnityEngine;

public class DragItem : MonoBehaviour
{
    public static DragItem Instance { get; private set; }

    [SerializeField] private GameObject draggingObject;
    [SerializeField] private Item currentItem;
    [SerializeField] private Camera cam;

    public event Action<GameObject, Item, Plate> OnDropAttempt;

    private void Awake()
    {
        Instance = this;
        Plate.OnItemEnteredPlate += HandleTriggerDrop;
    }

    private void OnDestroy()
    {
        Plate.OnItemEnteredPlate -= HandleTriggerDrop;
    }

    public void BeginDrag(GameObject obj, Item item)
    {
        draggingObject = obj;
        currentItem = item;
    }

    private void Update()
    {
        if (draggingObject == null) return;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            draggingObject.transform.position = hit.point;
        }

        // ”бираем mouseUp Ч всЄ делаетс€ через Trigger
    }

    private void HandleTriggerDrop(Plate plate, PickableItem pickable)
    {
        if (draggingObject == null || pickable.gameObject != draggingObject)
            return;

        OnDropAttempt?.Invoke(draggingObject, currentItem, plate);
        draggingObject = null;
        currentItem = null;
    }
}
