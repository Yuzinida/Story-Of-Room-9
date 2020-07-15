using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomUI : MonoBehaviour
{
    UIFADE startUI;
    void Start()
    {
        startUI = this.GetComponent<UIFADE>();
        

        StartCoroutine("StartOutUI");
    }
    IEnumerator StartOutUI()
    {
        yield return new WaitForSeconds(4f);
        startUI.Fadem();
        yield return new WaitForSeconds(5f);
        startUI.Fadem();
    }
}
