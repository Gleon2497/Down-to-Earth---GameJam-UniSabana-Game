using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEvents : MonoBehaviour
{
    private Image buttonImage;

    public Sprite normalSprite;
    public Sprite hoverSprite;
    public Sprite pressedSprite;

    void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = pressedSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;
    }
}
