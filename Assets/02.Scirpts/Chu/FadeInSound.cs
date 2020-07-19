using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInSound : MonoBehaviour
{
    AudioSource fadeSound;
    bool isSound = true;
    private void Start()
    {
        fadeSound = this.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(isSound == true)
        {
            fadeSound.volume += 0.003f;
            if(fadeSound.volume >= 0.5f)
            {
                isSound = false;      
                this.GetComponent<FadeInSound>().enabled = false;
            }
        }
    }
}
