using UnityEngine;
using UnityEngine.EventSystems;

public class HoverController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private Texture2D magnifierCursor;
    [SerializeField] private Vector2 hotspot;

    public GameObject bookUIPanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(magnifierCursor, hotspot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bookUIPanel.SetActive(true);
    }

    void OnMouseEnter()
    {
        Cursor.SetCursor(magnifierCursor, hotspot, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseDown()
    {
        bookUIPanel.SetActive(true);
    }
}