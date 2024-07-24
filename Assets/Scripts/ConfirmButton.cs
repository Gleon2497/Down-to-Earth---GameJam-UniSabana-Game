using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    public GameObject canvasPanel;  // El panel del canvas a ocultar
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ClosePanel);
    }

    void ClosePanel()
    {
        if (canvasPanel != null)
        {
            canvasPanel.SetActive(false);
            Time.timeScale = 1;  // Reanuda el juego cuando el panel se cierra
        }
    }
}