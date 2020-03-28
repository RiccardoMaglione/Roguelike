using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternGammur : MonoBehaviour
{


    public GameObject ScreamPart;
    public GameObject Gammur;

    public GameObject Egg;
    public GameObject Player;
    public Transform GammurTransformParent;

    public GameObject ChickenMinion;
    //public Transform GammurTransformParent;
    bool isActive = true;


    private void OnTriggerEnter(Collider other)
    {
        if(isActive == true)
        {
            StartCoroutine(GammurAttack());
            isActive = false;
        }
    }


    private void Start()
    {
        //StartCoroutine(GammurAttack());
    }

    public IEnumerator GammurAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds((float)3f);
            StartCoroutine(Scream());
            yield return new WaitForSeconds((float)10f);
            SpawnMinion();
            yield return new WaitForSeconds((float)10f);
            EggBomb();
            yield return new WaitForSeconds((float)3f);
        }
    }

    public IEnumerator Scream()
    {
        for (int i = 0; i < 3; i++)
        {
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x + 1, transform.position.y, Gammur.transform.position.z + 3), Quaternion.identity);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x -1, transform.position.y, Gammur.transform.position.z + 3), Quaternion.identity);

            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 4, transform.position.y, Gammur.transform.position.z + 1), Quaternion.identity); //1
            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 4, transform.position.y, Gammur.transform.position.z - 0), Quaternion.identity); //2


            yield return new WaitForSeconds((float)0.2f);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x + 2, transform.position.y, Gammur.transform.position.z + 3), Quaternion.identity);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x -2, transform.position.y, Gammur.transform.position.z + 3), Quaternion.identity);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x + 3, transform.position.y, Gammur.transform.position.z + 3), Quaternion.identity);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x -3, transform.position.y, Gammur.transform.position.z + 3), Quaternion.identity);

            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 3, transform.position.y, Gammur.transform.position.z + 2), Quaternion.identity); //3
            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 3, transform.position.y, Gammur.transform.position.z - 1), Quaternion.identity); //4
            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 3, transform.position.y, Gammur.transform.position.z + 3), Quaternion.identity); //5
            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 3, transform.position.y, Gammur.transform.position.z - 2), Quaternion.identity); //6

            yield return new WaitForSeconds((float)0.2f);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x + 4, transform.position.y, Gammur.transform.position.z + 2), Quaternion.identity);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x -4, transform.position.y, Gammur.transform.position.z + 2), Quaternion.identity);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x + 5, transform.position.y, Gammur.transform.position.z + 2), Quaternion.identity);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x -5, transform.position.y, Gammur.transform.position.z + 2), Quaternion.identity);
            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 2, transform.position.y, Gammur.transform.position.z + 1), Quaternion.identity); //7
            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 2, transform.position.y, Gammur.transform.position.z - 0), Quaternion.identity); //8


            yield return new WaitForSeconds((float)0.2f);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x + 1, transform.position.y, Gammur.transform.position.z + 3), Quaternion.identity);
            //Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x -1, transform.position.y, Gammur.transform.position.z + 3), Quaternion.identity);

            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 1, transform.position.y, Gammur.transform.position.z + 4), Quaternion.identity); //9
            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 1, transform.position.y, Gammur.transform.position.z - 3), Quaternion.identity); //10
            yield return new WaitForSeconds((float)0.2f);
            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 1, transform.position.y, Gammur.transform.position.z + 5), Quaternion.identity); //11
            Instantiate(ScreamPart, new Vector3(GammurTransformParent.transform.position.x - 1, transform.position.y, Gammur.transform.position.z - 4), Quaternion.identity); //12

            yield return new WaitForSeconds((float)2f);
        }
    }

    void EggBomb()
    {
        float radius = 2f;
        for (int i = 0; i < 3; i++)
        {
            float angle = i * Mathf.PI * 2f / 3;
            Vector3 newPos = new Vector3(Player.transform.position.x + Mathf.Cos(angle) * radius, 10, Player.transform.position.z + Mathf.Sin(angle) * radius);
            GameObject go = Instantiate(Egg, newPos, Quaternion.identity);
            go.transform.SetParent(GammurTransformParent);
            Rigidbody rg = go.AddComponent<Rigidbody>();
        }
    }

    void SpawnMinion()
    {
        float radius = 3f;
        for (int i = 0; i < 6; i++)
        {
            float angle = i * Mathf.PI * 2f / 6;
            Vector3 newPos = new Vector3(GammurTransformParent.transform.position.x + Mathf.Cos(angle) * radius, GammurTransformParent.transform.position.y, GammurTransformParent.transform.position.z + Mathf.Sin(angle) * radius);
            GameObject go = Instantiate(ChickenMinion, newPos, Quaternion.identity);
            go.transform.SetParent(GammurTransformParent);
            go.AddComponent<MinionLookAt>();
        }
    }

}