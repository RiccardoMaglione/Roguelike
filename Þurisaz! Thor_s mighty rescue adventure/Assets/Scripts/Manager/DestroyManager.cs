using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Shot" || other.gameObject.tag == "ShotPlayer" || other.gameObject.tag == "EggPlayer" || other.gameObject.tag == "EggcrackerPlayer") && gameObject.tag == "Column")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Egg")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Scream")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Egg")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Shot" || other.gameObject.tag == "ShotPlayer" || other.gameObject.tag == "EggPlayer" || other.gameObject.tag == "EggcrackerPlayer")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Egg")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Scream")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Egg")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            Destroy(collision.gameObject);
        }
    }
}