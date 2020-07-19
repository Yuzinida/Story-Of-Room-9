using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Room9AgText : MonoBehaviour
{
    public bool tFaded = true; 
    public float duration = 0.4f;


    public GameObject canvas1,canvas2,canvas3,canvas4,canvas5;

    

    void Start()
    {
        //set start color
        SteamVR_Fade.Start(Color.white, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.white, 0.1f);
        //StartCoroutine("ShowUI");
        StartCoroutine("WhiteIn");

    }

    IEnumerator WhiteIn()
    {
        

        yield return new WaitForSeconds(3f);
        //set start color
        SteamVR_Fade.Start(Color.white, 0f);
        //set and start fade to
        SteamVR_Fade.Start(new Color(1,1,1,0.01f), 3f);

    }

    

    IEnumerator ShowUI()
    {
        yield return new WaitForSeconds(0.5f);
        can1();
        yield return new WaitForSeconds(8f);
        can2();
        yield return new WaitForSeconds(5.5f);
        can3();
        yield return new WaitForSeconds(5.5f);
        can4();
        yield return new WaitForSeconds(7f);
        can4();
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
