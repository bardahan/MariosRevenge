using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    public bool isFiring;
    public Transform raycastOrigin;
    public Transform raycastDest;

    Ray ray;
    RaycastHit hitInfo;
    public static RaycastHit lastHitInfo;

    public void StartFiring()
    {
        isFiring = true;
        ray.origin = raycastOrigin.position;
        ray.direction = raycastDest.position - raycastOrigin.position;
        if (Physics.Raycast(ray, out hitInfo))
        {
            lastHitInfo = hitInfo;
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
