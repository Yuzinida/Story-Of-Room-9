using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

//갓 사운드는 한번만 재생 가능
public class GodSound : MonoBehaviour
{
    AudioSource godSound;
    int countWalk = 0;
    int countEat = 0;
   public AudioClip eat;
   public AudioClip walk;
   private void Awake()
   {
       godSound = this.GetComponent<AudioSource>();
       // Test
       GodWalk();
   }
   public void GodWalk()
   {
       countWalk+=1;
       if(countWalk<=1){
            godSound.clip = walk;
            godSound.Play();

            Hashtable ht = new Hashtable();
            ht.Add("time",20f);
            ht.Add("path",iTweenPath.GetPath("GodWalk"));
            ht.Add("easetype",iTween.EaseType.linear);
            ht.Add("delay",3f);

            iTween.MoveTo(this.gameObject, ht);
       }
        
   }
   public void GodEat()
   {
       countEat+=1;
       if(countWalk<=1){
           godSound.clip = eat;
            godSound.Play();
       }
        
   }

}
