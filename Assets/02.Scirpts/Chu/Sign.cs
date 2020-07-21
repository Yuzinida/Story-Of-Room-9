using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sign : MonoBehaviour
{
    
    Transform line;
    Renderer scolor;
    
    public  GameObject name;
       
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            line = name.transform;      
            line.position = new Vector3(-0.207f,-0.863f,0.568f);
            line.rotation = Quaternion.Euler(25.6f,0,0);
            
            for(int i=0; i<line.childCount; i++)
            {
                Renderer renderer = line.GetChild(i).GetComponent<Renderer>();
                renderer.material.color = Color.black;
            }
        }
        StartCoroutine("Credit");
    }

    IEnumerator Credit()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(8);
    }
}
