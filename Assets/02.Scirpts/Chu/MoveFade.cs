using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MoveFade : MonoBehaviour
{
    Light dRoomLight;
    AudioSource dRoomSound;
    bool isLightOff = false;
    bool isSoundOff = false;
    private void Awake()
    {
        dRoomLight = GameObject.Find("DSpot Light").GetComponent<Light>();
        dRoomSound = GameObject.Find("BackgourndSound").GetComponent<AudioSource>();

        StartCoroutine("LightOff");
        StartCoroutine("SoundOff");
    }
    private void Update()
    {
        if(isLightOff == true)
        {
            dRoomLight.intensity-=0.2f;
            if(dRoomLight.intensity <= 0.0f)
            {
                isLightOff = false;      
            }
        }

        if(isSoundOff == true)
        {
            dRoomSound.volume-=0.001f;
            if(dRoomSound.volume <= 0.0f)
            {
                isSoundOff = false;      
            }
        }
    }
    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(24f);
        isLightOff = true;
    }

    IEnumerator SoundOff()
    {
        yield return new WaitForSeconds(28f);
        isSoundOff = true;
    }
}
