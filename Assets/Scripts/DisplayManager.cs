using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayManager : MonoBehaviour
{
    public GameObject canvasPanel;  // El panel del canvas a mostrar
    public Text displayText;  // Referencia al Text UI para mostrar los n�meros
    public InputField inputField;  // Referencia al InputField para ingresar la secuencia
    public string correctSequence = "9371";  // La secuencia correcta de n�meros
    public GameObject correctActionObject; // Objeto a mostrar si la secuencia es correcta
    public GameObject gameOverObject; // Objeto a mostrar si la secuencia es incorrecta
    private List<int> displayedNumbers = new List<int>();

    // M�todo para mostrar el n�mero en el Text UI
    public void DisplayNumber(int number)
    {
        displayText.text += number.ToString();
        displayedNumbers.Add(number);
    }

    // M�todo para verificar la secuencia ingresada
    public void VerifySequence()
    {
        string enteredSequence = inputField.text;
        if (enteredSequence == correctSequence)
        {
            Debug.Log("Secuencia correcta!");
            displayText.text = "Secuencia correcta!";
            if (correctActionObject != null)
            {
                correctActionObject.SetActive(true); // Mostrar el objeto de acci�n correcta
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
            // Aqu� podr�as a�adir c�digo para manejar la muerte del jugador
        }

        // Despausar el juego despu�s de verificar la secuencia
        Time.timeScale = 1f;
        // Desactivar el panel del canvas
        canvasPanel.SetActive(false);
    }
}

