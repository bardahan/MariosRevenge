using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyBoundryScript : MonoBehaviour
{
    public GameObject connectedEnemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
        }
    }
}
