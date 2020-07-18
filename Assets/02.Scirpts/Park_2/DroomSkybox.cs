using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroomSkybox : MonoBehaviour
{
    public float Skyboxspeed = 2;


    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * Skyboxspeed);

        //관순과의 대화가 끝난다면
        // if (){

        //LightOnOff();
        // }


    }

    void LightOnOff()
    {
        RenderSettings.skybox.SetFloat("_Exposure", Mathf.Sin(Time.time * Mathf.Deg2Rad * 70) + 1);
    }
}
