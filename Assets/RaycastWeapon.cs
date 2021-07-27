using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    public bool isFiring;
    public int fireRate = 5;
    public float damage = 2;
    private float fireTime;

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
        fireTime = 0.0f;
        FireBullet();
        
    }

    public void UpdateFiring(float daltaTime)
    {
        fireTime += daltaTime;
        float fireInterval = 1.0f / fireRate;
        while (fireTime >= 0.0f)
        {
            FireBullet();
            fireTime -= fireInterval;
        }
    }

    private void FireBullet()
    {
        gunFlash.Emit(1);
        ray.origin = raycastOrigin.position;
        ray.direction = raycastDest.position - raycastOrigin.position;


        if (Physics.Raycast(ray, out hitInfo))
        {
            hitEffect.transform.position = hitInfo.point;
            hitEffect.transform.forward = hitInfo.normal;
            hitEffect.Emit(1);

            BasicEnemyScript target = hitInfo.transform.GetComponent<BasicEnemyScript>();
            BouncerAgent target2 = hitInfo.transform.GetComponent<BouncerAgent>();
            BoxScript target3 = hitInfo.transform.GetComponent<BoxScript>();

            if (target != null)
            {
                target.TakeDamge(damage);
            }
            if (target2 != null)
            {
                target2.TakeDamge(damage);
            }
            if (target3 != null)
            {
                target3.Crack();
            }
        }
    }

    public void StopFiring()
    {
        isFiring = false;
    }
}
