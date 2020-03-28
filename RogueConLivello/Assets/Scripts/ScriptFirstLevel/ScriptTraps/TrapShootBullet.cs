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
            GameObject stalactite = Instantiate(prefab, transform.localPosition, Quaternion.identity);
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