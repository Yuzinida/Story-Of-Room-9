using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas1;
    public GameObject canvas2;
    GameObject sign;
    
    private void Start()
    {
        sign = GameObject.Find("Sign").transform.GetChild(0).gameObject;
        StartCoroutine("Sign");
    }

    IEnumerator Sign()
    {
        yield return new WaitForSeconds(29f);
        sign.SetActive(true);
        canvas1.SetActive (false);
        canvas2.SetActive (true);
    }

}
