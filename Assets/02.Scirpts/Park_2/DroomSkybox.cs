using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroomSkybox : MonoBehaviour
{
    public float Skyboxspeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat ("_Rotation", Time.time * Skyboxspeed);
        RenderSettings.skybox.SetFloat("_Exposure", Mathf.Sin(Time.time * Mathf.Deg2Rad * 100) + 1);
    }
}
