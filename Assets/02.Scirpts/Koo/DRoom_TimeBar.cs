using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DRoom_TimeBar : MonoBehaviour
{
    public Image progressbar;
    public Text barText;

    void Start()
    {

    }

    void Update()
    {
        TimeGo();
    }

    void TimeGo() // 콜라이더 미션 시간(10초)를 보여주는 타임바
    {
        if (progressbar.fillAmount < 10.0f)
        {
            progressbar.fillAmount = Mathf.MoveTowards(progressbar.fillAmount, 10.0f, Time.deltaTime);
        }
        else
        {
            barText.text = " 끝 ";
        }
    }

    public void ResetTimeBar()
    {
        progressbar.fillAmount = 0.0f;
        barText.text = "시간";
    }
}