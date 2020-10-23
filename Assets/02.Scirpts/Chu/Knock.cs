using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Knock : MonoBehaviour
{
    AudioSource knockWall,knockRoomSound,stopSinging,reStartSing,violence,blackOut,playerTo;
    CanvasGroup knockHow;
    bool knockRoom = false;
    int count = 0;
    public GameObject knockGuide,arirangAndStop;
    private void Awake()
    {
        
        knockWall = this.GetComponent<AudioSource>();
        knockRoomSound = GameObject.Find("KnockRoom").GetComponent<AudioSource>();
        arirangAndStop = GameObject.Find("PlayStory").transform.GetChild(3).gameObject;
        stopSinging = GameObject.Find("StopSinging").GetComponent<AudioSource>();
        reStartSing = GameObject.Find("ReStartSing").GetComponent<AudioSource>();
        violence = GameObject.Find("Violence").GetComponent<AudioSource>();
        blackOut = GameObject.Find("BlackOut").GetComponent<AudioSource>();
        playerTo = GameObject.Find("PlayerTo").GetComponent<AudioSource>();
        knockGuide = this.transform.GetChild(0).gameObject;
        knockHow = GameObject.Find("HowKnock").GetComponent<CanvasGroup>();
    }

    // test
    // private void Start()
    // {
    //     Violence();        
    // }
    // test

    //노크 이벤트
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand") ){
            knockWall.Play();
            count += 1;
            print(count);
            if(knockRoom == false)
            {
                count = 0;
            }
            if(knockRoom == true && count >=1 )
            {
                if(knockGuide.activeSelf==true)
                {
                    knockGuide.SetActive(false);
                    GameObject.Find("KnockRoom2").SetActive(false);
                }
            }
            if(knockRoom == true && count >=4 )
            {
                count = 0;
                knockRoomSound.Play();
                if(arirangAndStop.activeSelf==false)
                {
                    arirangAndStop.SetActive(true);
                    MainStory();
                    HowKnock();
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
    void HowKnock()
    {
        StartCoroutine("HowTo");
    }
    IEnumerator HowTo()
    {
        yield return new WaitForSeconds(6f);
        for(float f = 0f; f < 1f; f+=0.01f)
        {
            knockHow.alpha+=0.01f;
            yield return null;
        }
        yield return new WaitForSeconds(7f);
        for(float f = 1f; f > 0f; f-=0.01f)
        {
            knockHow.alpha-=0.01f;
            yield return null;
        }
    }
    void MainStory()
    {
        StartCoroutine("MainStoryStart");
    }
    IEnumerator MainStoryStart()
    {
        yield return new WaitForSeconds(21.5f);  
        stopSinging.Play();
        reStartSing.Play();
        GameObject.Find("ReStartSing").transform.GetChild(2).gameObject.SetActive(true); 
        knockRoom = false;
        yield return new WaitForSeconds(8f);
        Recede();

        yield return new WaitForSeconds(23.5f);
        GameObject.Find("ReStartSing").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("ReStartSing").transform.GetChild(1).gameObject.SetActive(true);
                
        yield return new WaitForSeconds(1.5f);  
        Violence();
    }
   
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
   //1021
    void Violence()
    {
        violence.Play();
        Invoke("PlayerTo",9f);
        Invoke("BlackOut",13f);  // 씬 마무리 타임 설정
        Hashtable ht2 = new Hashtable();
        ht2.Add("time",13f);
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
        GameObject.Find("door_ctr").GetComponent<Animator>().SetTrigger("DoorOpen");
        Invoke("Fade_Out",2f);
        
    }
    void Fade_Out()
    {
         //set start color
         SteamVR_Fade.Start(Color.clear, 0f);
         //set and start fade to
         SteamVR_Fade.Start(Color.black, 2f);

         //다음씬으로!
         StartCoroutine("NextDRoom");

    }
    
    IEnumerator NextDRoom()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(4);
    }




}
