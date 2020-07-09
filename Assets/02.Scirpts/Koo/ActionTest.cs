// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// //using Valve.VR;

// public class ActionTest : MonoBehaviour
// {
//     public streamVR_Input_Source handType;          // 모두 사용, 왼손, 오른손
//     public streamVR_Input_Boolean teleportAction;   // 텔레포트 액션
//     public streamVR_Input_Boolean grabAction;       // 그랩 액션


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

//     // 잡기 액션이 활성화되어 있으면 true 반환
//     public bool GetGrab(){
//         return grabAction.GetState(handType);
//     }
// }
