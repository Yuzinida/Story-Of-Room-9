using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    UIFADE showLetter;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.up*-800);
        showLetter = GameObject.Find("LetterUI").GetComponent<UIFADE>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name=="floor")
        {
            this.GetComponent<AudioSource>().Play();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            showLetter.Fadem();
            count += 1;
            if(count <= 1 )
            {
                GameObject.Find("KnockWall").GetComponent<Knock>().NextScene();
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Hand"))
        {
            showLetter.Fadem();
        }
    }
    
}
