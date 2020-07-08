using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMove : MonoBehaviour
{

    public Transform target;
    public Vector3 direction;
    public float speed = 3;
    public float rotSpeed = 5;

    //public float velocity;
    //public float accelaration;

    public void Update()
    {
        MoveToTarget();
    }
    public void MoveToTarget()
    {
        GameObject policecall = GameObject.FindWithTag("PoliceCome");
        target = policecall.transform;


        direction = (target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

        GetComponent<CharacterController>().SimpleMove(direction.normalized * speed); 


        //accelaration = 0.1f;
        //velocity = (velocity + accelaration * Time.deltaTime);
        //float distance = Vector3.Distance(target.position, transform.position);
        //if (distance <= 10.0f)
        //{
        //   this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
        //                                           transform.position.y + (direction.y * velocity),
        //                                             transform.position.z);
        // }

        //else
        //{
        //   velocity = 0.0f;
        //}
    }
}
