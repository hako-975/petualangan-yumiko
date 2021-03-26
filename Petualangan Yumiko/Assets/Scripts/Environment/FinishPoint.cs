using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [HideInInspector]
    public int nextSceneLoad;

    void Start()
    {
        // -1 sesuai urutan pada build index, level saat ini 1 dan build index nya 3 dan next level adalah level 2
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex - 1;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int levelAt = PlayerPrefsManager.instance.GetLevelAt();

            if (nextSceneLoad > levelAt)
            {
                PlayerPrefsManager.instance.SetLevelAt(nextSceneLoad);
            }

            PlayerPrefsManager.instance.SetNextScene("Level" + " " + nextSceneLoad);
        }
    }
}
