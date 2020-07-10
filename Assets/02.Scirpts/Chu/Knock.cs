using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knock : MonoBehaviour
{
    AudioSource knockWall,knockRoomSound,knockRoomSound2,arirangAndStop,stopSinging,reStartSing;
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
            
    }
    //테스트
        private void Start()
        {
             NextScene();
            // Recede();
            //StopSinging();
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
        Invoke("ReStartSing",15f);
        
    }
    // // 발걸음 멀어지는 코드
    void Recede()
    {
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
    }

}
