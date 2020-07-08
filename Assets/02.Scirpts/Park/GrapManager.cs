using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrapManager : MonoBehaviour
{

    private SteamVR_Input_Sources hand = SteamVR_Input_Sources.Any;
    private SteamVR_Action_Boolean trigger = SteamVR_Actions.default_InteractUI;

    public float speed = 10.0f;

    private Transform grabObject;

    private bool isTouched = false;

    void Start()
    {
        
    }


    void Update()
    {
        if (isTouched == true && trigger.GetStateDown(hand))
        {
            grabObject.SetParent(this.transform);
            grabObject.GetComponent<Rigidbody>().isKinematic = true;        
        }

        if (isTouched == true && trigger.GetStateUp(hand))
        {
            grabObject.SetParent(null);
            Vector3 _velocity = GetComponent<SteamVR_Behaviour_Pose>().GetVelocity();
            grabObject.GetComponent<Rigidbody>().isKinematic = false;
            grabObject.GetComponent<Rigidbody>().velocity = _velocity * speed;


            isTouched  = false;
            grabObject = null;
        }

    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Grapable"))
        {
            isTouched = true;
            grabObject = other.transform;
        }
    }
}
