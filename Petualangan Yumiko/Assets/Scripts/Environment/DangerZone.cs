using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    Transform spawnPoint;

    PlayerStats playerStats;

    PlayerController player;

    CinemachineFreeLook thirdPersonCamera;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        playerStats = FindObjectOfType<PlayerStats>();
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform;
        thirdPersonCamera = FindObjectOfType<CinemachineFreeLook>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<CharacterController>().transform.position = spawnPoint.transform.position;
            player.GetComponent<CharacterController>().transform.rotation = Quaternion.identity;
            player.GetComponent<CharacterController>().enabled = true;
            thirdPersonCamera.enabled = false;
            thirdPersonCamera.m_YAxis.Value = 0.5f;
            thirdPersonCamera.m_XAxis.Value = 0f;
            thirdPersonCamera.enabled = true;
            playerStats.TakeDamage(1);
        }
    }
}
