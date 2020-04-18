using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneAttackGammurThree : MonoBehaviour
{
    public GameObject[] Player;
    public GameObject ChickenMinion;

    private void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SpawnMinion();
        }
    }

    void SpawnMinion()
    {
        float radius = 3f;
        for (int i = 0; i < 3; i++)
        {
            float angle = i * Mathf.PI * 2f / 3;
            Vector3 newPos = new Vector3(Player[0].transform.position.x + Mathf.Cos(angle) * radius, Player[0].transform.position.y, Player[0].transform.position.z + Mathf.Sin(angle) * radius);
            GameObject go1 = Instantiate(ChickenMinion, newPos, Quaternion.identity);
            go1.tag = "EggcrackerPlayer";
            //go1.transform.SetParent(Player[0].transform);
            go1.AddComponent<MinionLookAtClosest>();
        }
    }
}