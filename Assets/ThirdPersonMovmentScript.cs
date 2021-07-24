using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovmentScript : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6;
    public float turnSmoothTime = 0.1f;
    public float gravity = -9.81f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHight = 2;

    public Animator playerAnimator;

    float turnSmoothVelocity;
    private bool isMovmentPressed;
    private bool isRunPressed;
    private bool isJumpPressed;
    private bool isAimingPressed;

    int isWalkingHash;
    int isRunningHash;
    int isAimingHash;

    // Update is called once per frame
    void Update()
    {
        setKeyPressed();
        handelAnimation();

        float horisontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        isMovmentPressed = horisontal != 0 || vertical != 0;

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        velocity.y += gravity * Time.deltaTime;
        Vector3 direction = new Vector3(horisontal, 0f, vertical).normalized;
        controller.Move(velocity * Time.deltaTime);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            if (isRunPressed)
            {
                controller.Move(moveDir.normalized * speed * 2 * Time.deltaTime);

            }
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (isJumpPressed)
        {
            velocity.y += Mathf.Sqrt(jumpHight * -2f * gravity);
        }

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

    void Awake()
    {
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isAimingHash = Animator.StringToHash("isAiming");
    }

    void handelAnimation()
    {
        bool isWalking = playerAnimator.GetBool(isWalkingHash);
        bool isRunning = playerAnimator.GetBool(isRunningHash);
        //bool isAiming = playerAnimator.GetBool(isAimingHash);

        //if (isAimingPressed)
        //{
        //    playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("aim"), 1);
        //}
        //else
        //{
        //    playerAnimator.SetLayerWeight(playerAnimator.GetLayerIndex("aim"), 0);
        //}

        if (isMovmentPressed && !isWalking)
        {
            playerAnimator.SetBool(isWalkingHash, true);
        }
        else if (!isMovmentPressed && isWalking)
        {
            playerAnimator.SetBool(isWalkingHash, false);
        }

        if ((isMovmentPressed && isRunPressed) && !isRunning)
        {
            playerAnimator.SetBool(isRunningHash, true);
        }
        else if ((!isMovmentPressed || !isRunPressed) && isRunning)
        {
            playerAnimator.SetBool(isRunningHash, false);
        }
    }
}

