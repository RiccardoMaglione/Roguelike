using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsMove : MonoBehaviour
{
    void Update()
    {
            transform.Translate(Vector3.back * 10 * Time.deltaTime);
    }
}
