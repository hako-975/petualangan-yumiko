using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredBoss : MonoBehaviour
{
    BossSpiderController bossSpider;
    public GameObject uIBoss;
    public AudioSource backSound;
    public GameObject gameMusic;

    private void Start()
    {
        bossSpider = FindObjectOfType<BossSpiderController>();

        bossSpider.gameObject.SetActive(false);
        uIBoss.gameObject.SetActive(false);
        backSound.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bossSpider.gameObject.SetActive(true);
            uIBoss.gameObject.SetActive(true);
            backSound.gameObject.SetActive(true);
            gameMusic.gameObject.SetActive(false);
        }
    }
}
