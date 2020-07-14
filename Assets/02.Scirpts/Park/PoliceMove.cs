using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PoliceMove : MonoBehaviour
{
    AudioSource policeSound;

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
    }
    void StepBack()
    {
        
        Invoke("StepBackStart",6f);  // 지켜보는 시간 조정
        
    }
    void StepBackStart()
    {
        policeSound.Play();
        Hashtable ht2 = new Hashtable();
        ht2.Add("time",5.0f);
        ht2.Add("path",iTweenPath.GetPath("StepBack"));
        ht2.Add("easetype",iTween.EaseType.linear);

        iTween.MoveTo(this.gameObject, ht2);
    }
}
