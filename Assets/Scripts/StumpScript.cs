using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("HERE!");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("HERE!2");
            Rigidbody rigidbody = collision.gameObject.GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.up * 20000);
        }
    }
}
