using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneAttack1 : MonoBehaviour
{
    public GameObject shotReference;
    public GameObject[] player;
    bool SpellReady = true;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        //NumAmmoW = GameObject.Find("NumberAmmoWillOWispText").GetComponent<Text>();
    }
    void Update()
    {
        if(InventorySystem.tempIWow == 0)
        {
            if ((Input.GetKeyDown(GameManagerScript.GM.runeOne) || Input.GetKeyDown(KeyCode.JoystickButton2)) && SpellReady == true)
            {
                Attack3Angle();
                Ammo.AmmoW--;
                Ammo.NumAmmoW0.text = Ammo.AmmoW.ToString();
                SpellReady = false;
                StartCoroutine(cooldown());
            }
        }
        if (InventorySystem.tempIWow == 1)
        {
            if ((Input.GetKeyDown(GameManagerScript.GM.runeTwo) || Input.GetKeyDown(KeyCode.JoystickButton1)) && SpellReady == true)
            {
                Attack3Angle();
                Ammo.AmmoW--;
                Ammo.NumAmmoW1.text = Ammo.AmmoW.ToString();
                SpellReady = false;
                StartCoroutine(cooldown());
            }
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


    public IEnumerator cooldown()
    {
        if (InventorySystem.tempIWow == 0)
        {
            Ammo.RuneRawImageWilloWisp0.enabled = false;
            Ammo.RuneRawImageCooldownWilloWisp0.enabled = true;
            yield return new WaitForSeconds(0.70f);
            SpellReady = true;
            Ammo.RuneRawImageCooldownWilloWisp0.enabled = false;
            Ammo.RuneRawImageWilloWisp0.enabled = true;
        }
        if (InventorySystem.tempIWow == 1)
        {
            Ammo.RuneRawImageWilloWisp1.enabled = false;
            Ammo.RuneRawImageCooldownWilloWisp1.enabled = true;
            yield return new WaitForSeconds(0.70f);
            SpellReady = true;
            Ammo.RuneRawImageCooldownWilloWisp1.enabled = false;
            Ammo.RuneRawImageWilloWisp1.enabled = true;
        }
    }

}
