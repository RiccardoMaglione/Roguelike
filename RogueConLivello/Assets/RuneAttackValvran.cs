using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneAttackValvran : MonoBehaviour
{
    public GameObject PeckReference;
    public GameObject[] player;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        if (Input.GetKeyDown(GameManagerScript.GM.runeTwo))
        {
            StartCoroutine(Attack());
            Ammo.AmmoV--;
        }
    }
    //void Attack3Peck()
    //{
    //    GameObject newShot1 = Instantiate(PeckReference, player[0].transform.position, player[0].transform.rotation * Quaternion.Euler(0, 45, 0));
    //    Destroy(newShot1, 0.2f);
    //    newShot1.tag = "ShotPlayer";
    //    GameObject newShot2 = Instantiate(PeckReference, player[0].transform.position, player[0].transform.rotation);
    //    Destroy(newShot2, 0.6f);
    //    newShot2.tag = "ShotPlayer";
    //    GameObject newShot3 = Instantiate(PeckReference, player[0].transform.position, player[0].transform.rotation * Quaternion.Euler(0, -45, 0));
    //    Destroy(newShot3, 0.7f);
    //    newShot3.tag = "ShotPlayer";
    //}

    IEnumerator Attack()
    {
        yield return new WaitForSeconds((float)0.1f);
        GameObject newShot1 = Instantiate(PeckReference, player[0].transform.position, player[0].transform.rotation * Quaternion.Euler(0, 45, 0));
        newShot1.tag = "ShotPlayer";

        yield return new WaitForSeconds((float)0.2f);
        GameObject newShot2 = Instantiate(PeckReference, player[0].transform.position, player[0].transform.rotation);
        newShot2.tag = "ShotPlayer";

        yield return new WaitForSeconds((float)0.3f);
        GameObject newShot3 = Instantiate(PeckReference, player[0].transform.position, player[0].transform.rotation * Quaternion.Euler(0, -45, 0));
        newShot3.tag = "ShotPlayer";

        Destroy(newShot1, 0.5f);
        Destroy(newShot2, 0.7f);
        Destroy(newShot3, 0.9f);
    }
}