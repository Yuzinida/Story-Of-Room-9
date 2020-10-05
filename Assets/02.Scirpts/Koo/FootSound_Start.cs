using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class FootSound_Start : MonoBehaviour
{

    public AudioClip[] ad; // 발소리 추가 해준다.
    public AudioSource audioSource;
    float timer;
    float waitingTime;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        waitingTime = 0.5f;
        timer = 0.0f;
    }


    void Update()
    {

        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            audioSource.clip = ad[Random.Range(0, 5)];
            audioSource.Play();
            timer = 0;
        }
        
        //Invoke("footSound()", 0.5f);
        
    }

    //public void footSound()
    //{
        
    //    audioSource.Play();
    //}
}
