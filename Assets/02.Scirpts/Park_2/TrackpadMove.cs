using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrackpadMove : MonoBehaviour
{
    private Transform camTr;
    private CharacterController cc;
    Transform target;

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
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {

        if (trackPadClick.GetStateDown(any))
        {
            Vector2 rot = trackPadPosition.GetAxis(any);

            int facingx = 0;
            facingx = (rot.x > 0.0f) ? 1 : -1;
            RotateView(facingx);

            Debug.Log(facingx);
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

        void RotateView(int facingx)
        {
            if(facingx > 0)
            {
                target.rotation = Quaternion.Euler(0,target.rotation.eulerAngles.y + 45f,0);
            }

            if(facingx < 0)
            {
                target.rotation = Quaternion.Euler(0,target.rotation.eulerAngles.y + -45f,0);
            }
        }
}
