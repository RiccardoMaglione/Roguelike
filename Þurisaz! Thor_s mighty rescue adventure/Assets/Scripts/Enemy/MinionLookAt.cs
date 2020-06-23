using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionLookAt : MonoBehaviour
{
    public Transform target;
    private float speed = 1f;
    public GameObject ExplosionEggCracker;
    public float timer;
    void Start()
    {
        ExplosionEggCracker = GameObject.FindGameObjectWithTag("Explosion");
        if (gameObject.tag == "Eggcracker")
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            Destroy(gameObject, 10);
        }
        if (gameObject.tag == "EggcrackerPlayer")
        {
            Destroy(gameObject, 10);
        }
    }

    private void MoveEggcrackerGammur()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    void MoveEggcrackerPlayer(string tag)
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
    void Update()
    {
        if (gameObject.tag == "Eggcracker")
        {
            MoveEggcrackerGammur();
        }
        if (gameObject.tag == "EggcrackerPlayer")
        {
            MoveEggcrackerPlayer("Enemy");
        }

        timer += Time.deltaTime;
        if (gameObject.tag == "Eggcracker" && timer > 9.9)
        {
            GameObject GoExplosion = Instantiate(ExplosionEggCracker, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), transform.rotation);
            GoExplosion.SetActive(true);
            Destroy(GoExplosion, 1);
            timer = 0;
        }
        if (gameObject.tag == "EggcrackerPlayer" && timer > 9.9)
        {
            GameObject GoExplosion = Instantiate(ExplosionEggCracker, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), transform.rotation);
            GoExplosion.SetActive(true);
            Destroy(GoExplosion, 1);
            timer = 0;
        }
    }
}