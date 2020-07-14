using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Knock : MonoBehaviour
{
    AudioSource knockWall,knockRoomSound,knockRoomSound2,arirangAndStop,stopSinging,reStartSing,violence,blackOut,playerTo;
    bool knockRoom = false;
    int count = 0;
    private void Awake()
    {
        knockWall = this.GetComponent<AudioSource>();
        knockRoomSound = GameObject.Find("KnockRoom").GetComponent<AudioSource>();
        knockRoomSound2 = GameObject.Find("KnockRoom2").GetComponent<AudioSource>();
        arirangAndStop = GameObject.Find("ArirangAndStop").GetComponent<AudioSource>();
        stopSinging = GameObject.Find("StopSinging").GetComponent<AudioSource>();
        reStartSing = GameObject.Find("ReStartSing").GetComponent<AudioSource>();
        violence = GameObject.Find("Violence").GetComponent<AudioSource>();
        blackOut = GameObject.Find("BlackOut").GetComponent<AudioSource>();
        playerTo = GameObject.Find("PlayerTo").GetComponent<AudioSource>();
            
    }
    //테스트
        private void Start()
        {
            // NextScene();
            // BlackOut();
        }
    //

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
            else if(knockRoom == true && count >=4 )
            {
                count = 0;
                knockRoomSound.Play();

            }
        }
    }
    public void NextScene()
    {
        //0714 ㅂㅏㅂㄱㅡㄹㅡㅅ ㅅㅣㅈㅏㄱㅃㅏㄹㄹㅣ! ㅉㅗㄱㅈㅣ


        knockRoom = true;
        Invoke("KnockRoom",15f);
        Invoke("KnockRoom",20f);
        arirangAndStop.Play();
        Invoke("StopSinging",37f);
    }
    void KnockRoom()
    {
        knockRoomSound2.Play();
    }
    // // 아리랑 노래 끊고, 멀어지는 순사, 노크 반응차단
    void StopSinging()
    {
        stopSinging.Play();
        knockRoom = false;
        Invoke("Recede",8f);
        Invoke("ReStartSing",13.5f);
        
    }
    // // 발걸음 멀어지는 코드
    void Recede()
    {
        GameObject.Find("StopSinging").GetComponent<AudioReverbFilter>().enabled = true;

        Hashtable ht = new Hashtable();
        ht.Add("time",5.0f);
        ht.Add("path",iTweenPath.GetPath("Walk"));
        ht.Add("easetype",iTween.EaseType.linear);

        iTween.MoveTo(stopSinging.gameObject, ht);
    }    
    // // 발걸음 멀어지는 코드와 동시에 다시 개기듯 노래 또 부르기 시작하는 장면 
    void ReStartSing()
    {
        reStartSing.Play();
        Invoke("Violence",20.5f);
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
        ht3.Add("time",5f);
        ht3.Add("path",iTweenPath.GetPath("PlayerTo"));
        ht3.Add("easetype",iTween.EaseType.linear);

        iTween.MoveTo(playerTo.gameObject, ht3);
    }
    void BlackOut()
    {
        blackOut.Play();
        Invoke("Fade_Out",0.5f);
        
    }
    void Fade_Out()
    {
         //set start color
         SteamVR_Fade.Start(Color.clear, 0f);
         //set and start fade to
         SteamVR_Fade.Start(Color.black, 1f);

         //다음씬으로!

    }
    




}
