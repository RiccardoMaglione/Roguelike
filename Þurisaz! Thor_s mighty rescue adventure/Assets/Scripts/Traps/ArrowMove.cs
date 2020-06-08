using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector3.forward * 10 * Time.deltaTime);     //Muove la freccia nella direzione in cui sta guardando
    }
}