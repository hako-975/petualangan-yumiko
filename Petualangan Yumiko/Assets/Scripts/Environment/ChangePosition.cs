using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    PlayerController player;
    public Vector3 newPosition;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<CharacterController>().transform.position = newPosition;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
