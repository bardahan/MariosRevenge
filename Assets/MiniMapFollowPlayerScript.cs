using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollowPlayerScript : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 positionToLookAt;
        positionToLookAt.x = playerPos.x;
        positionToLookAt.y = 20.0f;
        positionToLookAt.z = playerPos.z;

        gameObject.transform.position = positionToLookAt;
    }
}
