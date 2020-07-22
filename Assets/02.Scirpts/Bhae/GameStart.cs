using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class GameStart : MonoBehaviour
{
   public void StartGame()
   {
       StartCoroutine("Delay");
       
   }
   IEnumerator Delay()
   {
       //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, 2f);

       yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
   }
}
