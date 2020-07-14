using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowlSound : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name=="floor")
        {
            this.GetComponent<AudioSource>().Play();
        }
    }
}
