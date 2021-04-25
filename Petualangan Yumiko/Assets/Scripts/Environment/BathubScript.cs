using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BathubScript : MonoBehaviour
{
    int currentLevel;
    GameObject spawnPoint;
    public GameObject body2;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (body2.activeSelf)
            {
                currentLevel = SceneManager.GetActiveScene().buildIndex;
                if (currentLevel == 9)
                {
                    PlayerPrefsManager.instance.SetCurrentLevel(9);
                    spawnPoint.transform.position = new Vector3(115f, 37f, 465f);
                    PlayerPrefsManager.instance.SetNextScene("Level 9");
                }
                else
                {
                    PlayerPrefsManager.instance.SetCurrentLevel(8);
                    spawnPoint.transform.position = new Vector3(-105f, 13.5f, 170f);
                    PlayerPrefsManager.instance.SetNextScene("Level 8");
                }
            }
        }
    }
}
