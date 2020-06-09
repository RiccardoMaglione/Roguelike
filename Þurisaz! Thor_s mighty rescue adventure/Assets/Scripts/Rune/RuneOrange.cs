using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneOrange : MonoBehaviour
{
    #region Variables
    [Header("Reference for Attack")]
    public GameObject Fireball;
    public GameObject PlayerContainer;

    [Header("General Reference")]
    public GameObject shadow;
    public int HeightAttack = 5;
    public float CooldownAttack = 3f;
    public float CooldownFlash = 0.5f;

    bool isFinishAttack = true;
    bool SpellReady = true;

    float sfx;
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
                SpawnFireball();
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
                SpawnFireball();
                Ammo.AmmoW--;
                Ammo.NumAmmoW1.text = Ammo.AmmoW.ToString();
                SpellReady = false;
                StartCoroutine(cooldown());
            }
        }
    }

    #region Pattern
    void SpawnFireball()
    {
        //FindObjectOfType<AudioManager>().Play("InsertNameSound", sfx);
        for (int i = 2; i < 6; i++)
        {
            GameObject go = Instantiate(Fireball, new Vector3(PlayerContainer.transform.localPosition.x, PlayerContainer.transform.localPosition.y + HeightAttack, PlayerContainer.transform.localPosition.z) + PlayerContainer.transform.right * i, transform.rotation);
        }
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
