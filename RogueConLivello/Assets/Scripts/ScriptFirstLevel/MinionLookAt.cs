using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionLookAt : MonoBehaviour
{

    public Transform target;
    private float speed = 1f;
    //private Vector3 speedRot = Vector3.up;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void MoveSlime()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void Update()
    {
        MoveSlime();
    }
}
