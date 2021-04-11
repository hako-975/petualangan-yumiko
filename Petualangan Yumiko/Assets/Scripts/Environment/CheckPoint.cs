using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    int currentLevel;

    GameObject spawnPoint;

    PlayerStats playerStats;

    public GameObject activedCheckPoint;

    public GameObject notActiveCheckPoint;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        playerStats = FindObjectOfType<PlayerStats>();

        // check current scene - 4 karena build index level 4 adalah 8
        currentLevel = SceneManager.GetActiveScene().buildIndex - 4;

        if (currentLevel != PlayerPrefsManager.instance.GetCurrentLevel())
        {
            spawnPoint.transform.position = new Vector3(0f, 0.5f, 0f);
        }
    }
            
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnPoint.transform.position = this.transform.position;
            
            activedCheckPoint.gameObject.SetActive(true); 
            notActiveCheckPoint.gameObject.SetActive(false);
        }
    }
}
