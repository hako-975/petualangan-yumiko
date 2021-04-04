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

    bool isGrounded;
    bool isClimbing;

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

    PlayerStats playerStats;

    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        playerStats = GetComponent<PlayerStats>();

        groundCheck = GameObject.FindGameObjectWithTag("GroundCheck");
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        StartCoroutine(WaitPosition());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(WaitSetPosition());

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

        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;

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

        if ((Input.GetKey(KeyCode.Space) || jumpButton.pressed) && isGrounded && !isClimbing && Time.time > canJump)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            canJump = Time.time + 1f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    
    IEnumerator WaitPosition()
    {
        yield return new WaitForEndOfFrame();
        // set character to spawn point
        
        // check current scene - 3 karena build index level 4 adalah 7
        currentLevel = SceneManager.GetActiveScene().buildIndex - 3;
        
        if (currentLevel != PlayerPrefsManager.instance.GetCurrentLevel())
        {
            controller.enabled = false;
            controller.transform.position = spawnPoint.transform.position;
            controller.enabled = true;
            PlayerPrefsManager.instance.SetCurrentLevel(currentLevel);
        }
        else
        {
            controller.enabled = false;
            controller.transform.position = new Vector3(PlayerPrefsManager.instance.GetPositionX(), PlayerPrefsManager.instance.GetPositionY(), PlayerPrefsManager.instance.GetPositionZ());
            controller.enabled = true;
        }
    }

    IEnumerator WaitSetPosition()
    {
        yield return new WaitForSeconds(3f);
        PlayerPrefsManager.instance.SetPositionX(transform.position.x);
        PlayerPrefsManager.instance.SetPositionY(transform.position.y);
        PlayerPrefsManager.instance.SetPositionZ(transform.position.z);
    }

}
