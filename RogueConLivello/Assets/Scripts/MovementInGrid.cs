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

    public float timerW = 0f;
    public float timerS = 0f;
    public float timerA = 0f;
    public float timerD = 0f;

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
            timerW += Time.deltaTime;
            timerS = 0;
            timerA = 0;
            timerD = 0;
            speed = speedInitial;
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up); //guarda d
            transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up); //guarda w
            if (timerW > 0.10f)
            {
                moving = true;
                endpos = transform.position + Vector3.forward * WallTrigger.WallW;
                timerW = 0.99f;
            }
        }
        
        if (!moving && Input.GetKey(GameManagerScript.GM.backward))     //s
        {
            timerS += Time.deltaTime;
            timerW = 0;
            timerA = 0;
            timerD = 0;
            speed = speedInitial;
            //transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up); //guarda a
            transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up); //guarda s
            if (timerS > 0.10f)
            {
                moving = true;
                endpos = transform.position + Vector3.back * WallTrigger.WallS;
                timerS = 0.99f;
            }
        }
        
        if (!moving && Input.GetKey(GameManagerScript.GM.left))     //a
        {
            timerW = 0;
            timerS = 0;
            timerD = 0;
            timerA += Time.deltaTime;
            speed = speedInitial;
            //transform.rotation = Quaternion.LookRotation(Vector3.left, Vector3.up); //guarda w
            transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up); //guarda a
            if (timerA > 0.10f)
            {
                moving = true;
                endpos = transform.position + Vector3.left * WallTrigger.WallA;
                timerA = 0.99f;
            }
        }
        
        if (!moving && Input.GetKey(GameManagerScript.GM.right))     //d
        {
            timerW = 0;
            timerS = 0;
            timerA = 0;
            timerD += Time.deltaTime;
            speed = speedInitial;
            //transform.rotation = Quaternion.LookRotation(Vector3.right, Vector3.up); //guarda s
            transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up); //guarda d
            if (timerD > 0.10f)
            {
                moving = true;
                endpos = transform.position + Vector3.right * WallTrigger.WallD;
                timerD = 0.99f;
            }
        }
        
        speed += (acceleration - speed * friction) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endpos, Time.deltaTime * speed);        
    }
}
