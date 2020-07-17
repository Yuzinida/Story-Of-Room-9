using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_man : MonoBehaviour
{
    AudioSource left,right,all;
    bool isSound;

    private void Awake()
    {
        left = GameObject.Find("Left").GetComponent<AudioSource>();
        right = GameObject.Find("Right").GetComponent<AudioSource>();
        all = GameObject.Find("All").GetComponent<AudioSource>();
        StartCoroutine("IntroSoundMan");
    }
    private void Update()
    {
        if(isSound == true)
        {
            all.volume +=0.005f;
            left.volume +=0.005f;
            right.volume +=0.005f;
            if(all.volume >= 1.0f)
            {
                isSound = false;      
            }
        }
    }

    IEnumerator IntroSoundMan()
    {
        yield return new WaitForSeconds(22f);
        
        isSound = true;
        all.Play();
        left.Play();
        right.Play();
        

    }

}
