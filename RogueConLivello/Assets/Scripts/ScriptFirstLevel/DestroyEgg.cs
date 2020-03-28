using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEgg : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Egg")
        {
            Destroy(collision.gameObject);
        }
    }
}
