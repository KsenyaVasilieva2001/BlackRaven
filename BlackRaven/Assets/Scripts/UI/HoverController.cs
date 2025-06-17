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
        Debug.Log("Hover on Book");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Debug.Log("Hover exit");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked on Book");
        bookUIPanel.SetActive(true);
    }

    void OnMouseEnter()
    {
        Debug.Log("Hover on Book");
        Cursor.SetCursor(magnifierCursor, hotspot, CursorMode.Auto);
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        Debug.Log("Hover exit");
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked on Book");
        bookUIPanel.SetActive(true);
    }
}