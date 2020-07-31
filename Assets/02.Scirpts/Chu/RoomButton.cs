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
    int countW=0;
    int countE=0;

    
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
            if(this.gameObject.name == "Touch_one"&countW==0)
            {
                countW ++;
                godSound.GodWalk();
                fadeUI.Fadem();
                this.GetComponent<UIFADE>().Fadem();
            }
            else if(this.gameObject.name == "Touch_two"&countE==0)
            {
                countE ++;
                godSound.GodEat();
                fadeUI.Fadem();
                this.GetComponent<UIFADE>().Fadem();
                Invoke("ActPolice",6f);
                
            }
            
        }
    }
    void ActPolice()
    {
        police.SetActive(true);
    }
    

    
}
