using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class DRoom_Dialogue1 : MonoBehaviour
{
    public GameObject PlayerUI_1, PlayerUI_2, PlayerUI_3, PlayerUI_4;
    public GameObject YouUI;
    public AudioSource You_Sound1, You_Sound2, You_Sound3, You_Sound4;
    public Text Text_You;


    private void Awake()
    {
        // Player UI 입력
        PlayerUI_1 = GameObject.Find("Canvas_PlayerUI_1");
        PlayerUI_2 = GameObject.Find("Canvas_PlayerUI_2");
        PlayerUI_3 = GameObject.Find("Canvas_PlayerUI_3");
        PlayerUI_4 = GameObject.Find("Canvas_PlayerUI_4");

        // You UI와 판넬 입력
        YouUI = GameObject.Find("Canvas_YouUI");


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

        YouUI.SetActive(false);
    }


    public void OnClickPlayerUI_1()
    {
        PlayerUI_1.SetActive(false);

        YouUI.SetActive(true);
        Text_You.text = "관순 : ... 저는 의무라고만 여겼어요. 나라를 되찾으려는 당연한 의무...";
        You_Sound1.Play();
        Debug.Log("You_Sound1.Play()");
        
        Debug.Log("You_Sound2.Play()");

        Invoke("PlayerUI_2_func", 15.0f);
    }


    public void OnClickPlayerUI_2()
    {
        PlayerUI_2.SetActive(false);

        YouUI.SetActive(true);
        Text_You.text = "관순 : 어떻게 보면.. 나란 년은 정말 이상 속에서 잘난 체만 하면서 산 거 같아요.";
        Invoke("Text_You2_2_func", 30.0f);
        Invoke("Text_You2_3_func", 40.0f);
        Invoke("PlayerUI_3_func", 52.0f);
    }

    public void OnClickPlayerUI_3()
    {
        PlayerUI_3.SetActive(false);

        YouUI.SetActive(true);
        Text_You.text = "관순 : 그래도 정당한 일을 하니까 하나님이 도와 주실 줄 알았어요.";
        Invoke("Text_You3_2_func", 10.0f);

        You_Sound3.Play();
        Debug.Log("You_Sound3.Play()");
        Invoke("PlayerUI_4_func", 18.0f);
    }


    public void OnClickPlayerUI_4()
    {
        PlayerUI_4.SetActive(false);

        YouUI.SetActive(true);
        Text_You.text = "관순 : 금년이 윤달이 아니라면 딱 삼 일 남은 거 같아요.";
        You_Sound4.Play();
        Debug.Log("You_Sound4.Play()");
        // 9.0f 이후 자막 없어짐
        Invoke("YouUIFalse_func", 9.0f);
    }


    void Text_You2_2_func()
    {
        Text_You.text = "관순 : 진짜 만숙이 어머니 말 대로 내가 경성에서 만세소식을 전하러 내려오지 않았다면..";
    }

    void Text_You2_3_func()
    {
        Text_You.text = "관순 : 우리 부모님 고향사람들까지 돌아가시지 않았을지도 모르잖아요.";
    }

    void Text_You3_2_func()
    {
        Text_You.text = "관순 : 언니에 비하면 나는 만세부를 자격도 없는데..";
    }

    void YouUIFalse_func()
    {
        YouUI.SetActive(false);
    }







    void PlayerUI_2_func()
    {
        PlayerUI_2.SetActive(true);
        YouUI.SetActive(false);
        You_Sound2.Play(); // 흐느낌 소리 여기서부터 시작!
    }
    void PlayerUI_3_func()
    {
        PlayerUI_3.SetActive(true);
        YouUI.SetActive(false);
    }
    void PlayerUI_4_func()
    {
        PlayerUI_4.SetActive(true);
        YouUI.SetActive(false);
    }
}