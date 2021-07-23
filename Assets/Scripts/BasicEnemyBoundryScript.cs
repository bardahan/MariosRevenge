using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBoundryScript : MonoBehaviour
{
    public BasicEnemyScript connectedEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            connectedEnemy.StartAttack(other.gameObject.transform);
        }
    }
}
