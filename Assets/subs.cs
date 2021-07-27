using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class subs : MonoBehaviour
{
    public GameObject textBox;

    public bool end = false;

    private void Start()
    {
        StartCoroutine(TheSequence());
    }

    private IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(1);
        textBox.GetComponent<Text>().text = "Mario: Honey i'm home!";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "Mario: Where are you??";
        yield return new WaitForSeconds(2);
        textBox.GetComponent<Text>().text = "Women From the bedroom: Hoo, yes Luigi!!";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "Mario: Princess Peach? Is that you??";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "Man voice From the bedroom: Peach you are amaizing";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "Mario: Luigi!!! You are sleeping with my girlfrind??!?!?!";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "Luigi: Hoo, Mario I can explain!";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "Mario: Peach you told me you are doing yoga today! IS THIS YOUR YOGA CLASS???";
        yield return new WaitForSeconds(4);
        textBox.GetComponent<Text>().text = "Peach: I can explain!";
        yield return new WaitForSeconds(3);
        textBox.GetComponent<Text>().text = "Mario: No need for explanation... Luigi! I WILL <color=#ff0000ff>Revenge</color>";
        end = true;

    }

    private void Update()
    {
        if (end)
        {
            SceneManager.LoadScene(2);
        }
    }
}
