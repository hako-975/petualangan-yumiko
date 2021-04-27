using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    int currentLevel;

    CharacterController controller;

    GameObject cam;
    GameObject groundCheck;
    GameObject spawnPoint;

    float turnSmoothVelocity;

    [HideInInspector]
    public bool isGrounded;

    [HideInInspector]
    public bool isClimbing;

    private float canJump = 0f;

    [HideInInspector]
    public Vector3 velocity;

    [HideInInspector]
    public Animator animator;

    [HideInInspector]
    public float currentTransformY;

    public float gravity = -9.81f;
    public float groundDistance = 0.25f;
    public float jumpHeight = 2f;
    public float turnSmoothTime = 0.1f;
    public float movementSpeed = 4f;

    public Joystick joystick;
    public JoyButton jumpButton;

    public LayerMask groundMask;
    
    [HideInInspector]
    public Vector3 move;

    PlayerSFX playerSFX;

    PlayerStats playerStats;

    bool fall = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        playerStats = GetComponent<PlayerStats>();
        playerSFX = GetComponent<PlayerSFX>();

        groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        playerSFX.audioSpawn.Play();

        StartCoroutine(WaitPosition());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (fall == false)
        {
            if (velocity.y < -40f && playerStats.isDied == false)
            {
                playerSFX.audioFall.Play();
                fall = true;
            }
        }

        if (velocity.y >= -3f)
        {
            fall = false;
        }

        if (controller.transform.position.y < -200f)
        {
            controller.enabled = false;
            controller.transform.position = spawnPoint.transform.position;
            controller.enabled = true;
            playerStats.TakeDamage(1);
        }

        if (playerStats.isDied == false)
        {
            currentTransformY = GetComponent<Transform>().transform.eulerAngles.y;
        }

        isGrounded = Physics.CheckSphere(groundCheck.transform.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal") + joystick.Horizontal;
        float vertical = Input.GetAxisRaw("Vertical") + joystick.Vertical;

        move = new Vector3(horizontal, 0f, vertical).normalized;

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
        }

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isRunning = hasHorizontalInput || hasVerticalInput;
        
        // Animator
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsGrounded", isGrounded);
        isClimbing = animator.GetBool("IsClimbing");

        if (isClimbing)
        {
            velocity.y = -2f;
        }

        if ((Input.GetKey(KeyCode.Space) || jumpButton.pressed) && isGrounded && !isClimbing && playerStats.isDied == false && Time.time > canJump)
        {
            playerSFX.audioJump.Play();
            playerSFX.audioJump.volume = Random.Range(0.8f, 1f);
            playerSFX.audioJump.pitch = Random.Range(0.995f, 1.05f);

            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canJump = Time.time + 1f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    IEnumerator WaitPosition()
    {
        yield return new WaitForEndOfFrame();
        
        // check current scene karena build index level 4 adalah 4
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel != PlayerPrefsManager.instance.GetCurrentLevel() || currentLevel == 0)
        {
            if (PlayerPrefsManager.instance.GetComingSoon() > 0)
            {
                GetComponent<ChangeClothes>().enabled = true;
                GetComponent<ChangeMusic>().enabled = true;
                PlayerPrefsManager.instance.SetMusic(5f);
                spawnPoint.transform.position = Vector3.one * 2000f;
                PlayerPrefsManager.instance.SetComingSoon(0);
                PlayerPrefsManager.instance.SetCurrentLevel(0);
            }
            else
            {
                spawnPoint.transform.position = new Vector3(0f, 0.05f, 0f);
                PlayerPrefsManager.instance.SetCurrentLevel(currentLevel);
            }
        }

        controller.enabled = false;
        controller.transform.position = spawnPoint.transform.position;
        controller.enabled = true;
    }

}
