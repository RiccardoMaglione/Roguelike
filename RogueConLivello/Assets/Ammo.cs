using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    GameObject RuneWoW;
    GameObject RuneValvran;
    public static int AmmoW = 0;
    public static int AmmoV = 0;
    bool isFirstRuneWow = false;
    bool isFirstRuneValvran = false;
    public static Text NumAmmoW0;
    public static Text NumAmmoV1;
    public static RawImage RuneRawImageWilloWisp0;
    public static RawImage RuneRawImageValvran1;
    public static RawImage RuneRawImageCooldownWilloWisp0;
    public static RawImage RuneRawImageCooldownValvran1;

    public static Text NumAmmoV0;
    public static Text NumAmmoW1;
    public static RawImage RuneRawImageValvran0;
    public static RawImage RuneRawImageWilloWisp1;
    public static RawImage RuneRawImageCooldownValvran0;
    public static RawImage RuneRawImageCooldownWilloWisp1;


    bool isActivateWow = false;
    bool isActivateValvran = false;

    private void Start()
    {
        NumAmmoW0 = GameObject.Find("NumberAmmoWillOWispText0").GetComponent<Text>();
        NumAmmoW1 = GameObject.Find("NumberAmmoWillOWispText1").GetComponent<Text>();
        
        NumAmmoV0 = GameObject.Find("NumberAmmoValvranText0").GetComponent<Text>();
        NumAmmoV1 = GameObject.Find("NumberAmmoValvranText1").GetComponent<Text>();

        NumAmmoW0.gameObject.SetActive(false);
        NumAmmoW1.gameObject.SetActive(false);
        
        NumAmmoV0.gameObject.SetActive(false);
        NumAmmoV1.gameObject.SetActive(false);



        RuneRawImageWilloWisp0 = GameObject.Find("RuneWillOWispRawImage0").GetComponent<RawImage>();
        RuneRawImageWilloWisp1 = GameObject.Find("RuneWillOWispRawImage1").GetComponent<RawImage>();
        
        RuneRawImageValvran0 = GameObject.Find("RuneValvranRawImage0").GetComponent<RawImage>();
        RuneRawImageValvran1 = GameObject.Find("RuneValvranRawImage1").GetComponent<RawImage>();

        RuneRawImageWilloWisp0.enabled = false;
        RuneRawImageWilloWisp1.enabled = false;
        
        RuneRawImageValvran0.enabled = false;
        RuneRawImageValvran1.enabled = false;



        RuneRawImageCooldownWilloWisp0 = GameObject.Find("RuneWillOWispCooldownRawImage0").GetComponent<RawImage>();
        RuneRawImageCooldownWilloWisp1 = GameObject.Find("RuneWillOWispCooldownRawImage1").GetComponent<RawImage>();
        
        RuneRawImageCooldownValvran0 = GameObject.Find("RuneValvranCooldownRawImage0").GetComponent<RawImage>();
        RuneRawImageCooldownValvran1 = GameObject.Find("RuneValvranCooldownRawImage1").GetComponent<RawImage>();


        RuneRawImageCooldownWilloWisp0.enabled = false;
        RuneRawImageCooldownWilloWisp1.enabled = false;

        RuneRawImageCooldownValvran0.enabled = false;
        RuneRawImageCooldownValvran1.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        #region Rune Will o Wisp
        if (other.gameObject.tag == "RuneWow" && isFirstRuneWow == false)
        {
            if(InventorySystem.tempIImageWow == 0 && isActivateValvran == false)
            { 
                RuneRawImageWilloWisp0.enabled = true;
                NumAmmoW0.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW0.text = AmmoW.ToString();
                isActivateWow = true;
            }
            if (isActivateValvran == true)
            {
                RuneRawImageWilloWisp1.enabled = true;
                NumAmmoW1.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW1.text = AmmoW.ToString();
            }
        }
        else if(other.gameObject.tag == "RuneWow" && isFirstRuneWow == true)
        {
            AmmoW += 10;
            if (InventorySystem.tempIImageWow == 0)
            {
                NumAmmoW0.text = AmmoW.ToString();
            }
            if (InventorySystem.tempIImageWow == 1)
            {
                NumAmmoW1.text = AmmoW.ToString();
            }
            Destroy(other.gameObject);
        }
        #endregion

        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {
            if (InventorySystem.tempIImageValvran == 0 && isActivateWow == false)
            {
                RuneRawImageValvran0.enabled = true;
                NumAmmoV0.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV0.text = AmmoV.ToString();
                isActivateValvran = true;
            }
            if (isActivateWow == true)
            {
                RuneRawImageValvran1.enabled = true;
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
        }
        else if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == true)
        {
            AmmoV += 10;
            if (InventorySystem.tempIImageValvran == 0)
            {
                NumAmmoV0.text = AmmoV.ToString();
            }
            if (InventorySystem.tempIImageValvran == 1)
            {
                NumAmmoV1.text = AmmoV.ToString();
            }
            Destroy(other.gameObject);
        }
        #endregion
    }

    void Update()
    {
        Debug.Log(AmmoW);
        Debug.Log(AmmoV);
        #region Ammo Will o Wisp
            if (AmmoW <= 0)
            {
                Destroy(RuneWoW.gameObject);
                isFirstRuneWow = false;
                RuneRawImageWilloWisp0.enabled = false;
                RuneRawImageCooldownWilloWisp0.enabled = false;
                NumAmmoW0.gameObject.SetActive(false);
                RuneRawImageWilloWisp1.enabled = false;
                RuneRawImageCooldownWilloWisp1.enabled = false;
                NumAmmoW1.gameObject.SetActive(false);
            }
        #endregion

        #region Ammo Valvran
            if (AmmoV <= 0)
            {
                Destroy(RuneValvran.gameObject);
                isFirstRuneValvran = false;
                RuneRawImageValvran0.enabled = false;
                RuneRawImageCooldownValvran0.enabled = false;
                NumAmmoV0.gameObject.SetActive(false);
                RuneRawImageValvran1.enabled = false;
                RuneRawImageCooldownValvran1.enabled = false;
                NumAmmoV1.gameObject.SetActive(false);
            }
        #endregion
    }
}
