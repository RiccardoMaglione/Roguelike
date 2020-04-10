using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    //public GameObject Spike;
    public GameObject Trap5Normal;
    public GameObject Trap5Spike;
    public GameObject Trap7Normal;
    public GameObject Trap7Spike;
    IEnumerator OnTriggerEnter(Collider other)
    {
        if(Trap5Normal)
        {
            yield return new WaitForSeconds(0.5f);
            //Spike.transform.position = new Vector3(-21, 0.5f, -1);
            Trap5Spike.SetActive(true);
            yield return new WaitForSeconds(1f);
            //Spike.transform.position = new Vector3(-21, -0.5f, -1);
            Trap5Spike.SetActive(false);
        }
        if(Trap7Normal)
        {
            yield return new WaitForSeconds(0.5f);
            //Spike.transform.position = new Vector3(-4, 0.5f, -3);
            Trap7Spike.SetActive(true);
            yield return new WaitForSeconds(1f);
            //Spike.transform.position = new Vector3(-4, -0.5f, -3);
            Trap7Spike.SetActive(false);
        }
    }
}
