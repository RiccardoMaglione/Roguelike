using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstrainShadow : MonoBehaviour
{
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0.011f, transform.position.z);
    }
}
