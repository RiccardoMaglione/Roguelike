using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapShootBullet : MonoBehaviour
{
    public GameObject prefab;

    IEnumerator shot()
    {
        while (true)
        {
            Quaternion rot = new Quaternion(0, 180, 0, 0);
            GameObject stalactite = Instantiate(prefab, transform.position, rot);
            yield return new WaitForSeconds(1);
        }
    }

    void Start()
    {
        StartCoroutine(shot());
    }

    void Update()
    {

    }
}