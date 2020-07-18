using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRoom_Collider : MonoBehaviour
{
    // 박스 밖으로 넘어가면 소리가 나도록 한다. 
    // 이때 10 정도의 시간이 지나도록 한다.
    AudioSource audioSource;
    void Start()
    {
        // 오디오 소스 생성해서 추가
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        // // 뮤트: true일 경우 소리가 나지 않음
        // audioSource.mute = false;
        // // 루핑: true일 경우 반복 재생
        // audioSource.loop = false;
        // // 자동 재생: true일 경우 자동 재생
        // audioSource.playOnAwake = false;

    }

    // Collider 컴포넌트의 is Trigger가 false인 상태로 충돌을 시작했을 때
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("독방 안에 등장!");
    }



    // Collider 컴포넌트의 is Trigger가 false인 상태로 충돌중일 때
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("독방 안에서 스테이");
        //audioSource.Stop();
    }



    // Collider 컴포넌트의 is Trigger가 false인 상태로 충돌이 끝났을 때
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("독방 나감. 경고음 출동!!");
        audioSource.Play();
        //audioSource.Stop();

    }




}
