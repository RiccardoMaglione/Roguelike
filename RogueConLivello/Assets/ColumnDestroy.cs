using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shot" || other.gameObject.tag == "ShotPlayer" || other.gameObject.tag == "EggPlayer" || other.gameObject.tag == "EggcrackerPlayer")
        {
            Destroy(other.gameObject);
        }
    }
}
