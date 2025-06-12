using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Prompt : MonoBehaviour
{
    private static TMP_Text _promptText;
    private static CanvasGroup _canvas;


    public static void Show(string message)
    {
        _promptText.text = message;
        _canvas.alpha = 1;
    }

    public static void Hide()
    {
        _canvas.alpha = 0;
    }
}
