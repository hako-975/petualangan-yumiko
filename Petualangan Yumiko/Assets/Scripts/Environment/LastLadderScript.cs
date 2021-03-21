using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLadderScript : MonoBehaviour
{
    PlayerController player;

    [HideInInspector]
    public bool lastLadder;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void Update()
    {
        lastLadder = player.animator.GetBool("LastClimbing");
        if (player.animator.GetBool("LastClimbing"))
        {
            player.animator.speed = 1f;
            player.velocity = Vector3.up * 2f;
            StartCoroutine(LastMove());
            StartCoroutine(AfterLastMove());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.animator.SetBool("LastClimbing", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.animator.SetBool("LastClimbing", false);
        }
    }

    IEnumerator LastMove()
    {
        yield return new WaitForSeconds(2f);
        player.velocity = Vector3.forward;
    }

    IEnumerator AfterLastMove()
    {
        yield return new WaitForSeconds(2.5f);
        player.velocity = Vector3.zero;
    }
}
