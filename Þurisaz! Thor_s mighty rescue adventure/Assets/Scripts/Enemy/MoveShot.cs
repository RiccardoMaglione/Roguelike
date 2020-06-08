using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShot : MonoBehaviour
{
    public float velocity = 5;
    void Move()
    {
        if (gameObject.tag == "ShotEye")
        {
            transform.Translate(Vector3.up * velocity * Time.deltaTime);
        }
        if (gameObject.tag == "Shot")
        {
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        }
        if (gameObject.tag == "ShotPlayer")
        {
            transform.Translate(Vector3.right * velocity * Time.deltaTime);
        }
        if(gameObject.tag == "Scream")
        {
            transform.Translate(Vector3.left * 2 * Time.deltaTime);
        }
        if (gameObject.tag == "ShotFire")
        {
            transform.Translate(Vector3.down * velocity * Time.deltaTime);
        }
    }

    void Update()
    {
        Move();
    }
}