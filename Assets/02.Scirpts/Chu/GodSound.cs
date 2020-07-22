using System.Collections;
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
//    Light lt;
//    Light slt;
   Animator OpenM;
   AudioSource doorMOpen;
   private void Start()
   {
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, 0.1f);

       
       godSound = this.GetComponent<AudioSource>();
    //    lt = GameObject.Find("Point Light").GetComponent<Light>();
    //    slt = GameObject.Find("Spot Light").GetComponent<Light>();
       doorMOpen = GameObject.Find("door.m").GetComponent<AudioSource>();
       bowl = GameObject.Find("RB_W").transform.GetChild(0).gameObject;

       StartCoroutine("RoomFadeIn");

   }

   //시작 페이드인
    IEnumerator RoomFadeIn()
    {

        yield return new WaitForSeconds(2f);

        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, 3f);

        

    }
   public void GodWalk()
   {
       countWalk+=1;
       if(countWalk<=1){
            godSound.clip = walk;
            godSound.Play();

            // lt.intensity = 0.2f;             
            // slt.intensity = 5f;
            //set start color
            SteamVR_Fade.Start(Color.clear, 0f);
            //set and start fade to
            SteamVR_Fade.Start(new Color(0,0,0,0.8f), 1f);

            Hashtable ht = new Hashtable();
            ht.Add("time",15f);
            ht.Add("path",iTweenPath.GetPath("GodWalk"));
            ht.Add("easetype",iTween.EaseType.linear);

            iTween.MoveTo(this.gameObject, ht);

            Invoke("OutLight",12f);

            //ㅅㅡㅌㅗㄹㅣ ㅅㅣㅈㅏㄱ
            Invoke("StartStory",15f);
       }
       
        
   }
   public void GodEat()
   {
       countEat+=1;
       if(countEat<=1){

            // lt.intensity = 0.2f; 
            // slt.intensity = 30f;
            //set start color
            SteamVR_Fade.Start(Color.clear, 0f);
            //set and start fade to
            SteamVR_Fade.Start(new Color(0,0,0,0.8f), 1f);

            godSound.clip = eat;
            godSound.Play();

            Invoke("OutLight",7.5f);
            
       }
        
   }
   void OutLight()
   {
       //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, 0.1f);
    //    lt.intensity = 1.26f;
    //    slt.intensity = 1274f;
   }

   void StartStory()
   {
        GameObject.Find("UIController").SetActive(false);
        bowl.SetActive(true);
        OpenM = GameObject.Find("door.m").GetComponent<Animator>();
        OpenM.SetTrigger("Open");
        doorMOpen.Play();

        //2번째 방법
        //쪽지도 setactive(true)로 만든다.
   }

}
