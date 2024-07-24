using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void SceneChanger(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        // Cierra la aplicaci�n si est� ejecut�ndose en una plataforma donde se puede cerrar
        Application.Quit();

        // Esto es �til solo para el editor de Unity, para verificar que funciona la salida
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
