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

    void TimeGo()
    {
        if (progressbar.value < 10f)
        {
            progressbar.value = Mathf.MoveTowards(progressbar.value, 10f, Time.deltaTime);
        }
        else
        {
            loadtext.text = " 끝 ";
        }
    }
}
