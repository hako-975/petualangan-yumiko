using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathubScript : MonoBehaviour
{
    PlayerController player;
    GameObject spawnPoint;
    public GameObject body2;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (body2.activeSelf)
            {
                PlayerPrefsManager.instance.SetCurrentLevel(8);
                spawnPoint.transform.position = new Vector3(-105f, 13.5f, 170f);
                PlayerPrefsManager.instance.SetNextScene("Level 8");
            }
        }
    }
}
