using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class MiniInventorySwitch : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private RectTransform inventoryPanel;
    [SerializeField] private Button toggleButton;
    [SerializeField] private Image toggleButtonImage;

    [Header("Sprites")]
    [SerializeField] private Sprite openSprite;   // Иконка "открыть"
    [SerializeField] private Sprite closeSprite;  // Иконка "закрыть"

    [Header("Positions")]
    [SerializeField] private Vector2 shownPosition;   // Например (0, 0)
    [SerializeField] private Vector2 hiddenPosition;  // Например (500, 0)
    [SerializeField] private float animationDuration = 0.4f;

    private bool isOpen = true;

    private void Awake()
    {
        toggleButton.onClick.AddListener(ToggleInventory);
        inventoryPanel.anchoredPosition = shownPosition;
        toggleButtonImage.sprite = closeSprite;
    }

    public void ToggleInventory()
    {
        isOpen = !isOpen;

        inventoryPanel.DOAnchorPos(isOpen ? shownPosition : hiddenPosition, animationDuration)
            .SetEase(Ease.InOutSine);

        toggleButtonImage.sprite = isOpen ? closeSprite : openSprite;
    }
}
