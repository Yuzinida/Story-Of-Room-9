using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Material material;
    public float scrollSpeed = 0.2f;
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = Vector2.up;

        material.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
