using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanzaiScript : MonoBehaviour
{
    bool initialized;
    // Start is called before the first frame update
    void Start()
    {
        initialized = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }

        if (!initialized)
        {
            initialized = true;
            StartCoroutine(DestroySelf());
        }
    }

    private IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthScript>().TakeDamege(5);
        }
    }
}
