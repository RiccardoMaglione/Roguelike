using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalactiteMove : MonoBehaviour
{   
    void Start()
    {
        
    }
  
    void Update()
    {
        transform.Translate(Vector3.up * -10 * Time.deltaTime);
        if (transform.position.y <= 0)
            Destroy(gameObject);        
    }
}
