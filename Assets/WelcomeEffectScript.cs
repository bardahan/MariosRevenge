using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeEffectScript : MonoBehaviour
{
    public Text text;
    public float fadeSpeed = 5;
    public bool enterance = false;

    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    fadeText();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") text.enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player") text.enabled = false;
    }

    //private void fadeText()
    //{
    //    if (enterance)
    //    {
    //        text.color = Color.Lerp(text.color, Color.white, fadeSpeed * Time.deltaTime);
    //    }
    //    else
    //    {
    //        text.color = Color.Lerp(text.color, Color.clear, fadeSpeed * Time.deltaTime); 
    //    }
            
    //}

}
