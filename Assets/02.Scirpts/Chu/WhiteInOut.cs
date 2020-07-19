using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class WhiteInOut : MonoBehaviour
{
    Transform player;
    int count = 0;
    int count2 = 0;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        if(player.rotation.y >= 0.3f || player.rotation.x >= 0.3f || player.rotation.y <= -0.3f || player.rotation.x <= -0.3f)
        {   
            count += 1;
            count2 = 0;
            if(count <= 1)
            {
                SteamVR_Fade.Start(new Color(1,1,1,0.2f), 5f);
            }
        }
        else
        {   
            count2 += 1;
            count = 0;
            if(count2 <= 1)
            {
                SteamVR_Fade.Start(new Color(1,1,1,0.01f), 3f);
            }
        }
    }
}
