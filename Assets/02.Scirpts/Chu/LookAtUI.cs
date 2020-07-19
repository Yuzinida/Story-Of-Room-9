using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtUI : MonoBehaviour
{
    Transform player;
   
    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        this.transform.LookAt(player);
    }
}
