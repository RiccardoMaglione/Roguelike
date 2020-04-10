using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShot : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Shot")
    //    {
    //        Destroy(collision.gameObject);
    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Shot")
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Shot" || other.gameObject.tag == "ShotPlayer")
        {
            Destroy(other.gameObject);
        }
    }
}
