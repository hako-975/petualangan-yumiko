using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointBoss : MonoBehaviour
{
    int currentLevel;

    GameObject spawnPoint;

    public GameObject ground;

    public GameObject activedCheckPoint;

    public GameObject notActiveCheckPoint;

    private void Start()
    {
        transform.position = new Vector3(Random.Range(ground.transform.position.x - 4f, ground.transform.position.x + 4f), ground.transform.position.y + 0.4f , Random.Range(ground.transform.position.z - 4f, ground.transform.position.z + 4f));

        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        // check current scene karena build index level 4 adalah 4
        currentLevel = SceneManager.GetActiveScene().buildIndex;

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
