using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneWow : MonoBehaviour
{
    public GameObject shotReference;
    public GameObject[] player;
    bool SpellReady = true;

    public GameObject shadow;

    public float CooldownRune = 0.7f;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
    }
    void Update()
    {
        if(InventorySystem.tempIWow == 0)
        {
            if ((Input.GetKeyDown(ControlsManager.CM.runeOne) || Input.GetKeyDown(KeyCode.JoystickButton2)) && SpellReady == true)
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
            if ((Input.GetKeyDown(ControlsManager.CM.runeTwo) || Input.GetKeyDown(KeyCode.JoystickButton1)) && SpellReady == true)
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
        GameObject newShot1 = Instantiate(shotReference, player[0].transform.position, player[0].transform.rotation * Quaternion.Euler(0, 45, 0));
        newShot1.tag = "ShotPlayer";
        GameObject newShot2 = Instantiate(shotReference, player[0].transform.position, player[0].transform.rotation);
        newShot2.tag = "ShotPlayer";
        GameObject newShot3 = Instantiate(shotReference, player[0].transform.localPosition, player[0].transform.rotation * Quaternion.Euler(0, -45, 0));
        newShot3.tag = "ShotPlayer";
        
        GameObject shadow1 = Instantiate(shadow, new Vector3(player[0].transform.localPosition.x, 0.1f, player[0].transform.localPosition.z)/* + (transform.forward * 0.6f)*/, player[0].transform.rotation * Quaternion.Euler(0, 45, 0));
        GameObject shadow2 = Instantiate(shadow, new Vector3(player[0].transform.localPosition.x, 0.1f, player[0].transform.localPosition.z)/* + (transform.forward * 0.6f)*/, player[0].transform.rotation * Quaternion.Euler(0, 0, 0));
        GameObject shadow3 = Instantiate(shadow, new Vector3(player[0].transform.localPosition.x, 0.1f, player[0].transform.localPosition.z)/* + (transform.forward * 0.6f)*/, player[0].transform.rotation * Quaternion.Euler(0, -45, 0));

        shadow1.tag = "ShotPlayer";
        shadow2.tag = "ShotPlayer";
        shadow3.tag = "ShotPlayer";
        shadow1.transform.parent = newShot1.transform;
        shadow2.transform.parent = newShot2.transform;
        shadow3.transform.parent = newShot3.transform;
    }


    public IEnumerator cooldown()
    {
        if (InventorySystem.tempIWow == 0)
        {
            Ammo.RuneRawImageWilloWisp0.enabled = false;
            Ammo.RuneRawImageCooldownWilloWisp0.enabled = true;
            yield return new WaitForSeconds(CooldownRune);
            SpellReady = true;
            Ammo.RuneRawImageCooldownWilloWisp0.enabled = false;
            Ammo.RuneRawImageWilloWisp0.enabled = true;
        }
        if (InventorySystem.tempIWow == 1)
        {
            Ammo.RuneRawImageWilloWisp1.enabled = false;
            Ammo.RuneRawImageCooldownWilloWisp1.enabled = true;
            yield return new WaitForSeconds(CooldownRune);
            SpellReady = true;
            Ammo.RuneRawImageCooldownWilloWisp1.enabled = false;
            Ammo.RuneRawImageWilloWisp1.enabled = true;
        }
    }
}