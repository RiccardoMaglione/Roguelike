using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneAttackGammurTwo : MonoBehaviour
{
    public GameObject[] Player;
    public GameObject Egg;
    bool SpellReady = true;
    RawImage GammurCooldownTwo;

    private void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        GammurCooldownTwo = GameObject.Find("RuneGammur2RawImageCooldown").GetComponent<RawImage>();
        GammurCooldownTwo.enabled = false;
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button3)) && SpellReady == true)
        {
            EggBomb();
            SpellReady = false;
            StartCoroutine(cooldown());
        }
    }

    //GameObject EggBomb(string tag)
    //{
    //    GameObject[] gos;
    //    gos = GameObject.FindGameObjectsWithTag(tag);
    //    GameObject closest = null;
    //    float distance = Mathf.Infinity;
    //    Vector3 position = transform.position;
    //    foreach (GameObject go in gos)
    //    {
    //        Vector3 diff = go.transform.position - position;
    //        float curDistance = diff.sqrMagnitude;
    //        if (curDistance < distance)
    //        {
    //            closest = go;
    //            distance = curDistance;
    //            float radius = 2f;
    //            for (int i = 0; i < 3; i++)
    //            {
    //                float angle = i * Mathf.PI * 2f / 3;
    //                Vector3 newPos = new Vector3(closest.transform.position.x + Mathf.Cos(angle) * radius, 10, closest.transform.position.z + Mathf.Sin(angle) * radius);
    //                GameObject go1 = Instantiate(Egg, newPos, Quaternion.identity);
    //                go1.tag = "EggPlayer";
    //                //go1.transform.SetParent(Player[0].transform);
    //                Rigidbody rg = go1.AddComponent<Rigidbody>();
    //                go1.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
    //            }
    //            return gameObject;
    //        }
    //    }
    //    return gameObject;
    //}

    public IEnumerator cooldown()
    {
        GammurCooldownTwo.enabled = true;
        yield return new WaitForSeconds(10);
        SpellReady = true;
        GammurCooldownTwo.enabled = false;
    }

    public void EggBomb()
    {
        float bestDistance = 10.0f;
        Collider bestCollider = null;

        Collider[] hitColliders = Physics.OverlapSphere(Player[0].transform.position, 10f);
        foreach (Collider detectedCollider in hitColliders)
        {
            if(detectedCollider.tag == "Enemy")
            {
                Debug.Log("Trovato");

                float distance = Vector3.Distance(Player[0].transform.position, detectedCollider.transform.position);

                if (distance < bestDistance)
                {
                    bestDistance = distance;
                    bestCollider = detectedCollider;

                    Vector3 positionOfEnemy = detectedCollider.ClosestPointOnBounds(Player[0].transform.position);
                    float radius = 2f;
                    for (int i = 0; i < 3; i++)
                    {
                        float angle = i * Mathf.PI * 2f / 3;
                        Vector3 newPos = new Vector3(positionOfEnemy.x + Mathf.Cos(angle) * radius, 10, positionOfEnemy.z + Mathf.Sin(angle) * radius);
                        GameObject go1 = Instantiate(Egg, newPos, Quaternion.identity);
                        go1.tag = "EggPlayer";
                        //go1.transform.SetParent(Player[0].transform);
                        Rigidbody rg = go1.AddComponent<Rigidbody>();
                        go1.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
                    }
                }
            }
        }
    }
}