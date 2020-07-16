using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DrawMgr : MonoBehaviour
{
    [Header("Controller")]
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    public SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    public SteamVR_Action_Pose pose = SteamVR_Actions.default_Pose;

    [Header("Line")]
    public float lineWid = 0.01f;
    public Color lineColor = new Color(1,1,1);

    private LineRenderer line;

    void Start()
    {
        
    }
    void Update()
    {
        //트리거 버튼을 클릭했을 때 새로운 라인랜더러를 포함한 객체를 생성
        if(trigger.GetStateDown(rightHand))
        {
            CreateLineObject();
        }

        //트리거 버튼을 계속 클릭하고 있을 때 라인랜더러의 노드를 추가
        if(trigger.GetState(rightHand))
        {
            Vector3 position = pose.GetLastLocalPosition(rightHand);
            ++line.positionCount;
            line.SetPosition(line.positionCount - 1, position);
        }
    }
    void CreateLineObject()
    {
        //라인렌더러를 추가할 게임오브젝트 생성
        GameObject lineObject = new GameObject("Line");
        line = lineObject.AddComponent<LineRenderer>();

        //라인렌더러에 연결할 머테리얼 생성
        Material mt = new Material(Shader.Find("Unlit/Color"));
        mt.color = lineColor;

        line.material = mt;
        line.useWorldSpace = false;

        //라인의 끝부분을 부드럽게 하기 위한 버텍스의 개수 설정
        line.numCapVertices = 20;

        //라인랜더러의 너비 설정
        line.widthMultiplier = 0.1f;
        line.startWidth = lineWid;
        line.endWidth = lineWid;

        line.positionCount =1;

        Vector3 position =pose.GetLastLocalPosition(rightHand);
        line.SetPosition(0,position);

    }

}
