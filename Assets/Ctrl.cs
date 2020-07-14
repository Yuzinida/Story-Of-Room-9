using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Ctrl : MonoBehaviour
{
    public SteamVR_Behaviour_Pose RightHand = null;
    public SteamVR_Behaviour_Pose LeftHand = null;
    public SteamVR_Action_Boolean m_PullAction = null;
    private void Update()
    {
       Input();
    }

    private void Input()
    {
        //오른손
        if(m_PullAction.GetStateDown(RightHand.inputSource))
        {
            
        }     
        //왼손
        if(m_PullAction.GetStateDown(LeftHand.inputSource))
        {

        }   
    }
}
