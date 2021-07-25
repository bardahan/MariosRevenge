using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerScript : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        // force is how forcefully we will push the player away from the enemy.
        float force = 1000;

        // If the object we hit is the enemy
        if (col.gameObject.tag == "Player")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 moveDir = col.contacts[0].point - transform.position;
            gameObject.GetComponent<Rigidbody>().AddForce(moveDir * force);

            col.gameObject.GetComponent<PlayerHealthScript>().TakeDamege(20);
        }
    }
}
