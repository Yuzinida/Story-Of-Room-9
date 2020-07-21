using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DRoom_TimeBar : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;

    void Start()
    {
    }

    void TimeGo() // 콜라이더 미션 시간(10초)를 보여주는 타임바
    {
        if (progressbar.value < 1f)
        {
            progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
        }
        else
        {
            loadtext.text = " 끝 ";
        }
    }
}