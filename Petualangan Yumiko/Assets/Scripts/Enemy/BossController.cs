using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public int healthPoint = 3;
    public int damageAttack = 1;
    public float lookRadius = 1000f;

    bool beingHandled = false;
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    Vector3 firstPosition;

    PlayerStats playerStats;
    PlayerController player;
    HealthBarBoss healthBarBoss;

    [HideInInspector]
    public bool isDied = false;

    BossController bossController;

    float delaySoundWalk = 0.15f;

    bool handledWalk;

    public float defaultSpeed = 8f;
    public float defaultAcceleration = 450f;

    public AudioSource audioWalk;
    public AudioSource audioAttack;
    public AudioSource audioGetHit;

    // Start is called before the first frame update
    void Start()
    {
        firstPosition = transform.position;
        healthBarBoss = FindObjectOfType<HealthBarBoss>();
        healthBarBoss.SetMaxHealth(healthPoint);
        playerStats = FindObjectOfType<PlayerStats>();
        player = FindObjectOfType<PlayerController>();
        bossController = GetComponent<BossController>();
        
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        delaySoundWalk = 0.25f;

        if (playerStats.isDied)
        {
            lookRadius = 0f;
            playerStats.spawnPoint.transform.position = new Vector3(0f, 0.05f, 0f);
        }
        
        healthBarBoss.SetHealth(healthPoint);

        animator.SetBool("IsWalk", false);
        animator.SetBool("IsAttack", false);


        float distance = Vector3.Distance(target.position, transform.position);
        
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
        else
        {
            agent.SetDestination(firstPosition);
        }

        if (distance >= 50f)
        {
            agent.speed = 75f;
            agent.acceleration = 1000f;
            FaceTarget();
        }
        else if (distance < 50f)
        {
            agent.speed = defaultSpeed;
            agent.acceleration = defaultAcceleration;
            FaceTarget();
        }

        if (playerStats.isDied)
        {
            agent.SetDestination(firstPosition);
        }

        if (distance <= agent.stoppingDistance)
        {
            animator.SetBool("IsAttack", true);
            if ((playerStats.isInvisible == false) && animator.GetBool("IsAttack") && (playerStats.isDied == false))
            {
                if (!beingHandled)
                {
                    StartCoroutine(DelayBoss());
                }
                
                audioAttack.Play();
                audioAttack.volume = Random.Range(0.8f, 1f);
                audioAttack.pitch = Random.Range(0.8f, 1f);

                playerStats.TakeDamage(damageAttack);
                playerStats.isInvisible = true;
            }
        }

        if (agent.velocity.magnitude >= 0.1f)
        {
            if (!handledWalk && animator.GetBool("IsAttack") == false)
            {
                StartCoroutine(DelaySoundWalk(delaySoundWalk));
            }

            animator.SetBool("IsWalk", true);
        }

        if (isDied)
        {
            animator.SetBool("IsDied", true);
            agent.enabled = false;
            bossController.enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void TakeDamage(int damage)
    {
        audioGetHit.Play();
        audioGetHit.pitch = Random.Range(0.5f, 1f);

        healthPoint -= damage;
        StartCoroutine(DelayBoss());
        if (healthPoint <= 0)
        {
            IsDied();
        }
    }

    public void IsDied()
    {
        animator.SetBool("IsDied", true);
        lookRadius = 0f;
        isDied = true;
    }


    IEnumerator DelayBoss()
    {
        beingHandled = true;
        lookRadius = 0f;
        yield return new WaitForSeconds(3f);
        lookRadius = 1000f;
        beingHandled = false;
    }

    IEnumerator DelaySoundWalk(float delay)
    {
        handledWalk = true;
        yield return new WaitForSeconds(delay);
        audioWalk.Play();
        audioWalk.volume = Random.Range(0.8f, 1f);
        audioWalk.pitch = Random.Range(0.8f, 1f);
        handledWalk = false;
    }
}
