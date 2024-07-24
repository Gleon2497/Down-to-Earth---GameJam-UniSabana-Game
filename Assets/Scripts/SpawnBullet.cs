using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{
    private GameObject player;
    public string respawnPointName = "RespawnPoint3"; // Nombre del respawn point
    public string jugador = "Player"; // Nombre del respawn point
    private GameObject respawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        // Busca el objeto respawnPoint por nombre
        respawnPoint = GameObject.Find(respawnPointName);
        player = GameObject.Find(jugador);
        if (respawnPoint == null)
        {
            Debug.LogError("Respawn point no encontrado: " + respawnPointName);
        }
        if (player == null)
        {
            Debug.LogError("Jugador no encontrado: " + respawnPointName);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (respawnPoint != null)
            {
                player.transform.position = respawnPoint.transform.position;
            }
            else
            {
                Debug.LogError("Respawn point no asignado.");
            }
        }
    }
}