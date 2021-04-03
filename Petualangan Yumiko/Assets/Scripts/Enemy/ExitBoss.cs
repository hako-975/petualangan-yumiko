using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBoss : MonoBehaviour
{
    public GameObject uIBoss;
    public AudioSource backSound;
    public GameObject gameMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<BossSpiderController>().lookRadius = 0f;
            uIBoss.gameObject.SetActive(false);
            backSound.gameObject.SetActive(false);
            gameMusic.gameObject.SetActive(true);
        }
    }
}
