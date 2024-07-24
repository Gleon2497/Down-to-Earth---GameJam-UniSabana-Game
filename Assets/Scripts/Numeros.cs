using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Numeros : MonoBehaviour
{
    public int numberToDisplay;  // N�mero que este objeto representa
    private DisplayManager displayManager;

    void Start()
    {
        // Encontrar el DisplayManager en la escena
        displayManager = FindObjectOfType<DisplayManager>();
    }

    void OnMouseDown()
    {
        // Llamar al m�todo para mostrar el n�mero
        if (displayManager != null)
        {
            displayManager.DisplayNumber(numberToDisplay);
        }
    }
}
