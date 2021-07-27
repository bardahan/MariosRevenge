using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHairTargetScript : MonoBehaviour
{
    Camera mainCam;
    Ray ray;
    RaycastHit hitInfo;

    public Image amingDot;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = mainCam.transform.position;
        ray.direction = amingDot.transform.position;
        if (Physics.Raycast(ray, out hitInfo))
        {
            transform.position = hitInfo.point;
            amingDot.transform.TransformDirection(hitInfo.point);
        }
        else
        {
            transform.position = ray.origin + ray.direction * 10000.0f;
        }
    }
}
