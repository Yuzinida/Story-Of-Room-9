using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial1to2 : MonoBehaviour
{
    //public UIFADE fadeUI;
    //Transform touchTwo;
    //Transform player;
    //GodSound godSound;

    public GameObject Tutorial2;


    private void Start()
    {
        //touchTwo = GameObject.Find("Touch_two").GetComponent<Transform>();
        //godSound = GameObject.Find("GodSounds").GetComponent<GodSound>();
        Tutorial2 = GameObject.Find("Tutorial2------------------").transform.GetChild(0).gameObject;
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
            Debug.LogFormat("컨트롤러가 원 안에 들어왔다");
            Invoke("ShowTutorial2", 0.5f);
            Debug.LogFormat("튜토리얼2 생성!");  // x 위치가 0보다 크면 1 작으면 -1이 나온다.

        }
    }

    void ShowTutorial2() // 튜토리얼3가 나타난다.
    {
        Tutorial2.SetActive(true);
    }



}
