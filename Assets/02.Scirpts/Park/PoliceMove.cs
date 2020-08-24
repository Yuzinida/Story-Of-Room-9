using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PoliceMove : MonoBehaviour
{
    AudioSource policeSound;
    GameObject godWalk;

    private void Start()
    {
        policeSound = this.GetComponent<AudioSource>();
        policeSound.Play();

        Hashtable ht = new Hashtable();
        ht.Add("time",5.0f);
        ht.Add("path",iTweenPath.GetPath("Step"));
        ht.Add("easetype",iTween.EaseType.linear);
        ht.Add("oncomplete","StepBack");
        ht.Add("oncompletetarget",this.gameObject);

        iTween.MoveTo(this.gameObject, ht);

        godWalk = GameObject.Find("UIController").transform.GetChild(0).gameObject;
    }
    void StepBack()
    {
        
        Invoke("StepBackStart",5f);  // 돌아가기시작하는 발자국 소리타이밍
        
    }
    void StepBackStart()
    {
        policeSound.Play();
        Hashtable ht2 = new Hashtable();
        ht2.Add("time",5.0f);
        ht2.Add("path",iTweenPath.GetPath("StepBack"));
        ht2.Add("easetype",iTween.EaseType.linear);
        ht2.Add("oncomplete","ActWalk");
        ht2.Add("oncompletetarget",this.gameObject);


        iTween.MoveTo(this.gameObject, ht2);
    }
    void ActWalk()
    {
        godWalk.SetActive(true);
        
        
    }
}
