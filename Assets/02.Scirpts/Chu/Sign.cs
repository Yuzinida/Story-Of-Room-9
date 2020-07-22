using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class Sign : MonoBehaviour
{
    
    Transform line;
    Renderer scolor;
    Vector3 reposition;
    Transform target;
    
    public  GameObject name;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        this.transform.LookAt(target);
    }
       
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            line = name.transform;      
            line.position = new Vector3(0.042f,0.15f,1.106f);
            line.rotation = Quaternion.Euler(25.6f,0,0);
            
            for(int i=0; i<line.childCount; i++)
            {
                reposition = line.GetChild(i).transform.position;
                reposition.z = 0f;
                // Renderer renderer = line.GetChild(i).GetComponent<Renderer>();
                // renderer.material.color = Color.black;
            }
            Ending();
        }
        
    }

    void Ending()
    {
        StartCoroutine("Credit");
    }
    IEnumerator Credit()
    {
        yield return new WaitForSeconds(3f);
        //set start color
        SteamVR_Fade.Start(Color.clear, 0f);
        //set and start fade to
        SteamVR_Fade.Start(Color.black, 2f);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(8);
    }
}
