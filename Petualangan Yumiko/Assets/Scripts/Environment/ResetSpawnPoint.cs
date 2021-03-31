using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetSpawnPoint : MonoBehaviour
{
    GameObject spawnPoint;
    int currentLevel;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        // do not change PlayerPrefs.GetInt("CurrentLevel")
        // check current scene - 2 karena build index level 4 adalah 6
        currentLevel = SceneManager.GetActiveScene().buildIndex - 2;

        if (currentLevel != PlayerPrefs.GetInt("CurrentLevel"))
        {
            spawnPoint.transform.position = new Vector3(0f, 0.25f, 0f);
            PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        }
    }

}
