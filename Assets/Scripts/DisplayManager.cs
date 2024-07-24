using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayManager : MonoBehaviour
{
    public GameObject canvasPanel;  // El panel del canvas a mostrar
    public Text displayText;  // Referencia al Text UI para mostrar los números
    public InputField inputField;  // Referencia al InputField para ingresar la secuencia
    public string correctSequence = "9371";  // La secuencia correcta de números
    public GameObject correctActionObject; // Objeto a mostrar si la secuencia es correcta
    public GameObject gameOverObject; // Objeto a mostrar si la secuencia es incorrecta
    private List<int> displayedNumbers = new List<int>();

    // Método para mostrar el número en el Text UI
    public void DisplayNumber(int number)
    {
        displayText.text += number.ToString();
        displayedNumbers.Add(number);
    }

    // Método para verificar la secuencia ingresada
    public void VerifySequence()
    {
        string enteredSequence = inputField.text;
        if (enteredSequence == correctSequence)
        {
            Debug.Log("Secuencia correcta!");
            displayText.text = "Secuencia correcta!";
            if (correctActionObject != null)
            {
                correctActionObject.SetActive(true); // Mostrar el objeto de acción correcta
            }
        }
        else
        {
            Debug.Log("Secuencia incorrecta.");
            displayText.text = "Secuencia incorrecta.";
            if (gameOverObject != null)
            {
                gameOverObject.SetActive(true); // Mostrar el objeto de game over
            }
            // Aquí podrías añadir código para manejar la muerte del jugador
        }

        // Despausar el juego después de verificar la secuencia
        Time.timeScale = 1f;
        // Desactivar el panel del canvas
        canvasPanel.SetActive(false);
    }
}

