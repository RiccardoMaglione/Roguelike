using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public GameObject prefab;
    public GameObject TrapStalactite;
    public GameObject StalactiteBreak;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //TrapStalactite.SetActive(true);
            //StalactiteBreak.SetActive(false);
            GameObject stalactite = Instantiate(prefab, TrapStalactite.transform.position + (transform.up * 7), transform.rotation);
        }
        if(other.gameObject.tag == "Stalactite")
        {
            Destroy(other.gameObject);
            StalactiteBreak.SetActive(true);
            TrapStalactite.SetActive(false);
        }
    }
}
