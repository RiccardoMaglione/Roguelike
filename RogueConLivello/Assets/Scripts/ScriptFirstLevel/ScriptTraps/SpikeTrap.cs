using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject Spike;
    public GameObject Trap5;
    public GameObject Trap7;
    IEnumerator OnTriggerEnter(Collider other)
    {
        if(Trap5)
        {
            yield return new WaitForSeconds(0.5f);
            Spike.transform.position = new Vector3(-21, 0.5f, -1);
            yield return new WaitForSeconds(1f);
            Spike.transform.position = new Vector3(-21, -0.5f, -1);
        }
        if(Trap7)
        {
            yield return new WaitForSeconds(0.5f);
            Spike.transform.position = new Vector3(-4, 0.5f, -3);
            yield return new WaitForSeconds(1f);
            Spike.transform.position = new Vector3(-4, -0.5f, -3);
        }
    }
}
