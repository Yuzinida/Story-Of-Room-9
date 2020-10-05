using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrackpadMove_continous_click : MonoBehaviour
{
    private Transform camTr;
    private CharacterController cc;
    Transform target; // 플레이어의 위치를 정한다.

    public float speed = 3.0f; // 플레이어가 앞 뒤로 움직이는 속도
    public float rotSpeed = 3.0f; // 플레이어가 회전하는 속도

    //public SteamVR_Input_Sources any;
    public SteamVR_Input_Sources leftHand = SteamVR_Input_Sources.LeftHand;
    public SteamVR_Input_Sources rightHand = SteamVR_Input_Sources.RightHand;
    public SteamVR_Action_Boolean trackPadClick;   // 트랙패드 눌렀을 때
    //public SteamVR_Action_Boolean trackPadTouch;    // 트랙패드 닿았을 때
    public SteamVR_Action_Vector2 trackPadPosition; // 트랙패드 터치 위치 / 클릭 위치

    private void Awake()
    {
        // 왼쪽 클릭, 오른쪽 클릭을 나눈다.
        trackPadClick = SteamVR_Actions.default_Teleport;
        //trackPadTouch = SteamVR_Actions.default_TrackpadTouch;
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
        // 왼쪽 트랙패드의 x축 기준 45도 회전을 한다.---------------------------------------------------------------
        if (trackPadClick.GetState(leftHand))
        {
            //Vector2 rot = trackPadPosition.GetAxis(any);
            Vector2 pos_leftHand = trackPadPosition.GetAxis(leftHand);
            int facingx = 0;
            int rotateDirect = 0;

            //Debug.LogFormat("left (x,y) = ({0},{1})", pos_leftHand.x, pos_leftHand.y);

            rotateDirect = (pos_leftHand.x > 0) ? 1 : -1;
            //facingx = ((pos_leftHand.x > Abs(0.3f)) && (pos_leftHand.y < Abs(0.8f))) ? rotateDirect : 0;
            facingx = ((pos_leftHand.x > 0.3f || pos_leftHand.x < -0.3f) 
                && (pos_leftHand.y < 0.8f || pos_leftHand.y > -0.8f)) ? rotateDirect : 0;
            
            //facingx = (rot.x > 0.0f) ? 1 : -1;
            RotateView(facingx);    // +-45도 회전

            //Debug.LogFormat("facingx : {0}", facingx);  // x 위치가 0보다 크면 1 작으면 -1이 나온다.
        }



        void RotateView(int facingx)
        {
            if (facingx > 0)
            {
                target.rotation = Quaternion.Euler(0, target.rotation.eulerAngles.y + 1f, 0);
            }
            if (facingx < 0)
            {
                target.rotation = Quaternion.Euler(0, target.rotation.eulerAngles.y - 1f, 0);
            }
            if (facingx == 0)
            {
                target.rotation = Quaternion.Euler(0, target.rotation.eulerAngles.y, 0);
            }
        }





        // 오른쪽 트랙패드의 y축 기준 앞뒤로 이동한다.---------------------------------------------------------------
        if (trackPadClick.GetState(rightHand))
        {
            Vector2 pos_rightHand = trackPadPosition.GetAxis(rightHand);    // 트랙패드의 터치 위치

            int facingy = 0;
            int moveDirect = 0;

            //Debug.LogFormat("right (x,y) = ({0},{1})", pos_rightHand.x, pos_rightHand.y);    


            moveDirect = (pos_rightHand.y > 0) ? 1 : -1;
            //facingy = ((pos_rightHand.x < Abs(0.5f)) && (pos_rightHand.y > Abs(0.5f))) ? moveDirect : 0;
            facingy = ((pos_rightHand.y > 0.3f || pos_rightHand.y < -0.3f)
                && (pos_rightHand.x < 0.8f || pos_rightHand.x > -0.8f)) ? moveDirect : 0;

            MoveLookAt(facingy);     // 앞 뒤 이동

            //Debug.LogFormat("facing : {0}", facingy);    // y 위치가 0보다 크면 1,작으면 -1이 나온다.
        }
    }
    void MoveLookAt(int facingy)
    {
        Vector3 heading = camTr.forward;    // 이동하는 방향

        heading.y = 0.0f;

        cc.SimpleMove(heading * speed * facingy);   // y 위치가 0보다 크면 카메라 기준으로 앞으로,작으면 뒤로 이동한다.
    }





    // 중복 함수
    public int Abs(int x)
    {
        return (x > 0) ? x : -x;
    }
    public double Abs(double x)
    {
        return (x > 0) ? x : -x;
    }


}
