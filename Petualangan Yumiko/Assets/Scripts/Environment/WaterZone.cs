using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterZone : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.instance.player.GetComponent<CharacterController>().enabled = false;
            PlayerManager.instance.player.GetComponent<CharacterController>().transform.position = spawnPoint.transform.position;
            PlayerManager.instance.player.GetComponent<CharacterController>().enabled = true;
            PlayerStats.instance.TakeDamage(1);
        }
    }
}
