using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigOptions : MonoBehaviour
{
    public Dropdown screenModeDropdown;
    public Dropdown resolutionDropdown;

    void Start()
    {
        // Añade listeners para los cambios en los Dropdowns
        screenModeDropdown.onValueChanged.AddListener(ChangeScreenMode);
        resolutionDropdown.onValueChanged.AddListener(ChangeResolution);

        // Inicializa los Dropdowns
        InitDropdowns();
    }

    // Inicializa los valores y opciones de los Dropdowns
    void InitDropdowns()
    {
        // Inicializa el Dropdown de modo de pantalla
        screenModeDropdown.ClearOptions();
        screenModeDropdown.AddOptions(new List<string> { "Pantalla Completa", "Modo Ventana" });
        if (Screen.fullScreen)
        {
            screenModeDropdown.value = 0; // Pantalla Completa
        }
        else
        {
            screenModeDropdown.value = 1; // Modo Ventana
        }

        // Inicializa el Dropdown de resoluciones
        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(new List<string> { "1920x1080", "1600x900", "1280x720" });
    }

    // Método para cambiar el modo de pantalla
    public void ChangeScreenMode(int index)
    {
        if (index == 0)
        {
            // Cambiar a pantalla completa
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            Screen.fullScreen = true;
        }
        else if (index == 1)
        {
            // Cambiar a modo ventana
            Screen.fullScreenMode = FullScreenMode.Windowed;
            Screen.fullScreen = false;
        }
    }

    // Método para cambiar la resolución
    public void ChangeResolution(int index)
    {
        string[] resolutions = { "1920x1080", "1600x900", "1280x720" };
        string[] resolution = resolutions[index].Split('x');
        int width = int.Parse(resolution[0]);
        int height = int.Parse(resolution[1]);
        Screen.SetResolution(width, height, Screen.fullScreen);
    }
}
