using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutYourHandsUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas1;
    public GameObject canvas2;

    void Start()
    {
        StartCoroutine("canvers");  
    }

    IEnumerator canvers()
    {
        yield return new WaitForSeconds(33f);
        canvas1.SetActive (false);
        canvas2.SetActive (true);
        GameObject.Find("Canvas2").GetComponent<UIFADE>().Fadem();

    }

}
