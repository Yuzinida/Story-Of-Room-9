using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up*-800);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name=="floor")
        {
            this.GetComponent<AudioSource>().Play();
        }
    }
}
