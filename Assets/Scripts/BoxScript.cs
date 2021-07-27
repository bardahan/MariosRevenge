using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public GameObject crackedBox;
    public void Crack()
    {
        Instantiate(crackedBox, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
