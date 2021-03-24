using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public Transform spawnPoint;

    PlayerStats playerStats;

    PlayerController player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<CharacterController>().transform.position = spawnPoint.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            playerStats.TakeDamage(1);
        }
    }
}
