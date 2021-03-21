using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical") + player.joystick.Vertical;

        if (player.animator.GetBool("IsClimbing"))
        {
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
            if (hasVerticalInput)
            {
                player.animator.speed = 1f;
                player.velocity = Vector3.up * 2f;
            }
            else
            {
                player.animator.speed = 0f;
            }
        }
        else if (player.animator.GetBool("IsClimbing") == false)
        {
            player.animator.speed = 1f;
        }
    
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.animator.SetBool("IsClimbing", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.animator.SetBool("IsClimbing", false);
        }
    }
}
