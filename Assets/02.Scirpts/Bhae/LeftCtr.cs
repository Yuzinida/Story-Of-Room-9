﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftCtr : MonoBehaviour
{
    public Sprite[] animatedImage;
    public Image animateImageObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animateImageObj.sprite = animatedImage [(int)(Time.time*30)%animatedImage.Length];
    }
}
