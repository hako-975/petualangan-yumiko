using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBoss : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<BossSpiderController>().lookRadius = 0f;
        }
    }
}
