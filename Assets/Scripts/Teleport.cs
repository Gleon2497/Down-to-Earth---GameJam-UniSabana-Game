using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget; // El destino del teletransporte
    public GameObject player; // El jugador que se teletransportará
    private bool jugadorEnInterruptor = false; // Para verificar si el jugador está en la zona del interruptor
    private bool activado = false; // Para verificar si el teletransporte ya se ha activado

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnInterruptor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorEnInterruptor = false;
        }
    }

    void Update()
    {
        if (jugadorEnInterruptor && Input.GetMouseButtonDown(0) && !activado)
        {
            TeletransportarJugador();
            activado = true;
        }
    }

    private void TeletransportarJugador()
    {
        // Teletransporta al jugador a la posición del destino
        player.transform.position = teleportTarget.position;
    }
}
