using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    int currentLevel;

    GameObject spawnPoint;

    public GameObject activedCheckPoint;

    public GameObject notActiveCheckPoint;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        // check current scene - 3 karena build index level 4 adalah 7
        currentLevel = SceneManager.GetActiveScene().buildIndex - 3;

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
