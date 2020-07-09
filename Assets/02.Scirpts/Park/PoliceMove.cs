using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PoliceMove : MonoBehaviour
{

    public Transform target;
    public Vector3 direction;


    public float speed = 3;
    public float rotSpeed = 5;
    public AudioSource policesound;

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

        //오브젝트가 지역에 도착하고 3초 후에 다시 원래 자리로 돌아간다
    }

}
