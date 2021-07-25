using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour
{
    public Animator flagAnimator;
    public int nextSceaneNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Winning());
        }
    }

    private IEnumerator Winning()
    {
        flagAnimator.SetBool("isWon", true);

        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(nextSceaneNumber);
    }
}
