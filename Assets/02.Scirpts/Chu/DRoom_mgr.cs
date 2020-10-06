using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class DRoom_mgr : MonoBehaviour
{
    UIFADE dCanvas;
    GameObject startUI;
    AudioSource backSound,ending;
    Animator sunlight,dooropen;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine("PlayDRoom");
        dCanvas = GameObject.Find("DRoom_Tutorial_Can").GetComponent<UIFADE>();
        startUI = GameObject.Find("PlayerDialogue").transform.GetChild(0).gameObject;
        backSound = GameObject.Find("BackSound").GetComponent<AudioSource>();
        ending = GameObject.Find("Ending").GetComponent<AudioSource>();
        sunlight = GameObject.Find("DayLight").GetComponent<Animator>();

        dooropen = GameObject.Find("Ddoor (2)").GetComponent<Animator>();

        //StartCoroutine("Test");
    }
    IEnumerator PlayDRoom()
    {
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, 0.1f);

        yield return new WaitForSeconds(2.5f);
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, 3f);

        yield return new WaitForSeconds(10.5f);

        dCanvas.Fadem();        

        //처음 독방 알려주는 글씨 지속시간
        yield return new WaitForSeconds(5f);

        dCanvas.Fadem();

        // 대사 시작하는 시간 조절
        yield return new WaitForSeconds(10f);

        startUI.SetActive(true);
        backSound.Play();
    }

    public void Ending()
    {
        StartCoroutine("EndSound");
        
    }

    IEnumerator EndSound()
    {
        yield return new WaitForSeconds(4f);
        // 날씨 변화 시작         
        sunlight.SetBool("Daylight",true);  

        yield return new WaitForSeconds(0.5f);
        GameObject.Find("Patience").GetComponent<AudioSource>().Play();   

           

        yield return new WaitForSeconds(1f);
        GameObject.Find("Sunsound").GetComponent<AudioSource>().Play();   // 시작타이밍

        yield return new WaitForSeconds(3f);        //해뜨는 애니메 시간에 따라 시작되는 시간 더 늦추기
        ending.Play();
        GameObject.Find("Patience").GetComponent<AudioSource>().Stop();
        
        yield return new WaitForSeconds(0.3f);
        dooropen.SetTrigger("OpenDoor"); 

        yield return new WaitForSeconds(10f);
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.white, 6f);

        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(6);
    }

    //  IEnumerator Test()
    //  {
    //      yield return new WaitForSeconds(5f);       
    //     ending.Play();
        
    //     yield return new WaitForSeconds(0.3f);
    //     dooropen.SetTrigger("OpenDoor"); 
    //  }
}
