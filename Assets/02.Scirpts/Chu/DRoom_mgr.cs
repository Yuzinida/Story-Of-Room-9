using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DRoom_mgr : MonoBehaviour
{
    UIFADE dCanvas;
    GameObject startUI;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine("PlayDRoom");
        dCanvas = GameObject.Find("DRoom_Tutorial_Can").GetComponent<UIFADE>();
        startUI = GameObject.Find("PlayerDialogue").transform.GetChild(0).gameObject;
    }
    IEnumerator PlayDRoom()
    {
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, 0.1f);

        yield return new WaitForSeconds(2.5f);
        //set start color
        SteamVR_Fade.Start(Color.black, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.clear, 3f);

        yield return new WaitForSeconds(10.5f);

        dCanvas.Fadem();

        yield return new WaitForSeconds(4f);

        dCanvas.Fadem();

        yield return new WaitForSeconds(10f);

        startUI.SetActive(true);
    }

}
