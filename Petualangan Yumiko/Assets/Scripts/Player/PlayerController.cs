using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform cam;

    [HideInInspector]
    public CharacterController controller;

    [HideInInspector]
    public Vector3 velocity;

    [HideInInspector]
    public Animator animator;

    bool isGrounded;
    bool isClimbing;

    Transform groundCheck;

    float turnSmoothVelocity;

    public float gravity = -9.81f;
    public float groundDistance = 0.25f;
    public float jumpHeight = 2f;
    public float turnSmoothTime = 0.1f;
    public float movementSpeed = 4f;

    public Joystick joystick;
    public JoyButton jumpButton;

    public LayerMask groundMask;

    [HideInInspector]
    public float currentTransformY;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        groundCheck = GameObject.FindGameObjectWithTag("GroundCheck").transform;
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;

        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.transform.position.y < -100f)
        {
            controller.enabled = false;
            controller.transform.position = new Vector3(0f, 0.5f, 0f);
            controller.enabled = true;
            PlayerStats.instance.TakeDamage(1);
        }

        if (PlayerStats.instance.isDied == false)
        {
            currentTransformY = GetComponent<Transform>().transform.eulerAngles.y;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxisRaw("Horizontal") + joystick.Horizontal;
        float vertical = Input.GetAxisRaw("Vertical") + joystick.Vertical;

        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
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


        if ((Input.GetButtonDown("Jump") && isGrounded && !isClimbing) || (jumpButton.pressed && isGrounded && !isClimbing))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
