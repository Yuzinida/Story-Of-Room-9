using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomButton : MonoBehaviour
{
    public UIFADE fadeUI;
    Transform touchTwo;
    Transform player;
    GodSound godSound;
    
    GameObject police;
    int count =0 ;
    
    private void Start()
    {
        touchTwo = GameObject.Find("Touch_two").GetComponent<Transform>();
        godSound = GameObject.Find("GodSounds").GetComponent<GodSound>();
        police = GameObject.Find("Police_W").transform.GetChild(0).gameObject;
    }
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        touchTwo.LookAt(player);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            fadeUI.Fadem();
            this.GetComponent<UIFADE>().Fadem();
            if(this.gameObject.name == "Touch_one")
            {
                godSound.GodWalk();
            }
            else if(this.gameObject.name == "Touch_two")
            {
                Invoke("ActPolice",15f);
                godSound.GodEat();
            }
            else if(this.gameObject.name == "Touch_Letter")
            {
                count += 1;
            if(count <= 1 )
            {
                GameObject.Find("KnockWall").GetComponent<Knock>().NextScene();
            }
            }
        }
    }
    void ActPolice()
    {
        police.SetActive(true);
    }
    

    
}
