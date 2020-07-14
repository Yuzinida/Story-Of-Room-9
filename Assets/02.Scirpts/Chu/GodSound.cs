﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

//갓 사운드는 한번만 재생 가능
public class GodSound : MonoBehaviour
{
    AudioSource godSound;
    int countWalk = 0;
    int countEat = 0;
   public AudioClip eat;
   public AudioClip walk;
   GameObject bowl;
   Light lt;
   Light slt;
   Animator OpenM;
   AudioSource doorMOpen;
   private void Awake()
   {
       godSound = this.GetComponent<AudioSource>();
       lt = GameObject.Find("Point Light").GetComponent<Light>();
       slt = GameObject.Find("Spot Light").GetComponent<Light>();
       doorMOpen = GameObject.Find("door.m").GetComponent<AudioSource>();
       
   }
   private void Start()
   {
       //test
       //StartStory();
   }
   public void GodWalk()
   {
       countWalk+=1;
       if(countWalk<=1){
            godSound.clip = walk;
            godSound.Play();

            lt.intensity = 0.2f;             
            slt.intensity = 10f;

            Hashtable ht = new Hashtable();
            ht.Add("time",20f);
            ht.Add("path",iTweenPath.GetPath("GodWalk"));
            ht.Add("easetype",iTween.EaseType.linear);
            ht.Add("delay",3f);

            iTween.MoveTo(this.gameObject, ht);

            Invoke("OutLight",20f);

            //ㅅㅡㅌㅗㄹㅣ ㅅㅣㅈㅏㄱ
            Invoke("StartStory",25f);
       }
       
        
   }
   public void GodEat()
   {
       countEat+=1;
       if(countEat<=1){

            lt.intensity = 0.2f; 
            slt.intensity = 30f;

            godSound.clip = eat;
            godSound.Play();

            Invoke("OutLight",15f);
            
       }
        
   }
   void OutLight()
   {
       lt.intensity = 1.26f;
       slt.intensity = 1274f;
   }

   void StartStory()
   {
        GameObject.Find("UIController").SetActive(false);
        GameObject.Find("KnockWall").GetComponent<Knock>().NextScene();
        bowl = GameObject.Find("RB_W").transform.GetChild(0).gameObject;
        bowl.SetActive(true);
        OpenM = GameObject.Find("door.m").GetComponent<Animator>();
        OpenM.SetTrigger("Open");
        doorMOpen.Play();
   }

}