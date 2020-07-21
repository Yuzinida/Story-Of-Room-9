using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class DRoom_Dialogue : MonoBehaviour
{
    GameObject PlayerUI_1, PlayerUI_2, PlayerUI_3, PlayerUI_4;    
    AudioSource You_Sound1, You_Sound2, You_Sound3, You_Sound4, backSound,gamemgr;
    GameObject YouUI;
    public Text Text_You;


    private void Awake()
    {
        // Player UI 입력
        PlayerUI_1 = GameObject.Find("PlayerDialogue").transform.GetChild(0).gameObject;
        PlayerUI_2 = GameObject.Find("PlayerDialogue").transform.GetChild(1).gameObject;
        PlayerUI_3 = GameObject.Find("PlayerDialogue").transform.GetChild(2).gameObject;
        PlayerUI_4 = GameObject.Find("PlayerDialogue").transform.GetChild(3).gameObject;

        // You UI와 판넬 입력
        YouUI = GameObject.Find("YouDialogue").transform.GetChild(0).gameObject;


        // 소리 입력
        You_Sound1 = GameObject.Find("YouSound_1").GetComponent<AudioSource>();
        You_Sound2 = GameObject.Find("YouSound_2").GetComponent<AudioSource>();
        You_Sound3 = GameObject.Find("YouSound_3").GetComponent<AudioSource>();
        You_Sound4 = GameObject.Find("YouSound_4").GetComponent<AudioSource>();
        backSound = GameObject.Find("BackSound").GetComponent<AudioSource>();
        gamemgr = GameObject.Find("GameManager").GetComponent<AudioSource>();
        
    }



    public void OnClickPlayerUI_1()
    {
        PlayerUI_1.SetActive(false);

        YouUI.SetActive(true);
        Text_You.text = "관순 : ... 저는 의무라고만 여겼어요. 나라를 되찾으려는 당연한 의무...";
        You_Sound1.Play();

        StartCoroutine("PlayerUI_2_func");

    }


    public void OnClickPlayerUI_2()
    {
        PlayerUI_2.SetActive(false);

        // YouUI.SetActive(true);
        // Text_You.text = "관순 : 어떻게 보면.. 나란 년은 정말 이상 속에서 잘난 체만 하면서 산 거 같아요.";
        // Invoke("Text_You2_2_func", 30.0f);
        // Invoke("Text_You2_3_func", 40.0f);
    }

    public void OnClickPlayerUI_3()
    {
        PlayerUI_3.SetActive(false);

        // YouUI.SetActive(true);
        // Text_You.text = "관순 : 그래도 정당한 일을 하니까 하나님이 도와 주실 줄 알았어요.";
        // Invoke("Text_You3_2_func", 10.0f);

        You_Sound3.Play();

        StartCoroutine("PlayerUI_4_func");
    }


    public void OnClickPlayerUI_4()
    {
        PlayerUI_4.SetActive(false);

        // YouUI.SetActive(true);
        
        StartCoroutine("EndUID");
        // 9.0f 이후 자막 없어짐
        // Invoke("YouUIFalse_func", 9.0f);
    }


    // void Text_You2_2_func()
    // {
    //     // Text_You.text = "관순 : 진짜 만숙이 어머니 말 대로 내가 경성에서 만세소식을 전하러 내려오지 않았다면..";
    // }

    // void Text_You2_3_func()
    // {
    //     // Text_You.text = "관순 : 우리 부모님 고향사람들까지 돌아가시지 않았을지도 모르잖아요.";
    // }

    // void Text_You3_2_func()
    // {
    //     // Text_You.text = "관순 : 언니에 비하면 나는 만세부를 자격도 없는데..";
    // }

    // void YouUIFalse_func()
    // {
    //     // YouUI.SetActive(false);
    // }


    IEnumerator PlayerUI_2_func()
    {
        yield return new WaitForSeconds(13.0f);
        Text_You.text = "";
        PlayerUI_2.SetActive(true);        
        You_Sound2.Play(); // 흐느낌 소리 여기서부터 시작!

        yield return new WaitForSeconds(15f); //대사시작시간
        if(PlayerUI_2.activeSelf==true)
        {
            PlayerUI_2.SetActive(false);
        }
        Text_You.text = "관순 : 어떻게 보면.. 나란 년은 정말 이상 속에서 잘난 체만 하면서 산 거 같아요.";

        yield return new WaitForSeconds(12f);
        Text_You.text = "관순 : 진짜 만숙이 어머니 말 대로 내가 경성에서 만세소식을 전하러 내려오지 않았다면..";

        yield return new WaitForSeconds(12f);
        Text_You.text = "관순 : 우리 부모님, 고향사람들까지 돌아가시지 않았을지도 모르잖아요.";

        yield return new WaitForSeconds(13.0f);
        Text_You.text = "";
        PlayerUI_3.SetActive(true);
    }
    IEnumerator PlayerUI_4_func()
    {
        Text_You.text = "관순 : 그래도 정당한 일을 하니까 하나님이 도와 주실 줄 알았어요.";
        
        yield return new WaitForSeconds(8.0f); 
        Text_You.text = "관순 : 언니들에 비하면 나는 만세부를 자격도 없는데..";
        
        yield return new WaitForSeconds(10.0f); 
        Text_You.text = "";
        PlayerUI_4.SetActive(true);
        // YouUI.SetActive(false);
    }
    IEnumerator EndUID()
    {
        yield return new WaitForSeconds(3.5f);
        Text_You.text = "관순 : 금년이 윤달이 아니라면 딱 삼 일 남은 거 같아요.";
        You_Sound4.Play();

        yield return new WaitForSeconds(8.0f);
        YouUI.SetActive(false);

        yield return new WaitForSeconds(4.5f);
        for(int i=0 ; i<100; i++)
        {
            yield return new WaitForSeconds(0.02f);
            gamemgr.volume -= 0.01f;
        }

        yield return new WaitForSeconds(2f);
        gamemgr.gameObject.GetComponent<DRoom_mgr>().Ending();
    }
}