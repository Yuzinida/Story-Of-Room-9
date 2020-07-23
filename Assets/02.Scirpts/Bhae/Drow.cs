using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas1;
    public GameObject canvas2;
    GameObject sign;
    DrawMgr draw;
    
    private void Start()
    {
        sign = GameObject.Find("Sign").transform.GetChild(0).gameObject;
        draw = GameObject.Find("Controller (right)").GetComponent<DrawMgr>();
        StartCoroutine("Sign");
    }

    IEnumerator Sign()
    {
        yield return new WaitForSeconds(29f);
        draw.enabled = true;
        sign.SetActive(true);
        canvas1.SetActive (false);
        canvas2.SetActive (true);
    }

}
