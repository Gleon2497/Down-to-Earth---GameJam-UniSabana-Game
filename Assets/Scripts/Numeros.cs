using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Numeros : MonoBehaviour
{
    public int numberToDisplay;  // Número que este objeto representa
    private DisplayManager displayManager;

    void Start()
    {
        // Encontrar el DisplayManager en la escena
        displayManager = FindObjectOfType<DisplayManager>();
    }

    void OnMouseDown()
    {
        // Llamar al método para mostrar el número
        if (displayManager != null)
        {
            displayManager.DisplayNumber(numberToDisplay);
        }
    }
}
