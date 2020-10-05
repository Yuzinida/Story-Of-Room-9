using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial1_1to1_2 : MonoBehaviour
{

    public GameObject Tutorial1_1;
    public GameObject Tutorial1_2;
    public GameObject Tutorial1_3;
    public GameObject Tutorial2;
    public GameObject Tutorial3;


    private void Start()
    {
        //touchTwo = GameObject.Find("Touch_two").GetComponent<Transform>();
        //godSound = GameObject.Find("GodSounds").GetComponent<GodSound>();


        //Tutorial1_1 = GameObject.Find("Tutorial1-1-----------------");
        //Tutorial1_2 = GameObject.Find("Tutorial1-2-----------------");
        //Tutorial1_3 = GameObject.Find("Tutorial1-3-----------------");
        //Tutorial2 = GameObject.Find("Tutorial2------------------");
        //Tutorial3 = GameObject.Find("Tutorial3------------------");


        //Tutorial1_2 = GameObject.Find("Tutorial1-2-----------------").transform.GetChild(0).gameObject;
        // Tutorial1_3 = GameObject.Find("Tutorial1-3-----------------").transform.GetChild(0).gameObject;
        //Tutorial2 = GameObject.Find("Tutorial2------------------").transform.GetChild(0).gameObject;
        //Tutorial3 = GameObject.Find("Tutorial3------------------").transform.GetChild(0).gameObject;

        //InitialTutorialSetting();
        Invoke("InitialTutorialSetting()", 0.2f);

    }

    
    private void Update()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //touchTwo.LookAt(player);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            Debug.LogFormat("컨트롤러가 목표지점 안에 들어왔다");
            this.GetComponent<AudioSource>().Play();

            Invoke("ShowTutorial1_2", 0.3f);
            Debug.LogFormat("튜토리얼2 생성!");  // x 위치가 0보다 크면 1 작으면 -1이 나온다.

        }
    }

    void ShowTutorial1_2() // 튜토리얼3가 나타난다.
    {
        Tutorial1_2.SetActive(true);
        Tutorial1_1.SetActive(false);
    }

    void InitialTutorialSetting() // 튜토리얼 초기 셋팅을 보여준다. 1_1만 켜져 있고 나머지는 꺼져있다.
    {
        Tutorial1_1.SetActive(true);
        Tutorial1_2.SetActive(false);
        Tutorial1_3.SetActive(false);
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(false);
    }



}
