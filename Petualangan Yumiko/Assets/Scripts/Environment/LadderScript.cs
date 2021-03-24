using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public GameObject ladderButton;
    public GameObject exitLadderButton;
    public GameObject jumpButton;
    public GameObject jumpButtonPressed;


    [HideInInspector]
    public bool isEntered;
    
    public float speedClimb = 2f;
    public float lengthLadder = 8f;

    float maxPosition;
    float minPosition;

    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (player.animator.GetBool("IsClimbing"))
        {
            jumpButtonPressed.SetActive(false);
            jumpButton.SetActive(false);
        }
        else
        {
            jumpButtonPressed.SetActive(true);
            jumpButton.SetActive(true);
        }

        maxPosition = transform.position.y + lengthLadder;
        minPosition = transform.position.y;

        if (isEntered)
        {
            player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            player.animator.speed = 0f;
        }
        else
        {
            player.animator.speed = 1f;
        }

        float vertical = Input.GetAxisRaw("Vertical") + player.joystick.Vertical;

        if (isEntered && vertical > 0f && player.transform.position.y < maxPosition)
        {
            player.transform.position += Vector3.up * (speedClimb / 100f);
            player.animator.SetFloat("Speed", 1f);
            player.animator.speed = 1f;
        }

        if (isEntered && vertical < 0f && player.transform.position.y > minPosition)
        {
            player.transform.position += Vector3.down * (speedClimb / 100f);
            player.animator.SetFloat("Speed", -1f);
            player.animator.speed = 1f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Player") && player.animator.GetBool("IsClimbing") == false)
        {
            exitLadderButton.SetActive(false);
            ladderButton.SetActive(true);
        }

        if (other.gameObject.CompareTag("Player") && player.animator.GetBool("IsClimbing") == true)
        {
            exitLadderButton.SetActive(true);
            ladderButton.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && player.animator.GetBool("IsClimbing") == false)
        {
            exitLadderButton.SetActive(false);
            ladderButton.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player") && player.animator.GetBool("IsClimbing") == true)
        {
            exitLadderButton.SetActive(true);
            ladderButton.SetActive(false);
        }
    }

    public void OnLadderButtonClick()
    {
        #pragma warning disable 30842
        player.GetComponent<CharacterController>().enabled = false;
        #pragma warning disable 30842

        player.animator.SetBool("IsRunning", false);
        player.animator.SetBool("IsClimbing", true);
        ladderButton.SetActive(false);
        isEntered = true;
        exitLadderButton.SetActive(true);
    }

    public void OnExitLadderButtonClick()
    {
        player.velocity.y = 1f;
        player.GetComponent<CharacterController>().enabled = true;
        player.animator.SetBool("IsClimbing", false);
        ladderButton.SetActive(false);
        exitLadderButton.SetActive(false);
        isEntered = false;
    }
}
