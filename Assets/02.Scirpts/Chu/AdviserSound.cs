using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdviserSound : MonoBehaviour
{
    AudioSource dRoom;
    void Start()
    {
        Hashtable ht = new Hashtable();
        ht.Add("time",25f);
        ht.Add("path",iTweenPath.GetPath("Adviser"));
        ht.Add("easetype",iTween.EaseType.linear);

        iTween.MoveTo(this.gameObject, ht);

        dRoom = GameObject.Find("DRoom").GetComponent<AudioSource>();

        StartCoroutine("DRoomSound");

    }

    IEnumerator DRoomSound()
    {
        yield return new WaitForSeconds(25f);

        dRoom.Play();
    }

}
