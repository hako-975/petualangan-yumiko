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

    [HideInInspector]
    public bool isInvisible = false;

    [HideInInspector]
    public bool isDied = false;

    public int maxHealth = 4;
    public int currentHealth;

    public float delayInvisible = 3f;

    public HealthBar healthBar;

    [HideInInspector]
    public Animator animator;

    PlayerController player;

    bool beingHandled = false;



    private void Start()
    {
        currentHealth = maxHealth;

        animator = GetComponentInChildren<Animator>();
        player = GetComponent<PlayerController>();
     
        healthBar.SetMaxHealth(maxHealth);
    }
    

    void Update()
    {
        if (isInvisible)
        {
            animator.SetBool("IsHit", false);

            if (!beingHandled)
            {
                StartCoroutine(DelayInvisible(delayInvisible));
            }
        }

        if (animator.GetBool("IsDied"))
        {
            player.transform.rotation = Quaternion.Euler(0f, player.currentTransformY, 0f);
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetBool("IsHit", true);

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
        animator.SetBool("IsDied", true);
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
