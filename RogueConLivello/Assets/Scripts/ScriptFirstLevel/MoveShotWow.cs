using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShotWow : MonoBehaviour
{
    public float velocity = 50;
    void Move()
    {
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }

    void Update()
    {
        Move();
    }
}
