using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    Animator animator;
    bool isMovmentPressed;
    bool isRunPressed;
    bool isAimingPressed;
    bool isJumpPressed;

    int isWalkingHash;
    int isRunningHash;
    int isAimingHash;

    // Update is called once per frame
    void Update()
    {
        setKeyPressed();
        handelAnimation();
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (isJumpPressed)
        {
            velocity.y += Mathf.Sqrt(jumpHight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        isMovmentPressed = x != 0 || z != 0;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isAimingHash = Animator.StringToHash("isAiming");
    }

    void setKeyPressed()
    {

        if (Input.GetButton("Run"))
        {
            isRunPressed = true;
        }
        else
        {
            isRunPressed = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            isJumpPressed = true;
        }
        else
        {
            isJumpPressed = false;
        }
        if (Input.GetMouseButton(1))
        {
            isAimingPressed = true;
        }
        else
        {
            isAimingPressed = false;
        }
    }

    void handelAnimation()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool isAiming = animator.GetBool(isAimingHash);

        if (isAimingPressed)
        {
            animator.SetLayerWeight(animator.GetLayerIndex("aim"), 1);
        }
        else
        {
            animator.SetLayerWeight(animator.GetLayerIndex("aim"), 0);
        }

        if (isMovmentPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if (!isMovmentPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if ((isMovmentPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if ((!isMovmentPressed || !isRunPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
