using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    public Animator letterAnimator;

    // UIFADE showLetter;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //1번째 방법
        //animation으로 이 박스를 움직인다.

        // GetComponent<Rigidbody>().AddForce(transform.up*-800);
        this.GetComponent<Animator>().SetTrigger("LetterMove");
        StartCoroutine("Paper");
        
        // showLetter = GameObject.Find("LetterUI").GetComponent<UIFADE>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name=="floor")
        {
            this.GetComponent<AudioSource>().Play();
        }
        
    }

    IEnumerator Paper()
    {
        yield return new WaitForSeconds(1f);

        letterAnimator.SetTrigger("");  //ㅇㅕㄱㅣㅇㅛ
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.CompareTag("Hand"))
    //     {
    //         showLetter.Fadem();
    //         count += 1;
    //         if(count <= 1 )
    //         {
    //             GameObject.Find("KnockWall").GetComponent<Knock>().NextScene();
    //         }
            
    //     }
    // }
    // private void OnTriggerExit(Collider other)
    // {
    //     if(other.gameObject.CompareTag("Hand"))
    //     {
    //         showLetter.Fadem();
    //     }
    // }
    
}
