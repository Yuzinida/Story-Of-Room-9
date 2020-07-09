using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{
    private SteamVR_Behaviour_Pose pose;
    private SteamVR_Input_Sources hand;
    private LineRenderer line;

    public  SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;
    
    //라인의 최대 유효거리
    public float maxDistance = 30.0f;

    //라인의 색상
    public Color color = Color.blue;
    public Color clickedColor = Color.green;

    //레이캐스트를 위한 변수 선언
    private RaycastHit hit;
    //컨트롤러의 Transform 컴포넌트를 저장할 변수
    private Transform tr;

    //이벤트를 전달할 객체의 저장 변수
    private GameObject prevObject;
    private GameObject currObject;

    void Start()
    {
        tr =GetComponent<Transform>();

        pose = GetComponent<SteamVR_Behaviour_Pose>();

        hand = pose.inputSource;

        CreateLineRenderer();
    }

    void CreateLineRenderer()
    {
        line = this.gameObject.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.receiveShadows =false;

        //시작점과 끝점 위치 설정
        line.positionCount = 2;
        line.SetPosition(0, Vector3.zero);
        line.SetPosition(1, new Vector3(0, 0, maxDistance));

        //라인의 너비 설정
        line.startWidth = 0.03f;
        line.endWidth = 0.005f;

        //라인의 머티리얼 및 색상 설정
        line.material = new Material(Shader.Find("Unlit/Color"));
        line.material.color = this.color;
    }

    void Update()
    {
        if (Physics.Raycast(tr.position, tr.forward, out hit, maxDistance))
        {
            line.SetPosition(1, new Vector3(0,0,hit.distance));

            //현재 객체와 이전 객체가 다른 경우
            if(currObject !=prevObject)
            {
                ExecuteEvents.Execute(currObject,new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
                // 이전 객체에 PointerExit 이벤트 전달
                ExecuteEvents.Execute(prevObject,new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);

                prevObject = currObject;
            }

            //트리거 버튼을 클릭했을 경우에 클릭 이벤트를 발생시킴
            if(trigger.GetStateDown(hand))
            {
                ExecuteEvents.Execute(currObject,new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
            }
        }
        else
        {
            if(prevObject != null)
            {
                ExecuteEvents.Execute(prevObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
                prevObject = null;
            }
        }
    }
}
