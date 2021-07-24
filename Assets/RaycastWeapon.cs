using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    public bool isFiring;
    public Transform raycastOrigin;
    public Transform raycastDest;

    public ParticleSystem gunFlash;
    public ParticleSystem hitEffect;

    Ray ray;
    RaycastHit hitInfo;
    public static RaycastHit lastHitInfo;

    public void StartFiring()
    {
        isFiring = true;
        gunFlash.Emit(1);
        ray.origin = raycastOrigin.position;
        ray.direction = raycastDest.position - raycastOrigin.position;
        if (Physics.Raycast(ray, out hitInfo))
        {
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
