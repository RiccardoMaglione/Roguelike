using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneAttack1 : MonoBehaviour
{
    public GameObject shotReference;
    public GameObject[] player;
    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        if(Input.GetKeyDown(GameManagerScript.GM.runeOne))
        {
            Attack3Angle();
            Ammo.AmmoW--;
        }
    }
    void Attack3Angle()
    {
        GameObject newShot1 = Instantiate(shotReference, player[0].transform.position /*+ (transform.forward)*/, player[0].transform.rotation * Quaternion.Euler(0, 45, 0));
        //newShot1.tag = "ShotPlayer";
        newShot1.tag = "ShotPlayer";
        GameObject newShot2 = Instantiate(shotReference, player[0].transform.position /*+ (transform.forward)*/, player[0].transform.rotation);
        //newShot2.tag = "ShotPlayer";
        newShot2.tag = "ShotPlayer";
        GameObject newShot3 = Instantiate(shotReference, player[0].transform.localPosition /*+ (transform.forward)*/, player[0].transform.rotation * Quaternion.Euler(0, -45, 0));
        //newShot3.tag = "ShotPlayer";
        newShot3.tag = "ShotPlayer";
    }
}
