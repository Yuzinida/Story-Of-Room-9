using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabAction : MonoBehaviour
{
    public SteamVR_Input_Sources handType;          // 모두 사용, 왼손, 오른손
    public SteamVR_Action_Boolean teleportAction;   // 텔레포트 액션
    public SteamVR_Action_Boolean grabAction;       // 그랩 액션


//     void Update()
//     {
//         if(GetTeleportDown()){
//             Debug.Log("Teleport" + handType);
//         }
//         if(GetGrab()){
//             Debug.Log("Grab" + handType);
//         }
//     }

//     // 텔레포트가 활성화되면 true 반환
//     public bool GetTeleportDown(){
//         return teleportAction.GetStateDown(handType);
//     }

    // 잡기 액션이 활성화되어 있으면 true 반환
    public bool GetGrab(){
        return grabAction.GetState(handType);
    }
}
