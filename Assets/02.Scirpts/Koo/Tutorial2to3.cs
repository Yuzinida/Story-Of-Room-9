using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial2to3 : MonoBehaviour
{
    public GameObject Tutorial1_1;
    public GameObject Tutorial1_2;
    public GameObject Tutorial1_3;
    public GameObject Tutorial2;
    public GameObject Tutorial3;

    GameObject ding4;
    private void Start()
    {

        //touchTwo = GameObject.Find("Touch_two").GetComponent<Transform>();
        //godSound = GameObject.Find("GodSounds").GetComponent<GodSound>();
        //Tutorial1 = GameObject.Find("Tutorial1------------------").transform.GetChild(0).gameObject;
        //Tutorial2 = GameObject.Find("Tutorial2------------------").transform.GetChild(0).gameObject;
        //Tutorial3 = GameObject.Find("Tutorial3------------------").transform.GetChild(0).gameObject;

        //Tutorial1 = GameObject.Find("Tutorial1------------------");
        //Tutorial2 = GameObject.Find("Tutorial2------------------");
        //Tutorial3 = GameObject.Find("Tutorial3------------------");

        ding4 = GameObject.Find("Player").transform.GetChild(3).gameObject;


    }

    public void OnClick()
    {
        if(ding4.activeSelf == false)
            {
                ding4.SetActive(true);
            }
        Debug.LogFormat("유아이클릭");
        Invoke("ShowTutorial3", 0.3f);
        Debug.LogFormat("튜토리얼3 생성!");



        Invoke("DeleteTutorial2", 0.0f);
        Debug.LogFormat("튜토리얼1,2 없어짐!");
    }

    


    void DeleteTutorial2() // 튜토리얼2가 없어진다.
    {
        Tutorial2.SetActive(false);
    }

    void ShowTutorial3() // 튜토리얼3가 나타난다.
    {
        Tutorial3.SetActive(true);
    }



}
