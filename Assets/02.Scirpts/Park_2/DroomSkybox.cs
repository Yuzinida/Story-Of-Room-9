﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroomSkybox : MonoBehaviour
{
    public float Skyboxspeed = 2.0f;
    public float skyExposure = 0.0f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * Skyboxspeed);

 

    }

    public void LightOnOff()
    {
        skyExposure =  Mathf.Abs(Mathf.Sin(Time.time * Mathf.Deg2Rad * 50.0f)) * 0.5f;
        RenderSettings.skybox.SetFloat("_Exposure", skyExposure);
    }
}
