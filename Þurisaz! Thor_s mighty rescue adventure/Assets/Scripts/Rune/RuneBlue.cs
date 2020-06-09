using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneBlue : MonoBehaviour
{
    #region Variables
    [Header("Reference for Attack")]
    public GameObject Snowball;
    public GameObject PlayerContainer;

    [Header("General Reference")]
    public GameObject shadow;
    public float CooldownAttack = 6f;
    public float CooldownFlash = 0.5f;

    bool isFinishAttack = true;

    float sfx;
    bool SpellReady = true;
    #endregion

    private void Start()
    {
        PlayerContainer = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (InventorySystem.tempIWow == 0)
        {
            if ((Input.GetKeyDown(ControlsManager.CM.runeOne) || Input.GetKeyDown(KeyCode.JoystickButton2)) && SpellReady == true)
            {
                SpawnSnowball();
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
                SpawnSnowball();
                Ammo.AmmoW--;
                Ammo.NumAmmoW1.text = Ammo.AmmoW.ToString();
                SpellReady = false;
                StartCoroutine(cooldown());
            }
        }
    }

    #region Pattern
    void SpawnSnowball()
    {
        //FindObjectOfType<AudioManager>().Play("InsertNameSound", sfx);
        GameObject go = Instantiate(Snowball, new Vector3(PlayerContainer.transform.position.x, PlayerContainer.transform.position.y, PlayerContainer.transform.position.z), transform.rotation);
        Destroy(go, 10);
    }
    #endregion

    #region IEnumerator Attack

    #endregion

    public IEnumerator cooldown()
    {
        if (InventorySystem.tempIWow == 0)
        {
            //Ammo.RuneRawImageWilloWisp0.enabled = false;
            //Ammo.RuneRawImageCooldownWilloWisp0.enabled = true;
            yield return new WaitForSeconds(CooldownAttack);
            SpellReady = true;
            //Ammo.RuneRawImageCooldownWilloWisp0.enabled = false;
            //Ammo.RuneRawImageWilloWisp0.enabled = true;
        }
        if (InventorySystem.tempIWow == 1)
        {
            //Ammo.RuneRawImageWilloWisp1.enabled = false;
            //Ammo.RuneRawImageCooldownWilloWisp1.enabled = true;
            yield return new WaitForSeconds(CooldownAttack);
            SpellReady = true;
            //Ammo.RuneRawImageCooldownWilloWisp1.enabled = false;
            //Ammo.RuneRawImageWilloWisp1.enabled = true;
        }
    }
}
