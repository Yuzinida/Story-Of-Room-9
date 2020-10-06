using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class WhiteInOut : MonoBehaviour
{
    Transform player;
    int count = 0;
    int count2 = 0;
    AudioSource clock,brild;
    public Text echotext;
    GameObject come;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        clock = GameObject.Find("Clock").GetComponent<AudioSource>();
        brild = GameObject.Find("Brild").GetComponent<AudioSource>();
        come = GameObject.Find("ComeHere").transform.GetChild(0).gameObject;
        StartCoroutine("EchoUI");
    }
    private void Update()
    {
        if(player.rotation.y >= 0.3f || player.rotation.x >= 0.3f || player.rotation.y <= -0.3f || player.rotation.x <= -0.3f)
        {   
            count += 1;
            count2 = 0;
            if(count <= 1)
            {
                SteamVR_Fade.Start(new Color(1,1,1,0.2f), 5f);
            }
        }
        else
        {   
            count2 += 1;
            count = 0;
            if(count2 <= 1)
            {
                SteamVR_Fade.Start(new Color(1,1,1,0.01f), 3f);
            }
        }
    }

    IEnumerator EchoUI()
    {
        yield return new WaitForSeconds(5.5f);
        echotext.text = "관순 : 다른 언니들처럼 난 진짜 \n 만세를 불러본 적도 없는 거네요.";

        yield return new WaitForSeconds(6f);
        echotext.text = "";

        yield return new WaitForSeconds(1f);
        echotext.text = "관순 : 그럼 이제 진짜 싸움을 해야죠 \n 진짜 자유롭기 위해서."; 

        yield return new WaitForSeconds(7f);
        echotext.text = ""; 

        yield return new WaitForSeconds(1.6f);
        echotext.text = "관순 : 바칠 목숨이 하나뿐이라 그게 아쉽네요."; 

        yield return new WaitForSeconds(5f);
        echotext.text = "";

        yield return new WaitForSeconds(3.6f);
        clock.Play();
        brild.Play();
        come.SetActive(true);
        SteamVR_Fade.Start(Color.clear, 0.1f);
        this.GetComponent<WhiteInOut>().enabled = false;
    }
}
