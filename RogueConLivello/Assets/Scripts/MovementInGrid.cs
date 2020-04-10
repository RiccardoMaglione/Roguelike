using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInGrid : MonoBehaviour
{
    public float speed = 1.0f;

    public static Vector3 endpos;
    private bool moving = false;

    public float acceleration;
    float speedInitial;
    public float friction = 10;

    void Start()
    {
        endpos = transform.position;
        speedInitial = speed;
    }

    void Update()
    {
        if (moving && (transform.position == endpos))
            moving = false;

        if (!moving && Input.GetKey(GameManagerScript.GM.forward))      //w
        {
            speed = speedInitial;
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up); //guarda d
            transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up); //guarda w
            moving = true;
            endpos = transform.position + Vector3.forward * WallTrigger.WallW;
        }

        if (!moving && Input.GetKey(GameManagerScript.GM.backward))     //s
        {
            speed = speedInitial;
            //transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up); //guarda a
            transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up); //guarda s
            moving = true;
            endpos = transform.position + Vector3.back * WallTrigger.WallS;
        }

        if (!moving && Input.GetKey(GameManagerScript.GM.left))     //a
        {
            speed = speedInitial;
            //transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up); //guarda w
            transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up); //guarda a
            moving = true;
            endpos = transform.position + Vector3.left * WallTrigger.WallA;
        }

        if (!moving && Input.GetKey(GameManagerScript.GM.right))     //d
        {
            speed = speedInitial;
            //transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up); //guarda s
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up); //guarda d
            moving = true;
            endpos = transform.position + Vector3.right * WallTrigger.WallD;
        }

        speed += (acceleration - speed * friction) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * speed);
    }
}
