using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    float hand = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
         Debug.Log("dd");

        hand += 1;
        print(hand);
    }
   

    // Update is called once per frame
    void Update()
    {
        if(hand>5)
        {
            SceneManager.LoadScene(2);
        }
    }
}
