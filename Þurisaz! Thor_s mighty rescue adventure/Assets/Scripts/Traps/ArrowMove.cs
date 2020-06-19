using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    void Update()
    {
        if(this.gameObject.name == "ArrowE0(Clone)")
        {
            transform.Translate(Vector3.left * 10 * Time.deltaTime);     //Muove la freccia nella direzione in cui sta guardando
        }
        else if (this.gameObject.name == "ArrowOE(Clone)")
        {
            transform.Translate(Vector3.right * 10 * Time.deltaTime);     //Muove la freccia nella direzione in cui sta guardando
        }
        else
        {
            transform.Translate(Vector3.forward * 10 * Time.deltaTime);     //Muove la freccia nella direzione in cui sta guardando
        }
    }
}