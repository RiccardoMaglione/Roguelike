using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShotWow : MonoBehaviour
{
    public float velocity = 5;
    void Move()
    {
        if(gameObject.tag == "Shot")
        {
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);
        }
        if (gameObject.tag == "ShotPlayer")
        {
            transform.Translate(Vector3.right * velocity * Time.deltaTime);
        }

    }

    void Update()
    {
        Move();
    }
}
