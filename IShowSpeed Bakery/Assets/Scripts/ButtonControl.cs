using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Button button;
    Image image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData data)
    {
        image.color = button.colors.highlightedColor;
    }
    public void OnPointerExit(PointerEventData data)
    {
        image.color = button.colors.normalColor;
    }
}
