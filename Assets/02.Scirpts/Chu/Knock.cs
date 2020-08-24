﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Knock : MonoBehaviour
{
    AudioSource knockWall,knockRoomSound,knockRoomSound2,stopSinging,reStartSing,violence,blackOut,playerTo;
    
    bool knockRoom = false;
    int count = 0;
    GameObject knockGuide,arirangAndStop;
    private void Awake()
    {
        
        knockWall = this.GetComponent<AudioSource>();
        knockRoomSound = GameObject.Find("KnockRoom").GetComponent<AudioSource>();
        knockRoomSound2 = GameObject.Find("KnockRoom2").GetComponent<AudioSource>();
        arirangAndStop = GameObject.Find("PlayStory").transform.GetChild(3).gameObject;
        stopSinging = GameObject.Find("StopSinging").GetComponent<AudioSource>();
        reStartSing = GameObject.Find("ReStartSing").GetComponent<AudioSource>();
        violence = GameObject.Find("Violence").GetComponent<AudioSource>();
        blackOut = GameObject.Find("BlackOut").GetComponent<AudioSource>();
        playerTo = GameObject.Find("PlayerTo").GetComponent<AudioSource>();
        knockGuide = this.transform.GetChild(0).gameObject;
    }


    //노크 이벤트
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand") ){
            knockWall.Play();
            count += 1;
            if(knockRoom == false)
            {
                count = 0;
            }
            else if(knockRoom == true && count >=1 )
            {
                if(knockGuide.activeSelf==true)
                {
                    knockGuide.SetActive(false);
                    GameObject.Find("KnockRoom2").SetActive(false);
                }
            }
            else if(knockRoom == true && count >=4 )
            {
                count = 0;
                knockRoomSound.Play();
                if(arirangAndStop.activeSelf==false)
                {
                    arirangAndStop.SetActive(true);
                    MainStory();
                }

            }
            
        }
    }
    public void NextScene()
    {
        // 코르틴으로 true 와 액티브 트루
        knockGuide.SetActive(true);        
        knockRoom = true;
    }
    void MainStory()
    {
        StartCoroutine("MainStoryStart");
    }
    IEnumerator MainStoryStart()
    {
        yield return new WaitForSeconds(10f);  //////////// 아리랑 노래 녹음한다음 녹음초수에 맞춰서 스탑시키는 음악 나오는 시간 적기 수정
        stopSinging.Play();
        knockRoom = false;
        yield return new WaitForSeconds(8f);
        Recede();
        yield return new WaitForSeconds(3f);
        ReStartSing();
        yield return new WaitForSeconds(20.5f);
        Violence();
    }
    // // 아리랑 노래 끊고, 멀어지는 순사, 노크 반응차단
   
    // // 발걸음 멀어지는 코드
    void Recede()
    {
        GameObject.Find("StopSinging").GetComponent<AudioReverbFilter>().enabled = true;

        Hashtable ht = new Hashtable();
        ht.Add("time",8.0f);
        ht.Add("path",iTweenPath.GetPath("Walk"));
        ht.Add("easetype",iTween.EaseType.linear);

        iTween.MoveTo(stopSinging.gameObject, ht);
    }    
    // // 발걸음 멀어지는 코드와 동시에 다시 개기듯 노래 또 부르기 시작하는 장면 
    void ReStartSing()
    {
        reStartSing.Play();
    }
    void Violence()
    {
        violence.Play();
        Invoke("PlayerTo",10f);
        Invoke("BlackOut",14f);
        Hashtable ht2 = new Hashtable();
        ht2.Add("time",15f);
        ht2.Add("path",iTweenPath.GetPath("violence"));
        ht2.Add("easetype",iTween.EaseType.linear);

        iTween.MoveTo(violence.gameObject, ht2);
    }    
    void PlayerTo()
    {
        playerTo.Play();
        Hashtable ht3 = new Hashtable();
        ht3.Add("time",4f);
        ht3.Add("path",iTweenPath.GetPath("PlayerTo"));
        ht3.Add("easetype",iTween.EaseType.linear);

        iTween.MoveTo(playerTo.gameObject, ht3);
    }
    void BlackOut()
    {
        blackOut.Play();
        GameObject.Find("door").GetComponent<Animator>().SetTrigger("DoorOpen");
        Invoke("Fade_Out",0.5f);
        
    }
    void Fade_Out()
    {
         //set start color
         SteamVR_Fade.Start(Color.clear, 0f);
         //set and start fade to
         SteamVR_Fade.Start(Color.black, 1f);

         //다음씬으로!
         StartCoroutine("NextDRoom");

    }
    
    IEnumerator NextDRoom()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(4);
    }




}
