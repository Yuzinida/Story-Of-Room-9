using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStart : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("BackToStart");
    }

    IEnumerator BackToStart()
    {
        yield return new WaitForSeconds(50.5f);
        SceneManager.LoadScene(0);
    }
}
