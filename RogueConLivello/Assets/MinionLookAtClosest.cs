using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionLookAtClosest : MonoBehaviour
{
    public Transform target;
    private float speed = 1f;
    //private Vector3 speedRot = Vector3.up;

    void Start()
    {
        Destroy(gameObject, 10);
    }

    void Update()
    {
        MoveSlime("Enemy");
    }


    void MoveSlime(string tag)
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag(tag);
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
                transform.LookAt(closest.transform);
                transform.position = Vector3.MoveTowards(transform.position, closest.transform.position, speed * Time.deltaTime);
            }
        }
    }
}
