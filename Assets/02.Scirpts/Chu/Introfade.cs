using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class Introfade : MonoBehaviour
{
    //Light introLight;
    AudioSource openDoor,closeDoor;
    private void Awake()
    {
        //introLight = GameObject.Find("Spot Light").GetComponent<Light>();
        openDoor = GameObject.Find("OpenDoor").GetComponent<AudioSource>();
        closeDoor = GameObject.Find("CloseDoor").GetComponent<AudioSource>();

        //StartCoroutine("LightOn");
        StartCoroutine("LightOff");
        StartCoroutine("NextSceneRoom");
    }

    // IEnumerator LightOn()
    // {
    //     yield return new WaitForSeconds(3.5f);

    //     introLight.enabled=true;
    // }
    IEnumerator LightOff()
    {
        yield return new WaitForSeconds(7f);
        openDoor.Play();
        closeDoor.Play();
        //introLight.enabled=false;
    }
    IEnumerator NextSceneRoom()
    {
        yield return new WaitForSeconds(12f);
        SceneManager.LoadScene(3);
    }
    
}
