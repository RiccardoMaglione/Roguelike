using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneAttackValvran : MonoBehaviour
{
    public GameObject PeckReference;
    public GameObject[] player;
    bool SpellReady = true;
    

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        if(InventorySystem.tempIValvran == 0)
        {
            if ((Input.GetKeyDown(GameManagerScript.GM.runeOne) || Input.GetKeyDown(KeyCode.JoystickButton2)) && SpellReady == true)
            {
                StartCoroutine(Attack());
                Ammo.AmmoV--;
                Ammo.NumAmmoV0.text = Ammo.AmmoV.ToString();
                SpellReady = false;
                Ammo.RuneRawImageValvran0.enabled = false;
                Ammo.RuneRawImageCooldownValvran0.enabled = true;
                StartCoroutine(cooldown());
                Ammo.RuneRawImageCooldownValvran0.enabled = false;
                Ammo.RuneRawImageValvran0.enabled = true;
            }
        }
        if (InventorySystem.tempIValvran == 1)
        {
            if ((Input.GetKeyDown(GameManagerScript.GM.runeTwo) || Input.GetKeyDown(KeyCode.JoystickButton1)) && SpellReady == true)
            {
                StartCoroutine(Attack());
                Ammo.AmmoV--;
                Ammo.NumAmmoV1.text = Ammo.AmmoV.ToString();
                SpellReady = false;
                Ammo.RuneRawImageValvran1.enabled = false;
                Ammo.RuneRawImageCooldownValvran1.enabled = true;
                StartCoroutine(cooldown());
                Ammo.RuneRawImageCooldownValvran1.enabled = false;
                Ammo.RuneRawImageValvran1.enabled = true;
            }
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

        Destroy(newShot1, 0.2f);
        Destroy(newShot2, 0.4f);
        Destroy(newShot3, 0.6f);
    }
    public IEnumerator cooldown()
    {
        yield return new WaitForSeconds(0.70f);
        SpellReady = true;
    }
}