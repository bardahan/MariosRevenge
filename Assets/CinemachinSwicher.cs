using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinemachinSwicher : MonoBehaviour
{
    private Animator animator;

    public Image aimDot;

    //private bool isMainCameraActive = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        aimDot.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            aimDot.enabled = true;
            animator.Play("AimCamera");
        }
        else
        {
            aimDot.enabled = false;
            animator.Play("MainCamera");
        }
    }
}

