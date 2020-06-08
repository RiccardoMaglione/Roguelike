using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 5f;
    public float power = 10f;
    public float explosionVerticality = 1f;

    private void Start()
    {
        StartCoroutine(ExplosionSnowball());
    }

    private void Update()
    {
        //if(Input.GetKey(KeyCode.W))
        //{
        //    
        //}
    }

    IEnumerator ExplosionSnowball()
    {
        yield return new WaitForSeconds(2);
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, explosionVerticality);
        }
        yield return new WaitForSeconds(5);
        //Destroy(this.gameObject,10);
    }
}
