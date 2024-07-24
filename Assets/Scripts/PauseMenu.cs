using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject configMenu;
    public GameObject controlsMenu;

    public KeyCode pauseKey;

    public static bool isPaused;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        configMenu.SetActive(false);
        controlsMenu.SetActive(false);
        Time.timeScale = 1f;

        if (EventSystem.current == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<EventSystem>();
            eventSystem.AddComponent<StandaloneInputModule>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        configMenu.SetActive(false);
        controlsMenu.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        configMenu.SetActive(false);
        controlsMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToConfigMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        configMenu.SetActive(true);
        controlsMenu.SetActive(false);
        isPaused = true;
    }

    public void GoToControlsMenu()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        configMenu.SetActive(false);
        controlsMenu.SetActive(true);
        isPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        // Esto es útil solo para el editor de Unity, para verificar que funciona la salida
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
//KeyCode.Escape