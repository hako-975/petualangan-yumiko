using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredBoss : MonoBehaviour
{
    BossSpiderController bossSpider;
    private void Start()
    {
        bossSpider = FindObjectOfType<BossSpiderController>();
        bossSpider.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bossSpider.gameObject.SetActive(true);
        }
    }
}
