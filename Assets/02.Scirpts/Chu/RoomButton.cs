using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
    UIFADE uIFADE;
    
    private void Start()
    {
        uIFADE = GameObject.Find("WalkUI").GetComponent<UIFADE>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            uIFADE.Fadem();
            this.GetComponent<UIFADE>().Fadem();
                
        }
    }
    

    
}
