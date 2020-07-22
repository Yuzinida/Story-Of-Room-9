using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUI : MonoBehaviour
{
    // Transform target;

    // private void Start()
    // {
    //     target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    // }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            GameObject.Find("KnockWall").GetComponent<Knock>().NextScene();
            GameObject.Find("Touch_Letter").transform.GetChild(1).gameObject.SetActive(true);
            // GameObject.Find("Touch_Letter").transform.GetChild(1).transform.LookAt(target);
            this.gameObject.SetActive(false);
        }
    }
}
