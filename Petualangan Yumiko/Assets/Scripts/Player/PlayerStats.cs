using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    PlayerController player;

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

    void Start()
    {
        if (PlayerPrefsManager.instance.GetFirstPlaying() == 0)
        {
            currentLife = PlayerPrefsManager.instance.SetLife(3);
            PlayerPrefsManager.instance.SetFirstPlaying(1);
        }
        else
        {
            currentLife = PlayerPrefsManager.instance.GetLife();
        }

        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);

        lifeBar.SetTextLife(currentLife);

        player = GetComponent<PlayerController>();

        menuManager = FindObjectOfType<MenuManager>();
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
        DecreaseLife();
    }

    public void DecreaseLife()
    {
        // check current life if zero
        if (currentLife <= 0)
        {
            // load scene game over, to main menu
            PlayerPrefsManager.instance.SetLife(3);
            menuManager.MainMenu();
        }
        else
        {
            PlayerPrefsManager.instance.DecreaseLife();
            menuManager.Restart();
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
