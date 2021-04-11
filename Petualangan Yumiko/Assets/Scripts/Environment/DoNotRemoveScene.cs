using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotRemoveScene : MonoBehaviour
{
    GameObject spawnPoint;
    
    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefsManager.instance.SetCurrentLevel(-1);
            spawnPoint.transform.position = new Vector3(8000f, 8001f, 8000f);
            PlayerPrefsManager.instance.SetNextScene("Do not Remove Scene");
        }
    }
}
