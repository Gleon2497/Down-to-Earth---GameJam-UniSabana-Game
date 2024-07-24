using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WIn : MonoBehaviour
{
    public GameObject canvasPanel; // Arrastra aquí el Canvas desde el editor
    private bool jugadorEnInterruptor = false;
    private bool activado = false;

    private void Start()
    {
        // Asegúrate de que el Canvas esté desactivado al inicio
        if (canvasPanel != null)
        {
            canvasPanel.gameObject.SetActive(false);
        }
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
            activado = true;
            ToggleCanvasPanel();
        }
    }

    private void ToggleCanvasPanel()
    {
        if (canvasPanel != null)
        {
            canvasPanel.gameObject.SetActive(true);
            // Iniciar la corutina para cambiar de escena después de 2 segundos
            StartCoroutine(CambiarAEscenaCreditos());
        }
    }

    private IEnumerator CambiarAEscenaCreditos()
    {
        // Espera 2 segundos antes de cambiar de escena
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("MainMenu"); // Cambia "NombreDeLaEscenaDeCreditos" por el nombre de tu escena de créditos
    }
}
