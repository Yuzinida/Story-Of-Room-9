using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroomLight : MonoBehaviour
{

    Light myLight;
    float interval = 0.3f;
    float minAngle = 38.3f;
    float maxAngle = 70f;
    float flowTime;
    public bool lightOn;


    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.type = LightType.Spot;

    }

    void Update()
    {
//관순과의 대화 종료


        if (lightOn)
        {
            flowTime = Mathf.Max(flowTime, 1);
            flowTime += Time.deltaTime;
            myLight.intensity = Mathf.PingPong(flowTime*38f, 100f);

            // myLight.spotAngle = Random.Range(minAngle, maxAngle);

            myLight.spotAngle = Mathf.Lerp(minAngle, maxAngle, flowTime);
            // if (flowTime ==1){

         //       DayChange();
          // }

        }

    }

    void DayChange()
    {
        maxAngle -= minAngle;
    }
}

