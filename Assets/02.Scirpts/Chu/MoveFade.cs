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
    GameObject left,right,ad;
    private void Awake()
    {
        dRoomLight = GameObject.Find("DSpot Light").GetComponent<Light>();
        dRoomSound = GameObject.Find("BackgourndSound").GetComponent<AudioSource>();
        left = this.transform.GetChild(0).gameObject;
        right = this.transform.GetChild(1).gameObject;
        ad = GameObject.Find("StartAd").transform.GetChild(0).gameObject;

        StartCoroutine("StartF");
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

    IEnumerator StartF()
    {
        yield return new WaitForSeconds(2f);
        left.SetActive(true);
        right.SetActive(true);
        ad.SetActive(true);
    }
    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(26f);
        isLightOff = true;
    }

    IEnumerator SoundOff()
    {
        yield return new WaitForSeconds(30f);
        isSoundOff = true;
    }
}
