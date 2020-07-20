using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScript : MonoBehaviour
{
    Transform target;
    AudioSource final,manse;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        final = GameObject.Find("Ending").GetComponent<AudioSource>();
        manse = GameObject.Find("Manse").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            final.Stop();
            manse.Play();
            this.gameObject.SetActive(false);
        }
    }
}
