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
        audioSource = GetComponent<AudioSource>();
        // // 뮤트: true일 경우 소리가 나지 않음
        // audioSource.mute = false;
        // // 루핑: true일 경우 반복 재생
        // audioSource.loop = false;
        // // 자동 재생: true일 경우 자동 재생
        // audioSource.playOnAwake = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("독방 안에 등장!");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("독방 안에서 스테이");
        audioSource.Stop();
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hand")
        {
            Debug.Log("독방 나감. 경고음 출동!!");
            audioSource.Play();
            Debug.Log("오디오 나와랏!!");
            //audioSource.Stop();
        }
    }
}
