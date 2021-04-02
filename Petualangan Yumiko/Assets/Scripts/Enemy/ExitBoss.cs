using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBoss : MonoBehaviour
{
    BossSpiderController bossSpider;
    private void Start()
    {
        bossSpider = FindObjectOfType<BossSpiderController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bossSpider.lookRadius = 0f;
        }
    }
}
