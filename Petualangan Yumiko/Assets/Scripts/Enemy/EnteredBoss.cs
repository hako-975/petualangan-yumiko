using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteredBoss : MonoBehaviour
{
    BossController bossController;
    public GameObject uIBoss;
    public AudioSource backSound;
    GameObject gameMusic;
    public bool setActive = false;

    private void Start()
    {
        bossController = FindObjectOfType<BossController>();
        gameMusic = GameObject.FindGameObjectWithTag("GameMusic");

        if (setActive == false)
        {
            bossController.gameObject.SetActive(false);
            uIBoss.gameObject.SetActive(false);
            backSound.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bossController.gameObject.SetActive(true);
            uIBoss.gameObject.SetActive(true);
            backSound.gameObject.SetActive(true);
            gameMusic.gameObject.SetActive(false);
        }
    }
}
