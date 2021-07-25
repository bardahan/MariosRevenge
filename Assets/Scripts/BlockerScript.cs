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
            Vector3 dir = col.contacts[0].point - transform.position;
            // We then get the opposite (-Vector3) and normalize it
            dir = -dir.normalized;
            // And finally we add force in the direction of dir and multiply it by force. 
            // This will push back the player
            col.gameObject.GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }
}
