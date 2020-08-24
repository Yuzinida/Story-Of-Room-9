using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockStart : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine("StoryStart");
    }

    IEnumerator StoryStart()
    {
        yield return new WaitForSeconds(10f); //쪽지읽는시간

        this.GetComponent<AudioSource>().Play();
        GameObject.Find("KnockWall").GetComponent<Knock>().NextScene();
    }
}
