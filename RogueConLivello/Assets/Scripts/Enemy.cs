using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject RuneReference;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("asfd");
        //Destroy(this.gameObject);
        //GameObject rune = Instantiate(RuneReference, transform.position, transform.rotation);
    }
   
       
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
