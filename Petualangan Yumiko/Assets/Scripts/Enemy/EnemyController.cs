using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 5f;

    Transform target;
    NavMeshAgent agent;
    Animator animator;
    Vector3 firstPosition;

    PlayerStats playerStats;
    PlayerController player;
    bool beingHandled = false;
    public float delayAttack = 0f;
    public int damageAttack = 1;
    public float stopAttackDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        firstPosition = transform.position;

        playerStats = FindObjectOfType<PlayerStats>();
        player = FindObjectOfType<PlayerController>();

        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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

        if (playerStats.isDied)
        {
            agent.SetDestination(firstPosition);
        }

        if (distance <= agent.stoppingDistance + stopAttackDistance)
        {
            animator.SetBool("IsAttack", true);
            if ((playerStats.isInvisible == false) && animator.GetBool("IsAttack") && (playerStats.isDied == false))
            {
                if (!beingHandled)
                {
                    StartCoroutine(DelayAttack(delayAttack));
                }
            }
        }

        if (agent.velocity.magnitude >= 0.1f)
        {
            animator.SetBool("IsWalk", true);
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


    IEnumerator DelayAttack(float delay)
    {
        beingHandled = true;
        yield return new WaitForSeconds(delay);
        if (animator.GetBool("IsAttack"))
        {
            playerStats.TakeDamage(damageAttack);
            playerStats.isInvisible = true;
        }
        beingHandled = false;
    }

}
