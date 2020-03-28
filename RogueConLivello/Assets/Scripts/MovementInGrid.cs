using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInGrid : MonoBehaviour
{
    public float speed = 1.0f;

    public static Vector3 endpos;
    private bool moving = false;

    void Start()
    {
        endpos = transform.position;
    }

    void Update()
    {
        if (moving && (transform.position == endpos))
            moving = false;

        if (!moving && Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up); //guarda d
            transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up); //guarda w
            moving = true;
            endpos = transform.position + Vector3.forward;
        }

        if (!moving && Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up); //guarda a
            transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up); //guarda s
            moving = true;
            endpos = transform.position + Vector3.back;
        }

        if (!moving && Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up); //guarda w
            transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up); //guarda a
            moving = true;
            endpos = transform.position + Vector3.left;
        }

        if (!moving && Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up); //guarda s
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up); //guarda d
            moving = true;
            endpos = transform.position + Vector3.right;
        }

        transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * speed);
    }
}
