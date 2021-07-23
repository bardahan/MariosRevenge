using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationAndMovementController : MonoBehaviour
{
    KeyInput playerInput;
    CharacterController characterController;
    Animator animator;

    int isWalkingHash;
    int isRunningHash;
    int isAimingHash;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovmentPressed;
    bool isRunPressed;
    bool isAimingPressed;

    public float rotationFactorPerFrame = 10.0f;
    public float runMultiplier = 3.0f;
    public float walkMultiplier = 2.0f;

    void Awake()
    {
        playerInput = new KeyInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isAimingHash = Animator.StringToHash("isAiming");

        playerInput.CharicterControls.Move.started += onMovementInput;
        playerInput.CharicterControls.Move.canceled += onMovementInput;
        playerInput.CharicterControls.Move.performed += onMovementInput;
        playerInput.CharicterControls.Run.started += onRun;
        playerInput.CharicterControls.Run.canceled += onRun;
        playerInput.CharicterControls.Aim.started += onAim;
        playerInput.CharicterControls.Aim.canceled += onAim;
    }

    void onAim(InputAction.CallbackContext context)
    {
        isAimingPressed = context.ReadValueAsButton();
    }

    void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }


    void handleRotation()
    {
        Vector3 positionToLookAt;
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;

        if (isMovmentPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }

    }

    void onMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x * walkMultiplier;
        currentMovement.z = currentMovementInput.y * walkMultiplier;
        currentRunMovement.x = currentMovementInput.x * runMultiplier;
        currentRunMovement.z = currentMovementInput.y * runMultiplier;
        isMovmentPressed = currentMovement.x != 0 || currentMovement.z != 0;
    }

    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            float groundedGravity = -.005f;
            currentMovement.y = groundedGravity;
            currentRunMovement.y = groundedGravity;
        }
        else
        {
            float gravity = -9.8f;
            currentMovement.y = gravity;
            currentRunMovement.y = gravity;
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

    // Update is called once per frame
    void Update()
    {
        handleGravity();
        handleRotation();
        handelAnimation();

        if (isRunPressed)
        {
            characterController.Move(currentRunMovement * Time.deltaTime);
        }
        else
        {
            characterController.Move(currentMovement * Time.deltaTime);
        }
    }

    void OnEnable()
    {
        playerInput.CharicterControls.Enable();
    }

    void OnDisable()
    {
        playerInput.CharicterControls.Disable();
    }
}
