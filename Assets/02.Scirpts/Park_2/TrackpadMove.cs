using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrackpadMove : MonoBehaviour
{
    private Transform camTr;
    private CharacterController cc;
    Transform target; // 플레이어의 위치를 정한다.

    public float speed = 3.0f; // 플레이어가 앞 뒤로 움직이는 속도

    public SteamVR_Input_Sources any;
    public SteamVR_Action_Boolean trackPadClick;   // 트랙패드 눌렀을 때
    public SteamVR_Action_Boolean trackPadTouch;    // 트랙패드 닿았을 때
    public SteamVR_Action_Vector2 trackPadPosition; // 트랙패드 터치 위치 / 클릭 위치

    private void Awake()
    {
        trackPadClick = SteamVR_Actions.default_Teleport;
        trackPadTouch = SteamVR_Actions.default_TrackpadTouch;
        trackPadPosition = SteamVR_Actions.default_TrackpadPosition;
    }

    private void Start()
    {
        camTr = Camera.main.GetComponent<Transform>();  // 카메라의 방향을 정한다.
        cc = GetComponent<CharacterController>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();  // 타겟을 플레이어로 설정한다.
    }
    void Update()
    {
        // 트랙패드의 x축 기준 45도 회전을 한다.---------------------------------------------------------------
        if (trackPadClick.GetStateDown(any))
        {
            //Vector2 rot = trackPadPosition.GetAxis(any);
            Vector2 pos = trackPadPosition.GetAxis(any);

            int facingx = 0;
            facingx = (pos.x > 0.0f) ? 1 : -1;
            //facingx = (rot.x > 0.0f) ? 1 : -1;
            RotateView(facingx);    // +-45도 회전

            Debug.LogFormat("facingx : {0}", facingx);  // x 위치가 0보다 크면 1 작으면 -1이 나온다.
        }


        void RotateView(int facingx)
        {
            if (facingx > 0)
            {
                target.rotation = Quaternion.Euler(0, target.rotation.eulerAngles.y + 45f, 0);
            }

            if (facingx < 0)
            {
                target.rotation = Quaternion.Euler(0, target.rotation.eulerAngles.y + -45f, 0);
            }
        }


        // 트랙패드의 y축 기준 앞뒤로 이동한다.---------------------------------------------------------------
        if (trackPadTouch.GetState(any))
        {
            Vector2 pos = trackPadPosition.GetAxis(any);    // 트랙패드의 터치 위치

            int facingy = 0;
            facingy = (pos.y > 0.0f) ? 1 : -1;
            MoveLookAt(facingy);     // 앞 뒤 이동

            Debug.LogFormat("facing : {0}", facingy);    // y 위치가 0보다 크면 1,작으면 -1이 나온다.
        }
    }
    void MoveLookAt(int facingy)
    {

        Vector3 heading = camTr.forward;    // 이동하는 방향

        heading.y = 0.0f;

        cc.SimpleMove(heading * speed * facingy);   // y 위치가 0보다 크면 카메라 기준으로 앞으로,작으면 뒤로 이동한다.


    }


}
