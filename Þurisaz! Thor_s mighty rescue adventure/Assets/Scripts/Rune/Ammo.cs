using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ammo : MonoBehaviour
{

    #region GameObject riferimento all'oggetto runa nella UI
    GameObject RuneWoW;
    GameObject RuneValvran;

    GameObject RuneBlue;
    GameObject RuneGreen;
    GameObject RuneYellow;
    GameObject RuneRed;
    GameObject RuneEye;
    GameObject RuneDarkElf;
    GameObject RuneDraugr;
    #endregion

    #region Intero riferimento al numero delle ammo dei singoli mostri
    public static int AmmoW = 0;
    public static int AmmoV = 0;

    public static int AmmoBlue = 0;
    public static int AmmoGreen = 0;
    public static int AmmoYellow = 0;
    public static int AmmoRed = 0;
    public static int AmmoEye = 0;
    public static int AmmoDarkElf = 0;
    public static int AmmoDraugr = 0;
    #endregion

    #region Booleano riferimento alla prima runa per capire il posizionamento nell'inventario
    bool isFirstRuneWow = false;
    bool isFirstRuneValvran = false;

    bool isFirstRuneBlue = false;
    bool isFirstRuneGreen = false;
    bool isFirstRuneYellow = false;
    bool isFirstRuneRed = false;
    bool isFirstRuneEye = false;
    bool isFirstRuneDarkElf = false;
    bool isFirstRuneDraugr = false;
    #endregion

    #region Testo riferimento al testo nella ui delle ammo
    public static Text NumAmmoW0;
    public static Text NumAmmoW1;
    
    public static Text NumAmmoV0;
    public static Text NumAmmoV1;

    public static Text NumAmmoBlue0;
    public static Text NumAmmoBlue1;

    public static Text NumAmmoGreen0;
    public static Text NumAmmoGreen1;
    
    public static Text NumAmmoRed0;
    public static Text NumAmmoRed1;
    
    public static Text NumAmmoYellow0;
    public static Text NumAmmoYellow1;

    public static Text NumAmmoEye0;
    public static Text NumAmmoEye1;

    public static Text NumAmmoDarkElf0;
    public static Text NumAmmoDarkElf1;

    public static Text NumAmmoDraugr0;
    public static Text NumAmmoDraugr1;
    #endregion
    
    #region Booleano riferimento per capire se è attivo o no
    bool isActivateWow = false;
    bool isActivateValvran = false;

    bool isActivateBlue = false;
    bool isActivateGreen = false;
    bool isActivateRed = false;
    bool isActivateYellow = false;
    bool isActivateEye = false;
    bool isActivateDraugr = false;
    bool isActivateDarkElf = false;
    #endregion

    #region Booleano temporaneo per attivo
    public static bool tempIsActiveWow = false;
    public static bool tempIsActiveValravn = false;

    public static bool tempIsActiveBlue = false;
    public static bool tempIsActiveGreen = false;
    public static bool tempIsActiveRed = false;
    public static bool tempIsActiveYellow = false;
    public static bool tempIsActiveEye = false;
    public static bool tempIsActiveDraugr = false;
    public static bool tempIsActiveDarkElf = false;
    #endregion
    
    //public static RawImage RuneRawImageWilloWisp0;
    //public static RawImage RuneRawImageValvran1;
    //public static RawImage RuneRawImageCooldownWilloWisp0;
    //public static RawImage RuneRawImageCooldownValvran1;
    //public static RawImage RuneRawImageValvran0;
    //public static RawImage RuneRawImageWilloWisp1;
    //public static RawImage RuneRawImageCooldownValvran0;
    //public static RawImage RuneRawImageCooldownWilloWisp1;

    #region Array

    public RawImage SlotRuneOne;
    public RawImage SlotRuneTwo;

    public Texture[] RuneWowTexture = new Texture[2];
    public Texture[] RuneValravnTexture = new Texture[2];
    public Texture[] RuneBlueTexture = new Texture[2];
    public Texture[] RuneYellowTexture = new Texture[2];
    public Texture[] RuneGreenTexture = new Texture[2];
    public Texture[] RuneRedTexture = new Texture[2];
    public Texture[] RuneEyeTexture = new Texture[2];

    #endregion



    Scene CurrentScene;
    private void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
        //if (CurrentScene.name == "FirstLevel")
        //{
            NumAmmoW0 = GameObject.Find("NumberAmmoWillOWispText0").GetComponent<Text>();
            NumAmmoW1 = GameObject.Find("NumberAmmoWillOWispText1").GetComponent<Text>();
            NumAmmoV0 = GameObject.Find("NumberAmmoValvranText0").GetComponent<Text>();
            NumAmmoV1 = GameObject.Find("NumberAmmoValvranText1").GetComponent<Text>();

            NumAmmoW0.gameObject.SetActive(false);
            NumAmmoW1.gameObject.SetActive(false);
            NumAmmoV0.gameObject.SetActive(false);
            NumAmmoV1.gameObject.SetActive(false);

            //RuneRawImageWilloWisp0 = GameObject.Find("RuneWillOWispRawImage0").GetComponent<RawImage>();
            //RuneRawImageWilloWisp1 = GameObject.Find("RuneWillOWispRawImage1").GetComponent<RawImage>();
            //RuneRawImageValvran0 = GameObject.Find("RuneValvranRawImage0").GetComponent<RawImage>();
            //RuneRawImageValvran1 = GameObject.Find("RuneValvranRawImage1").GetComponent<RawImage>();

            RuneRawImageWilloWisp0.enabled = false;
            RuneRawImageWilloWisp1.enabled = false;
            RuneRawImageValvran0.enabled = false;
            RuneRawImageValvran1.enabled = false;

            //RuneRawImageCooldownWilloWisp0 = GameObject.Find("RuneWillOWispCooldownRawImage0").GetComponent<RawImage>();
            //RuneRawImageCooldownWilloWisp1 = GameObject.Find("RuneWillOWispCooldownRawImage1").GetComponent<RawImage>();
            //RuneRawImageCooldownValvran0 = GameObject.Find("RuneValvranCooldownRawImage0").GetComponent<RawImage>();
            //RuneRawImageCooldownValvran1 = GameObject.Find("RuneValvranCooldownRawImage1").GetComponent<RawImage>();

            RuneRawImageCooldownWilloWisp0.enabled = false;
            RuneRawImageCooldownWilloWisp1.enabled = false;
            RuneRawImageCooldownValvran0.enabled = false;
            RuneRawImageCooldownValvran1.enabled = false;


        #region 

        #endregion



        //}
        if (CurrentScene.name == "ThirdLevel")
        {
            if(tempIsActiveWow == true)
            {
                RuneRawImageWilloWisp0.enabled = true;
                NumAmmoW0.gameObject.SetActive(true);
                //if l'altro oggetto è il seguente
                RuneRawImageValvran1.enabled = true;
                NumAmmoV1.gameObject.SetActive(true);
                isFirstRuneWow = true;
                isFirstRuneValvran = true;
                NumAmmoW0.text = AmmoW.ToString();
                NumAmmoV1.text = AmmoV.ToString();
            
            }
            if (tempIsActiveValravn == true)
            {
                RuneRawImageValvran0.enabled = true;
                NumAmmoV0.gameObject.SetActive(true);
                //if l'altro oggetto è il seguente
                RuneRawImageWilloWisp1.enabled = true;
                NumAmmoW1.gameObject.SetActive(true);
                isFirstRuneWow = true;
                isFirstRuneValvran = true;
                NumAmmoV0.text = AmmoV.ToString();
                NumAmmoW1.text = AmmoW.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        #region Rune Will o Wisp
        if (other.gameObject.tag == "RuneWow" && isFirstRuneWow == false)   //Se non ho già raccolto la runa
        {
            if(InventorySystem.tempIImageWow == 0 && isActivateValvran == false)            //Slot runa uno
            { 
                //RuneRawImageWilloWisp0.enabled = true;
                SlotRuneOne.texture = RuneWowTexture[0];
                
                
                
                
                
                
                
                NumAmmoW0.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW0.text = AmmoW.ToString();
                isActivateWow = true;
                tempIsActiveWow = true;
            } //Se l'immagine 
            if (isActivateValvran == true)                                                  //Slot runa due
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneWowTexture[0];
                NumAmmoW1.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW1.text = AmmoW.ToString();
            }
            if (isActivateBlue == true)                                                  //Slot runa due
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneWowTexture[0];
                NumAmmoW1.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW1.text = AmmoW.ToString();
            }
            if (isActivateGreen == true)                                                  //Slot runa due
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneWowTexture[0];
                NumAmmoW1.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW1.text = AmmoW.ToString();
            }
            if (isActivateRed == true)                                                  //Slot runa due
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneWowTexture[0];
                NumAmmoW1.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW1.text = AmmoW.ToString();
            }
            if (isActivateYellow == true)                                                  //Slot runa due
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneWowTexture[0];
                NumAmmoW1.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW1.text = AmmoW.ToString();
            }
            if (isActivateEye == true)                                                  //Slot runa due
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneWowTexture[0];
                NumAmmoW1.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW1.text = AmmoW.ToString();
            }
            if (isActivateDarkElf == true)                                                  //Slot runa due
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneWowTexture[0];
                NumAmmoW1.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW1.text = AmmoW.ToString();
            }
            if (isActivateDraugr== true)                                                  //Slot runa due
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneWowTexture[0];
                NumAmmoW1.gameObject.SetActive(true);
                AmmoW = 10;
                RuneWoW = other.gameObject;
                isFirstRuneWow = true;
                Debug.Log(AmmoW);
                NumAmmoW1.text = AmmoW.ToString();
            }
        }
        else if(other.gameObject.tag == "RuneWow" && isFirstRuneWow == true)    //Se ho già raccolto la runa
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









        #region Cose non ottimizzate


        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {
            if (InventorySystem.tempIImageValvran == 0 && isActivateWow == false)
            {
                //RuneRawImageValvran0.enabled = true;
                SlotRuneOne.texture = RuneValravnTexture[0];
                NumAmmoV0.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV0.text = AmmoV.ToString();
                isActivateValvran = true;
                tempIsActiveValravn = true;
            }
            if (isActivateWow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateBlue == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateGreen == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateRed == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateYellow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateEye == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDarkElf == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDraugr == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
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




        #region Rune Blue
        if (other.gameObject.tag == "RuneBlue" && isFirstRuneBlue == false)
        {
            if (InventorySystem.tempIImageBlue == 0 && isActivateWow == false)
            {
                //RuneRawImageValvran0.enabled = true;
                SlotRuneOne.texture = RuneValravnTexture[0];
                NumAmmoV0.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV0.text = AmmoV.ToString();
                isActivateValvran = true;
                tempIsActiveValravn = true;
            }
            if (isActivateWow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateBlue == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateGreen == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateRed == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateYellow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateEye == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDarkElf == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDraugr == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
        }
        else if (other.gameObject.tag == "RuneBlue" && isFirstRuneValvran == true)
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
        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {
            if (InventorySystem.tempIImageValvran == 0 && isActivateWow == false)
            {
                //RuneRawImageValvran0.enabled = true;
                SlotRuneOne.texture = RuneValravnTexture[0];
                NumAmmoV0.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV0.text = AmmoV.ToString();
                isActivateValvran = true;
                tempIsActiveValravn = true;
            }
            if (isActivateWow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateBlue == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateGreen == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateRed == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateYellow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateEye == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDarkElf == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDraugr == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
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
        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {
            if (InventorySystem.tempIImageValvran == 0 && isActivateWow == false)
            {
                //RuneRawImageValvran0.enabled = true;
                SlotRuneOne.texture = RuneValravnTexture[0];
                NumAmmoV0.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV0.text = AmmoV.ToString();
                isActivateValvran = true;
                tempIsActiveValravn = true;
            }
            if (isActivateWow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateBlue == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateGreen == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateRed == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateYellow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateEye == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDarkElf == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDraugr == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
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
        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {
            if (InventorySystem.tempIImageValvran == 0 && isActivateWow == false)
            {
                //RuneRawImageValvran0.enabled = true;
                SlotRuneOne.texture = RuneValravnTexture[0];
                NumAmmoV0.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV0.text = AmmoV.ToString();
                isActivateValvran = true;
                tempIsActiveValravn = true;
            }
            if (isActivateWow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateBlue == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateGreen == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateRed == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateYellow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateEye == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDarkElf == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDraugr == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
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
        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {
            if (InventorySystem.tempIImageValvran == 0 && isActivateWow == false)
            {
                //RuneRawImageValvran0.enabled = true;
                SlotRuneOne.texture = RuneValravnTexture[0];
                NumAmmoV0.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV0.text = AmmoV.ToString();
                isActivateValvran = true;
                tempIsActiveValravn = true;
            }
            if (isActivateWow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateBlue == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateGreen == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateRed == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateYellow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateEye == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDarkElf == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDraugr == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
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
        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {
            if (InventorySystem.tempIImageValvran == 0 && isActivateWow == false)
            {
                //RuneRawImageValvran0.enabled = true;
                SlotRuneOne.texture = RuneValravnTexture[0];
                NumAmmoV0.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV0.text = AmmoV.ToString();
                isActivateValvran = true;
                tempIsActiveValravn = true;
            }
            if (isActivateWow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateBlue == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateGreen == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateRed == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateYellow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateEye == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDarkElf == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDraugr == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
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
        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {
            if (InventorySystem.tempIImageValvran == 0 && isActivateWow == false)
            {
                //RuneRawImageValvran0.enabled = true;
                SlotRuneOne.texture = RuneValravnTexture[0];
                NumAmmoV0.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV0.text = AmmoV.ToString();
                isActivateValvran = true;
                tempIsActiveValravn = true;
            }
            if (isActivateWow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateBlue == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateGreen == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateRed == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateYellow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateEye == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDarkElf == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDraugr == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
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
        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {
            if (InventorySystem.tempIImageValvran == 0 && isActivateWow == false)
            {
                //RuneRawImageValvran0.enabled = true;
                SlotRuneOne.texture = RuneValravnTexture[0];
                NumAmmoV0.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV0.text = AmmoV.ToString();
                isActivateValvran = true;
                tempIsActiveValravn = true;
            }
            if (isActivateWow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateBlue == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateGreen == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateRed == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateYellow == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateEye == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDarkElf == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
            }
            if (isActivateDraugr == true)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
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

        #endregion






























    }

    void Update()
    {
        Debug.Log(AmmoW);
        Debug.Log(AmmoV);
        #region Ammo Will o Wisp
            if (AmmoW <= 0)
            {
                if (CurrentScene.name == "FirsLevel")
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
                if (CurrentScene.name == "ThirdLevel")
                {
                    Destroy(InventorySystem.RuneWow.gameObject);
                    isFirstRuneWow = false;
                    RuneRawImageWilloWisp0.enabled = false;
                    RuneRawImageCooldownWilloWisp0.enabled = false;
                    NumAmmoW0.gameObject.SetActive(false);
                    RuneRawImageWilloWisp1.enabled = false;
                    RuneRawImageCooldownWilloWisp1.enabled = false;
                    NumAmmoW1.gameObject.SetActive(false);
                }
            }
        #endregion

        #region Ammo Valvran
            if (AmmoV <= 0)
            {
                if (CurrentScene.name == "FirsLevel")
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
                if (CurrentScene.name == "ThirdLevel")
                {
                    Destroy(InventorySystem.RuneValravn.gameObject);
                    isFirstRuneValvran = false;
                    RuneRawImageValvran0.enabled = false;
                    RuneRawImageCooldownValvran0.enabled = false;
                    NumAmmoV0.gameObject.SetActive(false);
                    RuneRawImageValvran1.enabled = false;
                    RuneRawImageCooldownValvran1.enabled = false;
                    NumAmmoV1.gameObject.SetActive(false);
                }
            }
        #endregion
    }
}