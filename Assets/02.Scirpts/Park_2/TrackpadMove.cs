using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrackpadMove : MonoBehaviour
{
    private Transform camTr;
    private CharacterController cc;

    public float speed = 3.0f;

    public SteamVR_Input_Sources any;
    public SteamVR_Action_Boolean trackPadClick ;
    public SteamVR_Action_Boolean trackPadTouch;
    public SteamVR_Action_Vector2 trackPadPosition;

    private void Awake() {
        trackPadClick = SteamVR_Actions.default_Teleport;
        trackPadTouch = SteamVR_Actions.default_TrackpadTouch;
        trackPadPosition = SteamVR_Actions.default_TrackpadPosition;
    }

    private void Start()
    {
        camTr = Camera.main.GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {

        if (trackPadClick.GetStateDown(any))
        {
            Debug.Log("트랙패드 클릭");
        }

        if (trackPadTouch.GetState(any))
        {
            Vector2 pos = trackPadPosition.GetAxis(any);

            int facing = 0;
            facing = (pos.y > 0.0f) ? 1 : -1;
            MoveLookAt(facing);

        }
    }
        void MoveLookAt(int facing)
        {

            Vector3 heading = camTr.forward;

            heading.y = 0.0f;

            cc.SimpleMove(heading * speed * facing);


        }
}
