using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    AudioSource left,right,all;
    float hand = 0;
    bool isSoundOut;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
         Debug.Log("dd");

        hand += 1;
        print(hand);

        if(hand>5)
        {
            hand = 0;
            StartCoroutine("FadeOutIntro");
        }
    }
   

    // Update is called once per frame
    void Update()
    {

        if(isSoundOut == true)
        {
            all.volume-=0.005f;
            right.volume-=0.005f;
            left.volume-=0.005f;
            if(all.volume <= 0.0f)
            {
                isSoundOut = false;      
            }
        }
    }

    IEnumerator FadeOutIntro()
    {
        isSoundOut =true;
        GameObject.Find("Canvas2").GetComponent<UIFADE>().Fadem();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(2);

    }

}
