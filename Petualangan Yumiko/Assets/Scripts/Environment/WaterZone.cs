using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZone : MonoBehaviour
{
    PlayerController player;

    public Transform spawnPoint;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<CharacterController>().transform.position = spawnPoint.transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            PlayerStats.instance.TakeDamage(1);
        }
    }
}
