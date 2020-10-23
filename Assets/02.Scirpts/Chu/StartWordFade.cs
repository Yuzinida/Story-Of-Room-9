using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWordFade : MonoBehaviour
{
    CanvasGroup fadew, fadew2;
    // Start is called before the first frame update
    void Start()
    {
        fadew = this.GetComponent<CanvasGroup>();
        fadew2 = GameObject.Find("Guide").GetComponent<CanvasGroup>();
        StartCoroutine("FadeW");
    }

    
    IEnumerator FadeW()
    {
        yield return new WaitForSeconds(1f);
        for(float f = 0f; f < 10.9f; f+=0.1f)
        {
            fadew.alpha+=0.1f;
            yield return null;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            
            FadeF();
        }
        
    }
    void FadeF()
    {
        StartCoroutine("FadeFin");
    }

    IEnumerator FadeFin()
    {
        yield return new WaitForSeconds(0.5f);
       
        for(float f = 0f; f < 10.9f; f+=0.1f)
        {
            fadew2.alpha+=0.1f;
            yield return null;
        }
    }
}
