using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSound : MonoBehaviour
{
     AudioSource audioSource;
     bool once = true;
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(once)
        {
            once = false;
            audioSource.Play();
            StartCoroutine("DelaySound");
        }

        
    }
    
    IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(0.5f);
        once = true;
    }
}
