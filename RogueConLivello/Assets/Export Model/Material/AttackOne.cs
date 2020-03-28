using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOne : MonoBehaviour
{
    public GameObject ChickenMinion;
    public Transform GammurTransformParent;

    private void Start()
    {
        SpawnMinion();
    }

    void SpawnMinion()
    {
        float radius = 2f;
        for (int i = 0; i < 6; i++)
        {
            float angle = i * Mathf.PI * 2f / 6;
            Vector3 newPos = new Vector3(GammurTransformParent.transform.position.x + Mathf.Cos(angle) * radius, GammurTransformParent.transform.position.y, GammurTransformParent.transform.position.z + Mathf.Sin(angle) * radius);
            GameObject go = Instantiate(ChickenMinion, newPos, Quaternion.identity);
            go.transform.SetParent(GammurTransformParent);
        }
    }
}