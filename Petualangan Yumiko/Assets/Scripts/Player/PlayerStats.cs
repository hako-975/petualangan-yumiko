using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    PlayerController player;
    SpawnPoint spawnPoint;

    bool beingHandled = false;

    [HideInInspector]
    public bool isInvisible = false;

    [HideInInspector]
    public bool isDied = false;

    public int maxHealth = 4;
    public int currentHealth;
    public int currentLife;

    public float delayInvisible = 3f;

    public HealthBar healthBar;

    public LifeBar lifeBar;

    public MenuManager menuManager;

    public GameObject gameOverPanel;

    void Start()
    {
        spawnPoint = FindObjectOfType<SpawnPoint>();

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);

        player = GetComponent<PlayerController>();

        menuManager = FindObjectOfType<MenuManager>();
    }

    void Update()
    {
        currentLife = PlayerPrefsManager.instance.GetLife();
        lifeBar.SetTextLife(currentLife);

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
            player.transform.rotation = Quaternion.Euler(0f, player.currentTransformY, 0f);
        }
    }

    public void TakeDamage(int damage)
    {
        player.animator.SetBool("IsHit", true);

        isInvisible = true;

        currentHealth -= damage;
        
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            Died();
        }
    }

    public void Died()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.animator.SetBool("IsDied", true);
        isDied = true;
        StartCoroutine(DecreaseLife());
    }

    IEnumerator DecreaseLife()
    {
        yield return new WaitForSeconds(5f);
        // check current life if zero
        if (currentLife <= 0)
        {
            // game over panel
            gameOverPanel.SetActive(true);

            // if watch ads set life to 3 and not reset spawn point else to 1 and reset spawn point
            // if (watchads == true)
            // {

            // set life 3
            PlayerPrefsManager.instance.SetLife(3);

            // }
            // else
            // {

            // set life 1
            // PlayerPrefsManager.instance.SetLife(1);

            // reset spawn point
            spawnPoint.transform.position = new Vector3(0f, 0.25f, 0f);

            // }
        }
        else
        {
            PlayerPrefsManager.instance.DecreaseLife();
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
}
