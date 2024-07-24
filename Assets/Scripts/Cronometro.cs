using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    public Text tiempoText;
    private float tiempoPasado;

    void Update()
    {
        tiempoPasado += Time.deltaTime;

        int minutos = Mathf.FloorToInt(tiempoPasado / 60);
        int segundos = Mathf.FloorToInt(tiempoPasado % 60);

        tiempoText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}