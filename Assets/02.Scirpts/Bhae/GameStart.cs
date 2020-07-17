using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
   public void StartGame()
   {
       StartCoroutine("Delay");
       
   }
   IEnumerator Delay()
   {
       yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
   }
}
