﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutYourHandsUp : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas1;
    public GameObject canvas2;

    void Start()
    {

     Invoke("canvers",30f);
    }

    void canvers()
    {
canvas1.SetActive (false);
canvas2.SetActive (true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}