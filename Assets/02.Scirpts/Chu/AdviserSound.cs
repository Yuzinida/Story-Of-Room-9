using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdviserSound : MonoBehaviour
{
    AudioSource dRoom,rainStart;
    void Start()
    {
        Hashtable ht = new Hashtable();
        ht.Add("time",25f);
        ht.Add("path",iTweenPath.GetPath("Adviser"));
        ht.Add("easetype",iTween.EaseType.linear);

        iTween.MoveTo(this.gameObject, ht);

        dRoom = GameObject.Find("DRoom").GetComponent<AudioSource>();
        rainStart = GameObject.Find("RainStart").GetComponent<AudioSource>();

        StartCoroutine("DRoomSound");

    }

    IEnumerator DRoomSound()
    {
        yield return new WaitForSeconds(25f);

        dRoom.Play();

        yield return new WaitForSeconds(10f);

        rainStart.Play();   

        yield return new WaitForSeconds(9f);

        SceneManager.LoadScene(5);

    }

}
