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

    void Update()
    {
        TimeGo();
    }

    void TimeGo() // 콜라이더 미션 시간(10초)를 보여주는 타임바
    {
        if (progressbar.value < 1.0f)
        {
            progressbar.value = Mathf.MoveTowards(progressbar.value, 1.0f, Time.deltaTime);
        }
        else
        {
            loadtext.text = " 끝 ";
        }
    }

    public void ResetTimeBar()
    {
        progressbar.value = 0.0f;
        loadtext.text = "시간";
    }
}