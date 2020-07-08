using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knock : MonoBehaviour
{
    AudioSource knockWall;
    private void Awake()
    {
        
            knockWall = this.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand") ){
            knockWall.Play();
            print("녹");
        }
    }
}
