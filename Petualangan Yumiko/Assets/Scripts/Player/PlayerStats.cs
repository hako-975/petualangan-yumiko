using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region Singleton
    public static PlayerStats instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    PlayerController player;

    bool beingHandled = false;

    [HideInInspector]
    public bool isInvisible = false;

    [HideInInspector]
    public bool isDied = false;

    public int maxHealth = 4;
    public int currentHealth;

    public float delayInvisible = 3f;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;

        player = PlayerManager.instance.player;
        healthBar.SetMaxHealth(maxHealth);
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
    }

    IEnumerator DelayInvisible(float delay)
    {
        beingHandled = true;
        yield return new WaitForSeconds(delay);
        isInvisible = false;
        beingHandled = false;
    }
}
