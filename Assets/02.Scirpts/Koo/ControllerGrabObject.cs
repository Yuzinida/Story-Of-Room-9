using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class ControllerGrabObject : MonoBehaviour
{
    public SteamVR_Input_Sources handType;          // 모두 사용, 왼손, 오른손
    public SteamVR_Behaviour_Pose controllerPose;   // 컨트롤러 정보
    public SteamVR_Action_Boolean grabAction;       // 그랩 액션

    private GameObject collidingObject;             // 현재 충돌 중인 객체
    private GameObject objectInHand;                // 플레이어가 잡은 객체


    void Update()
    {
        // 잡는 버튼을 누를 때
        if (grabAction.GetLastStateDown(handType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }
        // 잡는 버튼을 땔 때
        if (grabAction.GetLastStateUp(handType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }


    // 충돌이 시작 되는 순간
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grapable"))
        {
            Debug.Log("들어갔다");
            SetCollidingObject(other);
        }
    }

    // 충돌 중일 때
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Grapable"))
        {
            SetCollidingObject(other);
        }
    }

    // 충돌이 끝나는 순간
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Grapable"))
        {
            Debug.Log("나갔다");
            if (!collidingObject)
            {
                return;
            }
            collidingObject = null;
        }
    }

    // 충돌 중인 객체로 설정
    private void SetCollidingObject(Collider col)
    {
        if (collidingObject != null)
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    // 객체를 잡음
    private void GrabObject()
    {
        objectInHand = collidingObject; // 잡은 객체로 설정
        collidingObject = null;       // 충돌 객체 해제

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // FiexedJoint : 객체들을 하나로 묶어 고정시켜줌
    // breakForce : 조인트가 제거되도록 하기 위한 필요한 힘의 크기
    // breakTorque : 조인트가 제거되도록 하귀 위한 필요한 토크
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    // 객체를 놓음
    // controllerPose.GetVeloecity() => 컨트롤러의 속도
    // controllerPose.GetAugularVelocity() => 컨트롤러의 각속도

    private void ReleaseObject()
    {
        FixedJoint joint = GetComponent<FixedJoint>();
        if (joint != null)
        {
            joint.connectedBody = null;
            Destroy(joint);

            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
            objectInHand = null;
        }
    }
}


