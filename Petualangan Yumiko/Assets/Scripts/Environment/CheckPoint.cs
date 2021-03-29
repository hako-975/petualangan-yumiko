using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameObject spawnPoint;

    bool hasEntered;

    public GameObject activedCheckPoint;

    public GameObject notActiveCheckPoint;

    private void Start()
    {
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
    }

    private void Update()
    {
        if (hasEntered)
        {
            activedCheckPoint.gameObject.SetActive(true);
            notActiveCheckPoint.gameObject.SetActive(false);
        }
        
        activedCheckPoint.gameObject.SetActive(false);
        notActiveCheckPoint.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawnPoint.transform.position = this.transform.position;
            hasEntered = true;
        }
    }
}
