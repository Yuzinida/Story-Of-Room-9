﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    float hand = 0;
    bool isSoundOut = false;
    AudioSource left,right,all;

    // Start is called before the first frame update
    void Start()
    {
       left = GameObject.Find("Left").GetComponent<AudioSource>();
       right = GameObject.Find("Right").GetComponent<AudioSource>();
       all = GameObject.Find("All").GetComponent<AudioSource>();

    }

    private void OnTriggerEnter(Collider other)
    {
         Debug.Log("dd");

        hand += 1;
        print(hand);

        if(hand>5)
        {
            hand = 0;
            StartCoroutine("FadeOutIntro");
        }
    }
   
    // Update is called once per frame
    void Update()
    {

        if(isSoundOut == true)
        {
            all.volume-=0.003f;
            right.volume-=0.003f;
            left.volume-=0.003f;
            if(all.volume <= 0.0f)
            {
                isSoundOut = false;      
            }
        }
    }

    IEnumerator FadeOutIntro()
    {
        isSoundOut =true;
        GameObject.Find("Canvas2").GetComponent<UIFADE>().Fadem();
        yield return new WaitForSeconds(1f);
        GameObject.Find("Quad").SetActive(false);
        GameObject.Find("GunFire").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(2);

    }

}
