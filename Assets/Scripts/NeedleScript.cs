using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleScript : MonoBehaviour
{
    float speed = 3;
    bool isInitialized = false;
    public Transform start, end;

    public void Initialize()
    {
        transform.position = start.position;
        transform.LookAt(end);
        isInitialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInitialized)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if ((transform.position - end.position).magnitude < 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
