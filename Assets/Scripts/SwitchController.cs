using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Sprite switchOnSprite;
    public Sprite switchOffSprite;

    private bool isOn = false;
    private bool jugadorEnInterruptor = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateSprite();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnInterruptor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnInterruptor = false;
        }
    }

    void Update()
    {
        if (jugadorEnInterruptor && Input.GetMouseButtonDown(0))
        {
            ToggleSwitch();
        }
    }

    void ToggleSwitch()
    {
        isOn = !isOn;
        UpdateSprite();
    }

    void UpdateSprite()
    {
        if (isOn)
        {
            spriteRenderer.sprite = switchOnSprite;
        }
        else
        {
            spriteRenderer.sprite = switchOffSprite;
        }
    }
}


