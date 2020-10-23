using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanStart : MonoBehaviour
{
    GameObject quad;
    private void Start()
    {
        quad = GameObject.Find("Quad");
    }
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            

            if(quad.activeSelf == true)
            {
                quad.SetActive(false);
            }

            

        }
    }
}
