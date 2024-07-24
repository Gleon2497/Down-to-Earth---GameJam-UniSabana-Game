using UnityEngine;
using UnityEngine.UI;

public class InteractiveObject : MonoBehaviour
{
    public GameObject canvasPanel;  // El panel del canvas a mostrar
    public int number;  // El n�mero que este objeto debe mostrar
    public int position;  // La posici�n que este n�mero ocupa

    private Text displayText;
    private bool isPanelActive = false;
    private bool jugadorEnInterruptor = false;  // Para detectar si el jugador est� en el �rea
    private bool activado = false;  // Para asegurar que no se active repetidamente

    void Start()
    {
        // Buscar el Text UI dentro del panel y configurarlo
        displayText = canvasPanel.GetComponentInChildren<Text>();
        UpdateDisplayText();
        canvasPanel.SetActive(false); // Asegurarse de que el panel est� inicialmente desactivado
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
        if (jugadorEnInterruptor && Input.GetMouseButtonDown(0) && !activado)
        {
            ToggleCanvasPanel();
            activado = true;
        }
    }

    void ToggleCanvasPanel()
    {
        if (canvasPanel != null)
        {
            isPanelActive = !isPanelActive;
            canvasPanel.SetActive(isPanelActive);
            Time.timeScale = isPanelActive ? 0 : 1;  // Pausa el juego cuando el panel est� activo, lo reanuda cuando est� inactivo
        }
    }

    void UpdateDisplayText()
    {
        if (displayText != null)
        {
            displayText.text = $"N�mero: {number}\nPosici�n: {position}";
        }
    }

    public void ClosePanel()
    {
        if (canvasPanel != null)
        {
            canvasPanel.SetActive(false);
            Time.timeScale = 1;  // Reanuda el juego cuando el panel se cierra
            activado = false;  // Permitir que se pueda activar nuevamente
        }
    }
}