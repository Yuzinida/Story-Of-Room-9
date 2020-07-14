using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DRoom_Dialogue1 : MonoBehaviour
{
    public GameObject PlayerUI_1, PlayerUI_2, PlayerUI_3, PlayerUI_4;
    public GameObject YouUI_1, YouUI_2, YouUI_3, YouUI_4;
    public AudioSource You_Sound1, You_Sound2, You_Sound3, You_Sound4;
    bool knockRoom = false;
    int count = 0;
    private void Awake()
    {
        // Player UI 입력
        PlayerUI_1 = GameObject.Find("Canvas_PlayerUI_1");
        PlayerUI_2 = GameObject.Find("Canvas_PlayerUI_2");
        PlayerUI_3 = GameObject.Find("Canvas_PlayerUI_3");
        PlayerUI_4 = GameObject.Find("Canvas_PlayerUI_4");

        // You UI 입력
        YouUI_1 = GameObject.Find("Canvas_YouUI_1");
        YouUI_2 = GameObject.Find("Canvas_YouUI_2");
        YouUI_3 = GameObject.Find("Canvas_YouUI_3");
        YouUI_4 = GameObject.Find("Canvas_YouUI_4");


        // 소리 입력
        You_Sound1 = GameObject.Find("YouSound_1").GetComponent<AudioSource>();
        You_Sound2 = GameObject.Find("YouSound_2").GetComponent<AudioSource>();
        You_Sound3 = GameObject.Find("YouSound_3").GetComponent<AudioSource>();
        You_Sound4 = GameObject.Find("YouSound_4").GetComponent<AudioSource>();
    }

    void Start()
    {
        PlayerUI_1.SetActive(true);
        PlayerUI_2.SetActive(false);
        PlayerUI_3.SetActive(false);
        PlayerUI_4.SetActive(false);

        YouUI_1.SetActive(false);
        YouUI_2.SetActive(false);
        YouUI_3.SetActive(false);
        YouUI_4.SetActive(false);

    }


    public void OnClickPlayerUI_1()
    {
        PlayerUI_1.SetActive(false);
        //YouUI_1.SetActive(true);
        You_Sound1.Play();
        Debug.Log("You_Sound1.Play()");
        Invoke("PlayerUI_2_func", 15.0f);
    }
    public void OnClickPlayerUI_2()
    {
        PlayerUI_2.SetActive(false);
        //YouUI_2.SetActive(true);
        You_Sound2.Play();
        Debug.Log("You_Sound2.Play()");
        Invoke("PlayerUI_3_func", 52.0f);
    }

    public void OnClickPlayerUI_3()
    {
        PlayerUI_3.SetActive(false);
        //YouUI_3.SetActive(true);
        You_Sound3.Play();
        Debug.Log("You_Sound3.Play()");
        Invoke("PlayerUI_4_func", 18.0f);
    }


        public void OnClickPlayerUI_4()
    {
        PlayerUI_4.SetActive(false);
        //YouUI_4.SetActive(true);
        You_Sound4.Play();
        Debug.Log("You_Sound4.Play()");
        // 9.0f 이후 자막 없어짐
    }

    void PlayerUI_2_func()
    {
        PlayerUI_2.SetActive(true);
        //YouUI_1.SetActive(false);
    }
    void PlayerUI_3_func()
    {
        PlayerUI_3.SetActive(true);
        //YouUI_2.SetActive(false);
    }
    void PlayerUI_4_func()
    {
        PlayerUI_4.SetActive(true);
        //YouUI_3.SetActive(false);
    }

}