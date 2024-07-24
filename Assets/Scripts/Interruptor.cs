using UnityEngine;
using System.Collections;

public class Interruptor : MonoBehaviour
{
    public GameObject puerta;
    public Vector3 nuevaPosicion;
    public float duracionMovimiento = 2f; // Duraci�n del movimiento en segundos
    private bool activado = false;
    private bool jugadorEnInterruptor = false;
    private Vector3 posicionOriginal; // Posici�n original de la puerta

    private void Start()
    {
        // Almacenar la posici�n original de la puerta al inicio
        posicionOriginal = puerta.transform.position;
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

    private void Update()
    {
        if (jugadorEnInterruptor && Input.GetMouseButtonDown(0))
        {
            if (activado)
            {
                StartCoroutine(MoverPuerta(posicionOriginal));
            }
            else
            {
                StartCoroutine(MoverPuerta(nuevaPosicion));
            }
            activado = !activado; // Alternar el estado de activado
        }
    }

    private IEnumerator MoverPuerta(Vector3 destino)
    {
        Vector3 posicionInicial = puerta.transform.position;
        float tiempoTranscurrido = 0f;

        while (tiempoTranscurrido < duracionMovimiento)
        {
            puerta.transform.position = Vector3.Lerp(posicionInicial, destino, tiempoTranscurrido / duracionMovimiento);
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }

        puerta.transform.position = destino; // Asegurarse de que la puerta est� exactamente en la posici�n de destino al final
    }
}


