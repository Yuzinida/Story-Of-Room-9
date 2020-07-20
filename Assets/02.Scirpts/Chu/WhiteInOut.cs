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
        StartCoroutine("Clock");
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
        yield return new WaitForSeconds(7f);
        echotext.text = "관순 : 성경에서도 행함이 없는 믿음은 온전하지 못하다 그랬잖아요";

        yield return new WaitForSeconds(8f);
        echotext.text = "관순 : 난 나중에 해보기라도 할 걸 하고 후회하고 싶지 않아요."; 

        yield return new WaitForSeconds(8f);
        echotext.text = "관순 : 이런짓도 했었다 이렇게 말 할 거예요."; 

        yield return new WaitForSeconds(7f);
        echotext.text = "";
    }

    IEnumerator Clock()
    {
        yield return new WaitForSeconds(33.5f);
        clock.Play();
        brild.Play();
        come.SetActive(true);
        SteamVR_Fade.Start(Color.clear, 0.1f);
        this.GetComponent<WhiteInOut>().enabled = false;
    }
}
