using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public float interval; // Intervalo de tiempo en segundos para cambiar la visibilidad
    private Renderer objectRenderer;
    private Collider2D objectCollider;

    void Start()
    {
        interval = Random.Range(2.0f, 10.0f); 
        // Obtener los componentes Renderer y Collider2D del objeto
        objectRenderer = GetComponent<Renderer>();
        objectCollider = GetComponent<Collider2D>();

        // Iniciar la corutina que alterna la visibilidad
        StartCoroutine(ToggleObject());
    }

    IEnumerator ToggleObject()
    {
        while (true)
        {
            // Cambiar la visibilidad del objeto
            objectRenderer.enabled = !objectRenderer.enabled;

            // Alternar el estado del collider del objeto si está presente
            if (objectCollider != null)
            {
                objectCollider.enabled = !objectCollider.enabled;
            }

            // Esperar el intervalo especificado antes de cambiar de nuevo
            yield return new WaitForSeconds(interval);
        }
    }
}
