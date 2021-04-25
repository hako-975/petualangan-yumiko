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

    AudioSource audioCheckPointIn;

    private void Start()
    {
        audioCheckPointIn = GetComponent<AudioSource>();

        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        // check current scene karena build index level 4 adalah 4
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel != PlayerPrefsManager.instance.GetCurrentLevel())
        {
            spawnPoint.transform.position = new Vector3(0f, 0.05f, 0f);
        }
    }
            
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (activedCheckPoint.gameObject.activeSelf == false)
            {
                audioCheckPointIn.Play();
            }

            spawnPoint.transform.position = this.transform.position;
            
            activedCheckPoint.gameObject.SetActive(true); 
            notActiveCheckPoint.gameObject.SetActive(false);
        }
    }
}
