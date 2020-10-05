using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class DRoom_Dialogue : MonoBehaviour
{
    GameObject PlayerUI_1, PlayerUI_2, PlayerUI_3, PlayerUI_4, PlayerUI_5;    
    AudioSource You_Sound1, You_Sound2, You_Sound3, You_Sound4,You_Sound5, backSound,gamemgr, thunder2, thunderImpact;
    GameObject YouUI;
    public Text Text_You;


    private void Awake()
    {
        // Player UI 입력
        PlayerUI_1 = GameObject.Find("PlayerDialogue").transform.GetChild(0).gameObject;
        PlayerUI_2 = GameObject.Find("PlayerDialogue").transform.GetChild(1).gameObject;
        PlayerUI_3 = GameObject.Find("PlayerDialogue").transform.GetChild(2).gameObject;
        PlayerUI_4 = GameObject.Find("PlayerDialogue").transform.GetChild(3).gameObject;
        PlayerUI_5 = GameObject.Find("PlayerDialogue").transform.GetChild(4).gameObject;

        // You UI와 판넬 입력
        YouUI = GameObject.Find("YouDialogue").transform.GetChild(0).gameObject;


        // 소리 입력
        You_Sound1 = GameObject.Find("YouSound_1").GetComponent<AudioSource>();
        You_Sound2 = GameObject.Find("YouSound_2").GetComponent<AudioSource>();
        You_Sound3 = GameObject.Find("YouSound_3").GetComponent<AudioSource>();
        You_Sound4 = GameObject.Find("YouSound_4").GetComponent<AudioSource>();
        You_Sound5 = GameObject.Find("YouSound_5").GetComponent<AudioSource>();
        backSound = GameObject.Find("BackSound").GetComponent<AudioSource>();
        gamemgr = GameObject.Find("GameManager").GetComponent<AudioSource>();
        thunder2 = GameObject.Find("Thunder2").GetComponent<AudioSource>();
        thunderImpact = GameObject.Find("ThunderImpact").GetComponent<AudioSource>();
    }



    public void OnClickPlayerUI_1()
    {
        PlayerUI_1.SetActive(false);

        You_Sound1.Play();

        StartCoroutine("PlayerUI_2_func");

    }


    public void OnClickPlayerUI_2()
    {
        PlayerUI_2.SetActive(false);
        You_Sound2.Play(); 
        StartCoroutine("PlayerUI_3_func");

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

        

        StartCoroutine("PlayerUI_4_func");
    }


    public void OnClickPlayerUI_4()
    {
        thunderImpact.Play();
        thunder2.Stop();
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

    public void OnClickPlayerUI_5()
    {
        PlayerUI_5.SetActive(false);
        

        StartCoroutine("RealEndUID");
        
    }


    IEnumerator PlayerUI_2_func()
    {
        yield return new WaitForSeconds(2f);
        YouUI.SetActive(true);
        Text_You.text = "관순 : ... 전.. 병천에서 온 유관순이라고 합니다.";

        yield return new WaitForSeconds(7f);
        Text_You.text = "";
        PlayerUI_2.SetActive(true);        
        
    }
    IEnumerator PlayerUI_3_func()
    {
        yield return new WaitForSeconds(6f); 
        Text_You.text = "관순 : 전 잔다르크처럼 나라를 구하는 소녀가 되고 싶었어요.";

        yield return new WaitForSeconds(9f);
        Text_You.text = "관순 : 그 의무감으로 저도 노력하면 자유를 찾을 수 있다 생각했는데..";

        yield return new WaitForSeconds(9f);
        Text_You.text = "관순 : 오히려 모든걸 빼앗겨버렸어요.. 제 눈앞에서...";

        yield return new WaitForSeconds(7f);
        Text_You.text = "관순 : 어머니.. 아버지.. 마을사람들까지 그놈들이 전부..!";

        yield return new WaitForSeconds(9.0f);
        Text_You.text = "";
        
        yield return new WaitForSeconds(2.0f);
        PlayerUI_3.SetActive(true);
    }
    IEnumerator PlayerUI_4_func()
    {
        yield return new WaitForSeconds(1f); 
        You_Sound3.Play();

        yield return new WaitForSeconds(1f); 
        Text_You.text = "관순 : 저희 부모님 억울해서 어쩌죠  ";
        
        yield return new WaitForSeconds(3.0f); 
        Text_You.text = "관순 : 죽은 우리 마을 사람들 원통하고 분해서 어떡해요..";

        yield return new WaitForSeconds(6.0f); 
        Text_You.text = "관순 : 기도하며 행하면.. 하나님이 지혜를 주실 줄 알았는데..";
        
        yield return new WaitForSeconds(1.5f); 
        thunder2.Play();

        yield return new WaitForSeconds(5.5f);
        Text_You.text = "";

        yield return new WaitForSeconds(8.5f); 
        PlayerUI_4.SetActive(true);
        // YouUI.SetActive(false);
    }
    IEnumerator EndUID()
    {
        yield return new WaitForSeconds(7f);
        You_Sound4.Play();

        yield return new WaitForSeconds(2f);
        Text_You.text = "관순 : 내가 원하는 것에 목숨을 바치는 거... 자유..";

        yield return new WaitForSeconds(7.0f);
        Text_You.text = "";

        yield return new WaitForSeconds(3f);
        Text_You.text = "관순 : 전 이상속에서 분노 하나에 빠져 떼만 쓰고 있었네요..";        
        
        yield return new WaitForSeconds(4.5f);
        Text_You.text = "관순 : 뺏지말라고... 돌려내라고.. 이미 마음이 꺾인싸움..";
        
        yield return new WaitForSeconds(6f);
        Text_You.text = "관순 : 내 자유를 그들 손에 쥐여주고 있었네 내가...";
        
        yield return new WaitForSeconds(4f);
        Text_You.text = "관순 : 정작 나는 의무감만 있고 모든 걸 다 던질 생각조차 못 하고 있었어요.";
        
        yield return new WaitForSeconds(8.5f);
        Text_You.text = "";
        
        yield return new WaitForSeconds(4f);
        PlayerUI_5.SetActive(true);
        
    }

    IEnumerator RealEndUID()
    {
        for(int i=0 ; i<100; i++)
        {
            yield return new WaitForSeconds(0.02f);
            gamemgr.volume -= 0.01f;
        }
        GameObject.Find("RainDrop").gameObject.SetActive(false);
        You_Sound5.Play();

        yield return new WaitForSeconds(4.5f);
        Text_You.text = "관순 : 3월1일..";

        yield return new WaitForSeconds(4.0f);
        Text_You.text = "관순 : 네 이제 딱 3일 남은 거 같아요.";

        yield return new WaitForSeconds(6.0f);
        YouUI.SetActive(false);
        gamemgr.gameObject.GetComponent<DRoom_mgr>().Ending();
    }

    
}