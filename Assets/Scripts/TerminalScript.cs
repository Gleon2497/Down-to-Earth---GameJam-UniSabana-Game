using UnityEngine;
using UnityEngine.EventSystems;

public class TerminalScript : MonoBehaviour
{
    public GameObject canvasPanel;  // El panel del canvas a mostrar

    private bool jugadorEnTerminal = false;  // Para detectar si el jugador est� en el �rea
    private bool activado = false;  // Para asegurar que no se active repetidamente

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnTerminal = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnTerminal = false;
        }
    }

    void Update()
    {
        if (jugadorEnTerminal && Input.GetMouseButtonDown(0) && !activado)
        {
            ToggleCanvasPanel();
            activado = true;
        }
    }

    void ToggleCanvasPanel()
    {
        if (canvasPanel != null)
        {
            bool isActive = canvasPanel.activeSelf;
            canvasPanel.SetActive(!isActive);
            Time.timeScale = isActive ? 1 : 0;  // Pausa el juego cuando el panel est� activo, lo reanuda cuando est� inactivo
        }
    }
}