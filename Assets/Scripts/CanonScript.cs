using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    public Transform player;
    public GameObject bullet;
    bool isFire;
    // Start is called before the first frame update
    void Start()
    {
        isFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lTargetDir = player.position - transform.position;
        lTargetDir.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lTargetDir), Time.time * 1);

        if (!isFire)
        {
            isFire = true;
            StartCoroutine(Fire());
        }
    }

    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(1);

        isFire = false;

        GameObject newIns = Instantiate(bullet, transform.position, transform.rotation);
        newIns.transform.LookAt(player);
        Rigidbody rigidbody = newIns.GetComponent<Rigidbody>();
        Vector3 forceDirection = (player.transform.position - newIns.transform.position).normalized;
        rigidbody.AddForce(Vector3.up * 200);
        rigidbody.AddForce(forceDirection * 1000);
    }
}
