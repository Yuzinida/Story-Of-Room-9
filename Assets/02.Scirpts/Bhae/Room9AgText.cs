using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Room9AgText : MonoBehaviour
{
    public bool tFaded = true; 
    public float duration = 0.4f;


    public GameObject canvas1,canvas2,canvas3,canvas4,canvas5;
    GameObject final;
    AudioSource manse;

    WhiteInOut ableTime;

    void Start()
    {
        
        StartCoroutine("WhiteInC");
        ableTime = GameObject.Find("BackSound").GetComponent<WhiteInOut>();
        final = GameObject.Find("Final").transform.GetChild(0).gameObject;
        manse = GameObject.Find("Manse").GetComponent<AudioSource>();

    }

    IEnumerator WhiteInC()
    {
        
        //set start color
        SteamVR_Fade.Start(Color.white, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.white, 0f);
        //StartCoroutine("ShowUI");
        yield return new WaitForSeconds(2f);
        ableTime.enabled = true;

    }

    
    public void ShowUI()
    {
        StartCoroutine("ShowUIStart");
    }

    IEnumerator ShowUIStart()
    {
        yield return new WaitForSeconds(8f);
        can1();
        yield return new WaitForSeconds(3f);
        can2();
        yield return new WaitForSeconds(3f);
        can3();
        yield return new WaitForSeconds(3f);
        can4();
        yield return new WaitForSeconds(3f);
        can5();
        final.SetActive(true);
        yield return new WaitForSeconds(24f);
        if(final.activeSelf)
        {
            final.SetActive(false);
            manse.Play();
        }
        yield return new WaitForSeconds(19f);
        SteamVR_Fade.Start(Color.white, 2f);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(7);
    }
   public void can1()
    {
        CanvasGroup canvGroup = canvas1.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, tFaded ? 1 : 0));
        //tFaded = !tFaded;
    }
    public void can2()
    {
        CanvasGroup canvGroup = canvas2.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, tFaded ? 1 : 0));
        //tFaded = !tFaded;
    }
      public void can3()
    {
        CanvasGroup canvGroup = canvas3.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, tFaded ? 1 : 0));
        //tFaded = !tFaded;
    }
      public void can4()
    {
        CanvasGroup canvGroup = canvas4.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, tFaded ? 1 : 0));
        //tFaded = !tFaded;
    }
      public void can5()
    {
        CanvasGroup canvGroup = canvas5.GetComponent<CanvasGroup>();
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, tFaded ? 1 : 0));
        //tFaded = !tFaded;
    }
    
    public IEnumerator DoFade(CanvasGroup canvasGroup, float start, float end)
    {
        float counter = 0f;
        while(counter<duration)
        {
            counter += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start,end, counter/duration);
            yield return null;
        }
    }
}
