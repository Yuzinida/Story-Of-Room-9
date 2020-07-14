using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Fade : MonoBehaviour
{
   
    void FadeOutC()
    {
        //set start color
         SteamVR_Fade.Start(Color.clear, 0f);
         //set and start fade to
         SteamVR_Fade.Start(Color.black, 1f);
    }
    void FadeInC()
    {
        //set start color
         SteamVR_Fade.Start(Color.black, 1f);
         //set and start fade to
         SteamVR_Fade.Start(Color.clear, 0f);
    }
}
