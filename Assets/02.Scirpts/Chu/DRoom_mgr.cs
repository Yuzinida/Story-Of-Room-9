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
    Animator sunlight;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine("PlayDRoom");
        dCanvas = GameObject.Find("DRoom_Tutorial_Can").GetComponent<UIFADE>();
        startUI = GameObject.Find("PlayerDialogue").transform.GetChild(0).gameObject;
        backSound = GameObject.Find("BackSound").GetComponent<AudioSource>();
        ending = GameObject.Find("Ending").GetComponent<AudioSource>();
        sunlight = GameObject.Find("SunLight").GetComponent<Animator>();
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
        // 날씨 변화 시작 
        sunlight.SetBool("Daylight",true);
        GameObject.Find("RainDrop").gameObject.SetActive(false);
        StartCoroutine("EndSound");
        
    }

    IEnumerator EndSound()
    {
        yield return new WaitForSeconds(2f);
        ending.Play();
        // 날씨 스탑 (소리먼저들려도 되고)       

        yield return new WaitForSeconds(12f);
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.white, 6f);

        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(6);
    }
}
