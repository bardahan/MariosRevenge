//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CameraFollowScript : MonoBehaviour
//{
//    public Transform targetObject;

//    public Vector3 cameraOffset;

//    public float smoothFactor = 0.5f;

//    void Start()
//    {
//        cameraOffset = transform.position - targetObject.transform.position;
//    }

//    void LateUpdate()
//    {
//        Vector3 newPosition = targetObject.transform.position + cameraOffset;
//        transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
//    }
//}
