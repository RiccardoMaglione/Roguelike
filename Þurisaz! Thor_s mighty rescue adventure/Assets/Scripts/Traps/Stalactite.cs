using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public GameObject prefab;
    public GameObject TrapStalactite;
    public GameObject StalactiteBreak;
    
    public float sfx;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject stalactite = Instantiate(prefab, TrapStalactite.transform.position + (transform.up * 7), transform.rotation);
        }
        if(other.gameObject.tag == "Stalactite")
        {
            FindObjectOfType<AudioManager>().Play("StalactiteTrap", sfx);
            Destroy(other.gameObject);
            StalactiteBreak.SetActive(true);
            TrapStalactite.SetActive(false);
        }
    }
    void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");
    }
}