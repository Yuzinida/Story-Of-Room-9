﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceEyes : MonoBehaviour
{
    AudioSource obSound;
    public AudioClip downSound;
    public AudioClip upSound;
    private void Awake()
    {
        obSound = this.GetComponent<AudioSource>();
        obSound.clip = downSound;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Police"))
        {
            Invoke("Down",1.5f);            
            obSound.Play();
        }
    }
    void Down()
    {
        Hashtable ht = new Hashtable();
        ht.Add("time",0.2f);
        ht.Add("path",iTweenPath.GetPath("Down"));
        ht.Add("easetype",iTween.EaseType.linear);

        iTween.MoveTo(this.gameObject, ht);

        Invoke("Up",3f);  //지켜보는 시간 조정
    }
    void Up()
    {
        obSound.clip = upSound;
        obSound.Play();
        
        Hashtable ht2 = new Hashtable();
        ht2.Add("time",0.2f);
        ht2.Add("path",iTweenPath.GetPath("Up"));
        ht2.Add("easetype",iTween.EaseType.linear);

        iTween.MoveTo(this.gameObject, ht2);
    }
}