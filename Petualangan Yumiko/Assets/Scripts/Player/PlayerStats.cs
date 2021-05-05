using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    PlayerController player;
    [HideInInspector]
    public GameObject spawnPoint;

    bool beingHandled = false;

    [HideInInspector]
    public bool isInvisible = false;

    [HideInInspector]
    public bool isDied = false;

    public float delayInvisible = 3f;

    MenuManager menuManager;

    public GameObject gameOverPanel;
    
    public GameObject adsPanel;

    PlayerSFX playerSFX;

    void Start()
    {
        player = GetComponent<PlayerController>();

        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        menuManager = FindObjectOfType<MenuManager>();

        playerSFX = GetComponent<PlayerSFX>();

        if (PlayerPrefsManager.instance.GetHealth() <= 0)
        {
            PlayerPrefsManager.instance.SetHealth(4);
            PlayerPrefsManager.instance.SetLife(PlayerPrefsManager.instance.GetLife() - 1);
        }

        if (PlayerPrefsManager.instance.GetLife() < 0)
        {
            PlayerPrefsManager.instance.SetLife(0);
        }
    }

    void Update()
    {
        if (isInvisible)
        {
            player.animator.SetBool("IsHit", false);

            if (!beingHandled)
            {
                StartCoroutine(DelayInvisible(delayInvisible));
            }
        }

        if (player.animator.GetBool("IsDied"))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.rotation = Quaternion.Euler(0f, player.currentTransformY, 0f);
        }

        if (PlayerPrefsManager.instance.GetHealth() <= 0 && isDied == false)
        {
            Died();
        }
    }

    public void TakeDamage(int damage)
    {
        player.animator.SetBool("IsHit", true);
        isInvisible = true;
        int currentHealth = PlayerPrefsManager.instance.GetHealth();
        currentHealth -= damage;
        PlayerPrefsManager.instance.SetHealth(currentHealth);
        playerSFX.audioGetHit.Play();
    }

    public void Died()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.animator.SetBool("IsDied", true);
        isDied = true;
        StartCoroutine(DelaySFXDied());
        StartCoroutine(DecreaseLife());
    }

    IEnumerator DecreaseLife()
    {
        yield return new WaitForSeconds(5f);
        // check current life if zero
        if (PlayerPrefsManager.instance.GetLife() <= 0)
        {
            // set current health 4
            PlayerPrefsManager.instance.SetHealth(4);

            // game over panel
            gameOverPanel.SetActive(true);
            adsPanel.SetActive(true);

            // reset spawn point
            spawnPoint.transform.position = new Vector3(0f, 0.05f, 0f);
        }
        else
        {
            PlayerPrefsManager.instance.DecreaseLife();
            PlayerPrefsManager.instance.SetHealth(4);
            // true is restart
            // false is die
            menuManager.Restart(false);
        }
    }

    IEnumerator DelayInvisible(float delay)
    {
        beingHandled = true;
        yield return new WaitForSeconds(delay);
        isInvisible = false;
        beingHandled = false;
    }

    IEnumerator DelaySFXDied()
    {
        yield return new WaitForSeconds(1f);
        playerSFX.audioDied.Play();
    }
}
