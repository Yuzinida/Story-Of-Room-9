using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sign : MonoBehaviour
{
    
    Transform line;
    Renderer scolor;
    Vector3 reposition;
    
    public  GameObject name;
       
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hand"))
        {
            line = name.transform;      
            line.position = new Vector3(0.13f,-0.37f,0.768f);
            line.rotation = Quaternion.Euler(25.6f,0,0);
            
            for(int i=0; i<line.childCount; i++)
            {
                reposition = line.GetChild(i).transform.position;
                reposition.z = 0f;
                // Renderer renderer = line.GetChild(i).GetComponent<Renderer>();
                // renderer.material.color = Color.black;
            }
            // Ending();
        }
        
    }

    void Ending()
    {
        StartCoroutine("Credit");
    }
    IEnumerator Credit()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(8);
    }
}
