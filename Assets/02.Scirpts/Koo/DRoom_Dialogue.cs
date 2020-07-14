/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using Valve.VR;

[System.Serializable]

// 대사와 이미지를 가져온다.
public class Dialogue
{

    [TextArea] // 한 줄이 아닌 여러 줄 쓸 수 있게 만든다.
    public string dialogue; // text를 가져온다.
    //public Sprite cg; // 이미지 가져오기 (오디오 가져올 수도 있음)
    public AudioSource audioSource; // 오디오 가져오기

    //public Canvas 

}
public class DRoom_Dialogue : MonoBehaviour
{
    //[SerializeField] private SpriteRenderer sprite_StandingCG; // 이미지

    [SerializeField] private Canvas Canvas_UI; // 1. UI -------------------------
    [SerializeField] private AudioSource sound; // 2. 소리
    [SerializeField] private SpriteRenderer sprite_DialogueBox; // 3. 다이어로그 창
    [SerializeField] private Text txt_Dialogue; // 4.텍스트



    private bool isDialogue = false; // 대화가 진행중인지 알려주는 변수
    private int count = 0; // 대화 번호 알려준다.

    [SerializeField] private Dialogue[] dialogue; // 대화를 배열로 가져온다.



    // 대화가 넘어갈 때마다 대화창 등이 활성/ 비활성화 되도록 만들어준다.

    // public void ShowDialogue()
    // {
    //     SoundOnOff(true);
    //     count = 0;
    //     NextDialogue();
    // }


        private void UIOnOff(bool _flag)
    {
        Canvas_UI.gameObject.SetActive(_flag); // 1. UI
    }

    private void SoundOnOff(bool _flag)
    {
        //sprite_StandingCG.gameObject.SetActive(_flag);
        sprite_DialogueBox.gameObject.SetActive(_flag); // 대화창
        txt_Dialogue.gameObject.SetActive(_flag); // 1. 텍스트
        isDialogue = _flag;
    }



    private void NextDialogue()
    {
        Canvas_UI.Button.text = dialogue[count].dialogue; // 1. 텍스트
        // 2. 사운드
        // 3. UI
        //sprite_StandingCG.sprite = dialogue[count].cg;
        count ++;
    }

    void Update()
    {
        if(isDialogue)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(count<dialogue.Length)
                {
                    NextDialogue();
                }
                else
                    SoundOnOff(false);
            }
        }
    }
}
*/