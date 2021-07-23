using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyScript : MonoBehaviour
{
    public Transform[] ways;
    public Animator animator;
    public int speed;
    int index;
    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        speed = 1;
        isWalking = true;
    }

    // Update is called once per frame
    void Update()
    {
        Transform current = ways[index];
        Vector3 dir = current.position - transform.position;

        if (dir.magnitude < 1)
        {
            index = Random.Range(0, 3);
            wait();
        }

        if (isWalking)
        {
            SelfRotation(current);
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (Random.Range(0, 60 * 3) == 0)
        {
            Walk();
        }
    }

    void SelfRotation(Transform target)
    {
        transform.LookAt(target.position);
    }

    void Walk()
    {
        speed = 1;
        isWalking = true;
        animator.SetBool("isWaiting", false);
    }

    void wait()
    {
        isWalking = false;
        animator.SetBool("isWaiting", true);
    }
}
