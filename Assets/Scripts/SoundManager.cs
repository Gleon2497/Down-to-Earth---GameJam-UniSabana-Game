using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public Slider volumeSlider; // Referencia al slider

    void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Inicializa el slider según el volumen actual
        volumeSlider.value = AudioListener.volume;

        // Añade un listener para cuando cambie el valor del slider
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    // Método para cambiar el volumen
    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
