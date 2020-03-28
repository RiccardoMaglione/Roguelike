using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScream : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Scream")
        {
            Destroy(collision.gameObject);
        }
    }
}
