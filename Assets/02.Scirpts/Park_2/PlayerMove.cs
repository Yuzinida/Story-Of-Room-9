using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class PlayerMove : MonoBehaviour
{
  
   //컨트롤러 정의
    public SteamVR_Input_Sources any;


    public SteamVR_Action_Boolean trackPadClick = SteamVR_Actions.default_Teleport;
    public SteamVR_Action_Boolean trackPadTouch = SteamVR_Actions.default_TrackpadTouch;
    public SteamVR_Action_Vector2 trackPadPosition = SteamVR_Actions.default_TrackpadPosition;


    void Update()
    {
        if (trackPadClick.GetStateDown(any))
        {
            Debug.Log("트랙패드 클릭");
        }

        if (trackPadTouch.GetState(any))
        {
            Vector2 pos = trackPadPosition.GetAxis(any);
            Debug.Log($"터치 포스 x = {pos.x}, y = {pos.y}");

        }
        //코드가 중복되어서 삭제함
    }
}