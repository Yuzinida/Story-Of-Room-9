using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCall : MonoBehaviour
{
    public PoliceMove policeMove;

    void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag ("Hand"))
		{
            policeMove.enabled = true;
            GameObject.Find("PoliceCallArea").SetActive(false);
            

        }

    }
}
