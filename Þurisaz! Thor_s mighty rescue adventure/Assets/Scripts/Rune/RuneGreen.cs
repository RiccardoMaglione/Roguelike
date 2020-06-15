using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneGreen : MonoBehaviour
{

    #region Variables
    [Header("Reference for Attack")]
    public GameObject Spine;
    public GameObject PlayerContainer;

    [Header("General Reference")]
    public GameObject shadow;
    public float CooldownAttack = 6f;
    public float CooldownFlash = 0.5f;

    bool isFinishAttack = true;

    float sfx;
    bool SpellReady = true;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        PlayerContainer = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (InventorySystem.tempIGreen == 0)
        {
            if ((Input.GetKeyDown(ControlsManager.CM.runeOne) || Input.GetKeyDown(KeyCode.JoystickButton2)) && SpellReady == true)
            {
                PlayerManager.CanMove = false;
                SpawnSpike();
                Ammo.AmmoGreen--;
                Ammo.NumAmmoGreen0.text = Ammo.AmmoGreen.ToString();
                SpellReady = false;
                StartCoroutine(cooldown());
            }
        }
        if (InventorySystem.tempIGreen == 1)
        {
            if ((Input.GetKeyDown(ControlsManager.CM.runeTwo) || Input.GetKeyDown(KeyCode.JoystickButton1)) && SpellReady == true)
            {
                PlayerManager.CanMove = false;
                SpawnSpike();
                Ammo.AmmoGreen--;
                Ammo.NumAmmoGreen1.text = Ammo.AmmoGreen.ToString();
                SpellReady = false;
                StartCoroutine(cooldown());
            }
        }
    }


    #region Pattern
    void SpawnSpike()
    {
        //FindObjectOfType<AudioManager>().Play("InsertNameSound", sfx);
        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                GameObject go = Instantiate(Spine, new Vector3(transform.position.x + i, /*transform.position.y*/0, transform.position.z + j), Quaternion.identity);
                go.transform.parent = PlayerContainer.transform;
                if (go.transform.position.x == PlayerContainer.transform.position.x && go.transform.position.z == PlayerContainer.transform.position.z)
                    Destroy(go);
                Destroy(go, 3f);
            }
        }
    }
    #endregion

    #region IEnumerator Attack

    #endregion
    public IEnumerator cooldown()
    {
        if (InventorySystem.tempIGreen == 0)
        {
            //Ammo.RuneRawImageWilloWisp0.enabled = false;
            //Ammo.RuneRawImageCooldownWilloWisp0.enabled = true;
            PlayerContainer.GetComponent<Ammo>().SlotRuneOne.texture = PlayerContainer.GetComponent<Ammo>().RuneGreenTexture[1];
            yield return new WaitForSeconds(CooldownAttack);
            PlayerManager.CanMove = true;
            SpellReady = true;
            PlayerContainer.GetComponent<Ammo>().SlotRuneOne.texture = PlayerContainer.GetComponent<Ammo>().RuneGreenTexture[0];
            //Ammo.RuneRawImageCooldownWilloWisp0.enabled = false;
            //Ammo.RuneRawImageWilloWisp0.enabled = true;
        }
        if (InventorySystem.tempIGreen == 1)
        {
            //Ammo.RuneRawImageWilloWisp1.enabled = false;
            //Ammo.RuneRawImageCooldownWilloWisp1.enabled = true;
            PlayerContainer.GetComponent<Ammo>().SlotRuneTwo.texture = PlayerContainer.GetComponent<Ammo>().RuneGreenTexture[1];
            yield return new WaitForSeconds(CooldownAttack);
            PlayerManager.CanMove = true;
            SpellReady = true;
            PlayerContainer.GetComponent<Ammo>().SlotRuneTwo.texture = PlayerContainer.GetComponent<Ammo>().RuneGreenTexture[0];
            //Ammo.RuneRawImageCooldownWilloWisp1.enabled = false;
            //Ammo.RuneRawImageWilloWisp1.enabled = true;
        }
    }
}
