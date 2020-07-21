using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DRoom_BeforeDialogue : MonoBehaviour
{
    public GameObject colliderTutorialUI, colliderSmall, colliderBig, timebar, timeLoad;
    public Text text_Tutorial;

    void Start()
    {
        // UI와 판넬 입력
        //colliderTutorialUI = GameObject.Find("colliderTutorialUI");
        //colliderSmall = GameObject.Find("colliderSmall");
        //colliderBig = GameObject.Find("colliderBig");
        timebar = GameObject.Find("Canvas_Timebar");
        timeLoad = GameObject.Find("TimeLoad");


        colliderTutorialUI.SetActive(false);
        colliderSmall.SetActive(false);
        colliderBig.SetActive(false);
        timebar.SetActive(false);
        timeLoad.SetActive(false);
    }
    void Update()
    {
        StartCoroutine("Door_Tutorial_Collider_Tutorial");
    }


    // public void DRoom_BeforeDialouge_func()
    // {
    //     StartCoroutine("Door_Tutorial_Collider_Tutorial");
    // }


    IEnumerator Door_Tutorial_Collider_Tutorial()
    {
        // 1. 문 열리기 애니메이션 & 소리 시작
        //colliderTutorialUI.SetActive(false);


        yield return new WaitForSeconds(5.0f);
        // 2. 콜라이더 시작 튜토리얼 보여주기
        colliderTutorialUI.SetActive(true);
        text_Tutorial.text = "- 독방 체험 미션 -\n자리에서 일어나 파란색 표시선 안으로 들어가 주시길 바랍니다.\n10초 간 표시선 밖으로 넘어가면 경고음이 울리면 재시작됩니다.\n미션이 끝나더라도, 자리에 앉지 마십시오.";


        // 3. 독방 미션 시작 : 콜라이더 활성화
        yield return new WaitForSeconds(4.0f);
        colliderTutorialUI.SetActive(false);
        Collider_func();


        yield return new WaitForSeconds(5.0f);
        colliderSmall.SetActive(false);
        timebar.SetActive(false);
        timeLoad.SetActive(false);
        // 4. 콜라이더 끝 튜토리얼 보여주기
        colliderBig.SetActive(true);
        colliderTutorialUI.SetActive(true);
        text_Tutorial.text = "- 독방 체험 미션 -\n독방은 실제 사람이 겨우 서 있을 정도 크기로 독립운동가를 가둔 일제의 고문 도구입니다. 2∼3일 갇혀 있으면 근육이 찢어지는 고통 끝에 전신이 마비된다고 합니다.";

        // 5. 유관순 열사와 대화 시작
    }



    void Collider_func()
    {
        colliderSmall.SetActive(true);
        timebar.SetActive(true);
        timeLoad.SetActive(true);



    }


}
