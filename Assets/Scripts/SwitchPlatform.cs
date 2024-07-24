using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlatform : MonoBehaviour
{
    public float interval = 2.0f; // Intervalo de tiempo en segundos para cambiar la visibilidad
    public string tag1 = "Rojo"; // Primera etiqueta
    public string tag2 = "Azul"; // Segunda etiqueta

    private Renderer[] renderersTag1;
    private Collider2D[] collidersTag1;
    private Renderer[] renderersTag2;
    private Collider2D[] collidersTag2;

    void Start()
    {
        // Obtener los objetos por sus etiquetas
        GameObject[] objectsTag1 = GameObject.FindGameObjectsWithTag(tag1);
        GameObject[] objectsTag2 = GameObject.FindGameObjectsWithTag(tag2);

        // Inicializar las listas de renderers y colliders
        renderersTag1 = new Renderer[objectsTag1.Length];
        collidersTag1 = new Collider2D[objectsTag1.Length];
        renderersTag2 = new Renderer[objectsTag2.Length];
        collidersTag2 = new Collider2D[objectsTag2.Length];

        // Llenar las listas de renderers y colliders para tag1
        for (int i = 0; i < objectsTag1.Length; i++)
        {
            renderersTag1[i] = objectsTag1[i].GetComponent<Renderer>();
            collidersTag1[i] = objectsTag1[i].GetComponent<Collider2D>();
        }

        // Llenar las listas de renderers y colliders para tag2
        for (int i = 0; i < objectsTag2.Length; i++)
        {
            renderersTag2[i] = objectsTag2[i].GetComponent<Renderer>();
            collidersTag2[i] = objectsTag2[i].GetComponent<Collider2D>();
        }

        // Iniciar la corutina que alterna la visibilidad
        StartCoroutine(ToggleObjects());
    }

    IEnumerator ToggleObjects()
    {
        bool tag1Visible = true;

        while (true)
        {
            if (tag1Visible)
            {
                // Apagar todos los objetos con tag1
                foreach (Renderer renderer in renderersTag1)
                {
                    renderer.enabled = false;
                }
                foreach (Collider2D collider in collidersTag1)
                {
                    if (collider != null)
                    {
                        collider.enabled = false;
                    }
                }

                // Encender todos los objetos con tag2
                foreach (Renderer renderer in renderersTag2)
                {
                    renderer.enabled = true;
                }
                foreach (Collider2D collider in collidersTag2)
                {
                    if (collider != null)
                    {
                        collider.enabled = true;
                    }
                }
            }
            else
            {
                // Encender todos los objetos con tag1
                foreach (Renderer renderer in renderersTag1)
                {
                    renderer.enabled = true;
                }
                foreach (Collider2D collider in collidersTag1)
                {
                    if (collider != null)
                    {
                        collider.enabled = true;
                    }
                }

                // Apagar todos los objetos con tag2
                foreach (Renderer renderer in renderersTag2)
                {
                    renderer.enabled = false;
                }
                foreach (Collider2D collider in collidersTag2)
                {
                    if (collider != null)
                    {
                        collider.enabled = false;
                    }
                }
            }

            // Alternar el estado visible de tag1
            tag1Visible = !tag1Visible;

            // Esperar el intervalo especificado antes de cambiar de nuevo
            yield return new WaitForSeconds(interval);
        }
    }
}
