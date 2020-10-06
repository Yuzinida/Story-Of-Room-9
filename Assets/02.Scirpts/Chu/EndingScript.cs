using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScript : MonoBehaviour
{
    AudioSource clock,ending,bell;
    Room9AgText paper;
    private void Start()
    {
        clock = GameObject.Find("Clock").GetComponent<AudioSource>();
        bell = GameObject.Find("Bell").GetComponent<AudioSource>();
        ending = GameObject.Find("Ending").GetComponent<AudioSource>();
        paper = GameObject.Find("CanvasMaster").GetComponent<Room9AgText>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            clock.Stop();
            ending.Play();
            bell.Play();
            paper.ShowUI();

            this.gameObject.SetActive(false);
        }
    }
}
