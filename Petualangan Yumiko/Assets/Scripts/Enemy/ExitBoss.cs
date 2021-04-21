using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBoss : MonoBehaviour
{
    public GameObject uIBoss;
    public GameObject enteredBoss;
    public AudioSource backSound;
    GameObject gameMusic;
    private void Start()
    {
        gameMusic = GameObject.FindGameObjectWithTag("GameMusic");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<BossController>().lookRadius = 0f;
            uIBoss.gameObject.SetActive(false);
            backSound.gameObject.SetActive(false);
            gameMusic.gameObject.SetActive(true);
            enteredBoss.gameObject.SetActive(false);
        }
    }
}
