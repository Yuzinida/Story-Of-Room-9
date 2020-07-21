using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
     AudioSource audioSource;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        Debug.Log("11111");
    }
}
