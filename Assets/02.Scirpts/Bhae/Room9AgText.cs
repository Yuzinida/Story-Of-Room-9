using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room9AgText : MonoBehaviour
{
    public bool tFaded = true; 
    public float duration = 0.4f;


    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvas5;


    void Start()
    {
     Invoke("can1",1f);
     Invoke("can2",1f);
     Invoke("can3",1f);
     Invoke("can4",1f);
     Invoke("can5",1f);

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
