using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneGammurTwo : MonoBehaviour
{
    public GameObject[] Player;
    public GameObject Egg;
    bool SpellReady = true;
    RawImage GammurCooldownTwo;

    public GameObject shadow;

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

                        GameObject shadow1 = Instantiate(shadow, new Vector3(newPos.x, 0.1f, newPos.z), Quaternion.identity);
                        shadow1.tag = "EggPlayer";
                        shadow1.transform.parent = go1.transform;

                        Rigidbody rg = go1.AddComponent<Rigidbody>();
                        go1.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
                    }
                }
            }
        }
    }
}