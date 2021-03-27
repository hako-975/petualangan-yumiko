using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LadderScript : MonoBehaviour
{
    public Button ladderButton;
    public Button exitLadderButton;

    public GameObject jumpButton;
    public GameObject jumpButtonPressed;


    [HideInInspector]
    public bool isEntered;
    
    public float speedClimb = 8f;
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
        ladderButton.onClick.AddListener(OnLadderButtonClick);
        exitLadderButton.onClick.AddListener(OnExitLadderButtonClick);
        

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
            exitLadderButton.gameObject.SetActive(false);
            ladderButton.gameObject.SetActive(true);
        }

        if (other.gameObject.CompareTag("Player") && player.animator.GetBool("IsClimbing") == true)
        {
            exitLadderButton.gameObject.SetActive(true);
            ladderButton.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && player.animator.GetBool("IsClimbing") == false)
        {
            exitLadderButton.gameObject.SetActive(false);
            ladderButton.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Player") && player.animator.GetBool("IsClimbing") == true)
        {
            exitLadderButton.gameObject.SetActive(true);
            ladderButton.gameObject.SetActive(false);
        }
    }

    public void OnLadderButtonClick()
    {
        player.GetComponent<CharacterController>().enabled = false;

        player.animator.SetBool("IsRunning", false);
        player.animator.SetBool("IsClimbing", true);
        ladderButton.gameObject.SetActive(false);
        isEntered = true;
        exitLadderButton.gameObject.SetActive(true);
    }

    public void OnExitLadderButtonClick()
    {
        player.velocity.y = 1f;
        player.GetComponent<CharacterController>().enabled = true;
        player.animator.SetBool("IsClimbing", false);
        ladderButton.gameObject.SetActive(false);
        exitLadderButton.gameObject.SetActive(false);
        isEntered = false;
    }
}
