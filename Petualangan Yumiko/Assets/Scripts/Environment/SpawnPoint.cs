using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    protected int currentLevel;

    private void Awake()
    {
        GameObject[] spawnPointObj = GameObject.FindGameObjectsWithTag("SpawnPoint");

        if (spawnPointObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        // check current scene
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel != PlayerPrefsManager.instance.GetCurrentLevel())
        {
            PlayerPrefsManager.instance.SetCurrentLevel(currentLevel);
            this.transform.position = new Vector3(0f, 0.25f, 0f);
        }
    }
}
