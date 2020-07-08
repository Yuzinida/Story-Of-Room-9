using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knock : MonoBehaviour
{
    AudioSource knockWall;
    AudioSource knockRoomSound;
    AudioSource knockRoomSound2;
    bool knockRoom = false;
    int count = 0;
    private void Awake()
    {
        knockWall = this.GetComponent<AudioSource>();
        knockRoomSound = GameObject.Find("KnockRoom").GetComponent<AudioSource>();
        knockRoomSound2 = GameObject.Find("KnockRoom2").GetComponent<AudioSource>();
            
    }
    private void Start()
    {
        NextScene();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hand") ){
            knockWall.Play();
            count += 1;
            if(knockRoom == false)
            {
                count = 0;
            }
            else if(knockRoom == true && count >=4 )
            {
                count = 0;
                knockRoomSound.Play();

            }
        }
    }
    public void NextScene()
    {
        knockRoom = true;
        Invoke("KnockRoom",15f);
        Invoke("KnockRoom",20f);
    }
    void KnockRoom()
    {
        knockRoomSound2.Play();
    }
}
