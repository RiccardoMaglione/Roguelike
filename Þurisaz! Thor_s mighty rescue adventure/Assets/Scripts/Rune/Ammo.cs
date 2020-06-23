using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ammo : MonoBehaviour
{

    #region GameObject riferimento all'oggetto runa nella UI
    public static GameObject RuneWoW;
    public static GameObject RuneValvran;

    public static GameObject RuneBlue;
    public static GameObject RuneGreen;
    public static GameObject RuneYellow;
    public static GameObject RuneRed;
    public static GameObject RuneEye;
    public static GameObject RuneDarkElf;
    public static GameObject RuneDraugr;
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
    public bool isFirstRuneWow = false;
    public bool isFirstRuneValvran = false;

    public static bool tempIsFirstRuneWow = false;
    public static bool tempIsFirstRuneValvran = false;

    public bool isFirstRuneBlue = false;
    public bool isFirstRuneGreen = false;
    public bool isFirstRuneYellow = false;
    public bool isFirstRuneRed = false;
    public bool isFirstRuneEye = false;
    public bool isFirstRuneDarkElf = false;
    public bool isFirstRuneDraugr = false;
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
    public bool isActivateWow = false;
    public bool isActivateValvran = false;

    public bool isActivateBlue = false;
    public bool isActivateGreen = false;
    public bool isActivateRed = false;
    public bool isActivateYellow = false;
    public bool isActivateEye = false;
    public bool isActivateDraugr = false;
    public bool isActivateDarkElf = false;
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
    public Texture[] RuneDarkElfTexture = new Texture[2];
    public Texture[] RuneDraugrTexture = new Texture[2];

    #endregion

    public Texture AlphaTexture;

    bool isSlotOneOccupiedWow = false;
    bool isSlotOneOccupiedValravn = false;
    bool isSlotOneOccupiedEye = false;
    bool isSlotOneOccupiedGreen = false;
    bool isSlotOneOccupiedBlue = false;
    bool isSlotOneOccupiedRed = false;
    bool isSlotOneOccupiedYellow = false;
    bool isSlotOneOccupiedDraugr = false;
    bool isSlotOneOccupiedDarkElf = false;


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

        NumAmmoEye0 = GameObject.Find("NumberAmmoEyeText0").GetComponent<Text>();
        NumAmmoEye1 = GameObject.Find("NumberAmmoEyeText1").GetComponent<Text>();
        NumAmmoGreen0 = GameObject.Find("NumberAmmoGreenText0").GetComponent<Text>();
        NumAmmoGreen1 = GameObject.Find("NumberAmmoGreenText1").GetComponent<Text>();
        NumAmmoDarkElf0 = GameObject.Find("NumberAmmoDarkElfText0").GetComponent<Text>();
        NumAmmoDarkElf1 = GameObject.Find("NumberAmmoDarkElfText1").GetComponent<Text>();

        NumAmmoW0.gameObject.SetActive(false);
        NumAmmoW1.gameObject.SetActive(false);
        NumAmmoV0.gameObject.SetActive(false);
        NumAmmoV1.gameObject.SetActive(false);

        NumAmmoEye0.gameObject.SetActive(false);
        NumAmmoEye1.gameObject.SetActive(false);
        NumAmmoGreen0.gameObject.SetActive(false);
        NumAmmoGreen1.gameObject.SetActive(false);
        NumAmmoDarkElf0.gameObject.SetActive(false);
        NumAmmoDarkElf1.gameObject.SetActive(false);

        SlotRuneOne.texture = AlphaTexture;
        SlotRuneTwo.texture = AlphaTexture;
            //RuneRawImageWilloWisp0 = GameObject.Find("RuneWillOWispRawImage0").GetComponent<RawImage>();
            //RuneRawImageWilloWisp1 = GameObject.Find("RuneWillOWispRawImage1").GetComponent<RawImage>();
            //RuneRawImageValvran0 = GameObject.Find("RuneValvranRawImage0").GetComponent<RawImage>();
            //RuneRawImageValvran1 = GameObject.Find("RuneValvranRawImage1").GetComponent<RawImage>();

            //RuneRawImageWilloWisp0.enabled = false;
            //RuneRawImageWilloWisp1.enabled = false;
            //RuneRawImageValvran0.enabled = false;
            //RuneRawImageValvran1.enabled = false;


            //RuneRawImageCooldownWilloWisp0 = GameObject.Find("RuneWillOWispCooldownRawImage0").GetComponent<RawImage>();
            //RuneRawImageCooldownWilloWisp1 = GameObject.Find("RuneWillOWispCooldownRawImage1").GetComponent<RawImage>();
            //RuneRawImageCooldownValvran0 = GameObject.Find("RuneValvranCooldownRawImage0").GetComponent<RawImage>();
            //RuneRawImageCooldownValvran1 = GameObject.Find("RuneValvranCooldownRawImage1").GetComponent<RawImage>();

            //RuneRawImageCooldownWilloWisp0.enabled = false;
            //RuneRawImageCooldownWilloWisp1.enabled = false;
            //RuneRawImageCooldownValvran0.enabled = false;
            //RuneRawImageCooldownValvran1.enabled = false;

        //}
        if (CurrentScene.name == "ThirdLevel")          //Nel primo piano ci sono solo due mostri quindi non mi servono le altre referenze
        {
            if(tempIsActiveWow == true)
            {
                if(tempIsFirstRuneWow == true)
                {
                    isActivateWow = tempIsActiveWow;                                        //Sistemare, problema è che se nel primo non prendo una runa, nel secondo la ho, anche se non la posso usare
                    //RuneRawImageWilloWisp0.enabled = true;                                
                    SlotRuneOne.texture = RuneWowTexture[0];                                
                    NumAmmoW0.gameObject.SetActive(true);                                   
                    //if l'altro oggetto è il seguente                                      
                    isFirstRuneWow = true;                                                  
                    NumAmmoW0.text = AmmoW.ToString();                                      
                }
                if(tempIsFirstRuneValvran == true)
                {
                    SlotRuneTwo.texture = RuneValravnTexture[0];                            
                    //RuneRawImageValvran1.enabled = true;                                  
                    NumAmmoV1.gameObject.SetActive(true);                                   
                    isFirstRuneValvran = true;                                              
                    NumAmmoV1.text = AmmoV.ToString();                                      
                }
                                                                                        
            }                                                                           
            if (tempIsActiveValravn == true)                                            
            {
                if (tempIsFirstRuneValvran == true)
                {
                    isActivateValvran = tempIsActiveValravn;
                    //RuneRawImageValvran0.enabled = true;                                  
                    SlotRuneOne.texture = RuneValravnTexture[0];
                    NumAmmoV0.gameObject.SetActive(true);
                    //if l'altro oggetto è il seguente        
                    isFirstRuneValvran = true;
                    NumAmmoV0.text = AmmoV.ToString();
                }
                if (tempIsFirstRuneWow == true)
                {
                    SlotRuneTwo.texture = RuneWowTexture[0];
                    //RuneRawImageWilloWisp1.enabled = true;                                
                    NumAmmoW1.gameObject.SetActive(true);
                    isFirstRuneWow = true;
                    NumAmmoW1.text = AmmoW.ToString();
                }
            }


            #region Ammo of monster of third floor
            //NumAmmoW0 = GameObject.Find("NumberAmmoWillOWispText0").GetComponent<Text>();
            //NumAmmoW1 = GameObject.Find("NumberAmmoWillOWispText1").GetComponent<Text>();
            //NumAmmoV0 = GameObject.Find("NumberAmmoValvranText0").GetComponent<Text>();
            //NumAmmoV1 = GameObject.Find("NumberAmmoValvranText1").GetComponent<Text>();
            //
            //NumAmmoW0.gameObject.SetActive(false);
            //NumAmmoW1.gameObject.SetActive(false);
            //NumAmmoV0.gameObject.SetActive(false);
            //NumAmmoV1.gameObject.SetActive(false);
            #endregion
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        #region Set Ammo

        #region Rune Will o Wisp
        if (other.gameObject.tag == "RuneWow" && isFirstRuneWow == false)   //Se non ho già raccolto la runa
        {
            if(InventorySystem.tempIImageWow == 0 && (isActivateValvran == false && isActivateBlue == false && isActivateGreen == false && isActivateRed == false && isActivateYellow == false && isActivateEye == false && isActivateDarkElf == false && isActivateDraugr == false))            //Slot runa uno
            { 
                //RuneRawImageWilloWisp0.enabled = true;
                SlotRuneOne.texture = RuneWowTexture[0];    //Sostituisce la texture della runa uno con la texture del wow
                NumAmmoW0.gameObject.SetActive(true);       //Attiva le ammo del wisp nello slots uno
                AmmoW = 10;                                 //Setta le ammo del wow a 10
                RuneWoW = other.gameObject;                 //Mette in runa wow in una variabile
                isFirstRuneWow = true;                      //Segna che la prima runa del wow è stata presa
                tempIsFirstRuneWow = true;
                Debug.Log(AmmoW);                           //Scrivo a console quante ammo ha il willowisp
                NumAmmoW0.text = AmmoW.ToString();          //Aggiorno il testo
                isActivateWow = true;                       //Setto a vero l'attivazione del wow
                tempIsActiveWow = true;                     //Setto a vero la temp dell'attivazione 
                isSlotOneOccupiedWow = true;
            }
            //if (isActivateValvran == true || isActivateBlue == true || isActivateGreen == true || isActivateRed == true || isActivateYellow == true || isActivateEye == true || isActivateDarkElf == true || isActivateDraugr == true)                  //Vede che la runa uno è occupata dal valravn o dalle altre in questione quindi mette la runa due
            if(SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedWow == false)
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneWowTexture[0];    //Sostituisce la texture della runa due
                NumAmmoW1.gameObject.SetActive(true);       //Attiva le ammo del wisp nello slots due
                AmmoW = 10;                                 //Setta le ammo del wow a 10
                RuneWoW = other.gameObject;                 //Mette in runa wow in una variabile
                isFirstRuneWow = true;                      //Segna che la prima runa del wow è stata presa
                tempIsFirstRuneWow = true;
                Debug.Log(AmmoW);                           //Scrivo a console quante rune ha il willowisp
                NumAmmoW1.text = AmmoW.ToString();          //Aggiorno il testo
            }
        }
        else if(other.gameObject.tag == "RuneWow" && isFirstRuneWow == true)    //Se ho già raccolto la runa
        {
            AmmoW += 10;
            Debug.Log("Aumenta");
            if (InventorySystem.tempIImageWow == 0) //Se la runa sta nello slot 0
            {
                NumAmmoW0.text = AmmoW.ToString();  //Aumenta le ammo dello slot 0
            }
            if (InventorySystem.tempIImageWow == 1) //Se la runa sta nello slot 1
            {
                NumAmmoW1.text = AmmoW.ToString();  //Aumenta le ammo dello slot 1
            }
            Destroy(other.gameObject);
        }
        #endregion

        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {
            if (InventorySystem.tempIImageValvran == 0 && (isActivateWow == false && isActivateBlue == false && isActivateGreen == false && isActivateRed == false && isActivateYellow == false && isActivateEye == false && isActivateDarkElf == false && isActivateDraugr == false))              //Slot runa uno
            {
                //RuneRawImageValvran0.enabled = true;
                Debug.Log("Lo stai mettendo qua?");
                SlotRuneOne.texture = RuneValravnTexture[0];    //Sostituisce la texture della runa uno con la texture del valravn
                NumAmmoV0.gameObject.SetActive(true);           //Attiva le ammo del valravn nello slots uno
                AmmoV = 10;                                     //Setta le ammo del valravn a 10
                RuneValvran = other.gameObject;                 //Mette in runa valravn in una variabile
                isFirstRuneValvran = true;                      //Segna che la prima runa del valravn è stata presa
                tempIsFirstRuneValvran = true;
                Debug.Log(AmmoV);                               //Scrivo a console quante ammo ha il valravn
                NumAmmoV0.text = AmmoV.ToString();              //Aggiorno il testo
                isActivateValvran = true;                       //Setto a vero l'attivazione del wow
                tempIsActiveValravn = true;                     //Setto a vero la temp dell'attivazione 
                isSlotOneOccupiedValravn = true;
            }
            //if (isActivateWow == true || isActivateBlue == true || isActivateGreen == true || isActivateRed == true || isActivateYellow == true || isActivateEye == true || isActivateDarkElf == true || isActivateDraugr == true)              //Vede che la runa uno è occupata dal wow o dalle altre in questione quindi mette la runa due
            if(SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedValravn == false)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 10;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                tempIsFirstRuneValvran = true;
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
                Debug.Log("AumentaValravn0");
            }
            if (InventorySystem.tempIImageValvran == 1)
            {
                NumAmmoV1.text = AmmoV.ToString();
                Debug.Log("AumentaValravn1");
            }
            Destroy(other.gameObject);
        }
        #endregion

        #region Rune Blue
        if (other.gameObject.tag == "RuneBlue" && isFirstRuneBlue == false)   //Se non ho già raccolto la runa
        {
            if (InventorySystem.tempIImageBlue == 0 && (isActivateWow == false && isActivateValvran == false && isActivateGreen == false && isActivateRed == false && isActivateYellow == false && isActivateEye == false && isActivateDarkElf == false && isActivateDraugr == false))            //Slot runa uno
            {
                //RuneRawImageWilloWisp0.enabled = true;
                SlotRuneOne.texture = RuneBlueTexture[0];    //Sostituisce la texture della runa uno con la texture del blue
                NumAmmoBlue0.gameObject.SetActive(true);     //Attiva le ammo del blue nello slots uno
                AmmoBlue = 10;                               //Setta le ammo del blue a 10
                RuneBlue = other.gameObject;                 //Mette in runa blue in una variabile
                isFirstRuneBlue = true;                      //Segna che la prima runa del blue è stata presa
                Debug.Log(AmmoBlue);                         //Scrivo a console quante ammo ha il blue
                NumAmmoBlue0.text = AmmoBlue.ToString();     //Aggiorno il testo
                isActivateBlue = true;                       //Setto a vero l'attivazione del blue
                tempIsActiveBlue = true;                     //Setto a vero la temp dell'attivazione 
                isSlotOneOccupiedBlue = true;
            }
            //if (isActivateWow == true || isActivateValvran == true || isActivateGreen == true || isActivateRed == true || isActivateYellow == true || isActivateEye == true || isActivateDarkElf == true || isActivateDraugr == true)                  //Vede che la runa uno è occupata dal valravn o dalle altre in questione quindi mette la runa due
            if(SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedBlue == false)
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneBlueTexture[0];    //Sostituisce la texture della runa due
                NumAmmoBlue1.gameObject.SetActive(true);     //Attiva le ammo del blue nello slots due
                AmmoBlue = 10;                               //Setta le ammo del blue a 10
                RuneBlue = other.gameObject;                 //Mette in runa blue in una variabile
                isFirstRuneBlue = true;                      //Segna che la prima runa del blue è stata presa
                Debug.Log(AmmoBlue);                         //Scrivo a console quante rune ha il blue
                NumAmmoBlue1.text = AmmoBlue.ToString();     //Aggiorno il testo
            }
        }
        else if (other.gameObject.tag == "RuneBlue" && isFirstRuneBlue == true)    //Se ho già raccolto la runa
        {
            AmmoBlue += 10;
            if (InventorySystem.tempIImageBlue == 0)        //Se la runa sta nello slot 0
            {
                NumAmmoBlue0.text = AmmoBlue.ToString();    //Aumenta le ammo dello slot 0
            }
            if (InventorySystem.tempIImageBlue == 1)        //Se la runa sta nello slot 1
            {
                NumAmmoBlue1.text = AmmoBlue.ToString();    //Aumenta le ammo dello slot 1
            }
            Destroy(other.gameObject);
        }
        #endregion

        #region Rune Green
        if (other.gameObject.tag == "RuneGreen" && isFirstRuneGreen == false)   //Se non ho già raccolto la runa
        {
            if (InventorySystem.tempIImageGreen == 0 && (isActivateWow == false && isActivateValvran == false && isActivateBlue == false && isActivateRed == false && isActivateYellow == false && isActivateEye == false && isActivateDarkElf == false && isActivateDraugr == false))            //Slot runa uno
            {
                Debug.Log("La prima parte si attiva");
                //RuneRawImageWilloWisp0.enabled = true;
                SlotRuneOne.texture = RuneGreenTexture[0];    //Sostituisce la texture della runa uno con la texture del green
                NumAmmoGreen0.gameObject.SetActive(true);     //Attiva le ammo del green nello slots uno
                AmmoGreen = 10;                               //Setta le ammo del green a 10
                RuneGreen = other.gameObject;                 //Mette in runa green in una variabile
                isFirstRuneGreen = true;                      //Segna che la prima runa del green è stata presa
                Debug.Log(AmmoGreen);                         //Scrivo a console quante ammo ha il green
                NumAmmoGreen0.text = AmmoGreen.ToString();    //Aggiorno il testo
                isActivateGreen = true;                       //Setto a vero l'attivazione del green
                tempIsActiveGreen = true;                     //Setto a vero la temp dell'attivazione
                isSlotOneOccupiedGreen = true;
            }
            //if (isActivateWow == true || isActivateValvran == true || isActivateBlue == true || isActivateRed == true || isActivateYellow == true || isActivateEye == true || isActivateDarkElf == true || isActivateDraugr == true)                  //Vede che la runa uno è occupata dal valravn o dalle altre in questione quindi mette la runa due
            if(SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedGreen == false)
            {
                Debug.Log("La seconda parte si attiva");
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneGreenTexture[0];    //Sostituisce la texture della runa due
                NumAmmoGreen1.gameObject.SetActive(true);     //Attiva le ammo del green nello slots due
                AmmoGreen = 10;                               //Setta le ammo del green a 10
                RuneGreen = other.gameObject;                 //Mette in runa green in una variabile
                isFirstRuneGreen = true;                      //Segna che la prima runa del green è stata presa
                Debug.Log(AmmoGreen);                         //Scrivo a console quante rune ha il green
                NumAmmoGreen1.text = AmmoGreen.ToString();    //Aggiorno il testo
            }
        }
        else if (other.gameObject.tag == "RuneGreen" && isFirstRuneGreen == true)    //Se ho già raccolto la runa
        {
            Debug.Log("Qui Verde");
            AmmoGreen += 10;
            if (InventorySystem.tempIImageGreen == 0)            //Se la runa sta nello slot 0
            {
                NumAmmoGreen0.text = AmmoGreen.ToString();      //Aumenta le ammo dello slot 0
            }
            if (InventorySystem.tempIImageGreen == 1)            //Se la runa sta nello slot 1
            {
                NumAmmoGreen1.text = AmmoGreen.ToString();      //Aumenta le ammo dello slot 1
            }
            Destroy(other.gameObject);
        }
        #endregion

        #region Rune Red
        if (other.gameObject.tag == "RuneRed" && isFirstRuneRed == false)   //Se non ho già raccolto la runa
        {
            if (InventorySystem.tempIImageOrange == 0 && (isActivateWow == false && isActivateValvran == false && isActivateBlue == false && isActivateGreen == false && isActivateYellow == false && isActivateEye == false && isActivateDarkElf == false && isActivateDraugr == false))            //Slot runa uno
            {
                //RuneRawImageWilloWisp0.enabled = true;
                SlotRuneOne.texture = RuneRedTexture[0];    //Sostituisce la texture della runa uno con la texture del red
                NumAmmoRed0.gameObject.SetActive(true);     //Attiva le ammo del red nello slots uno
                AmmoRed = 10;                               //Setta le ammo del red a 10
                RuneRed = other.gameObject;                 //Mette in runa red in una variabile
                isFirstRuneRed = true;                      //Segna che la prima runa del red è stata presa
                Debug.Log(AmmoRed);                         //Scrivo a console quante ammo ha il red
                NumAmmoRed0.text = AmmoRed.ToString();      //Aggiorno il testo
                isActivateRed = true;                       //Setto a vero l'attivazione del red
                tempIsActiveRed = true;                     //Setto a vero la temp dell'attivazione
                isSlotOneOccupiedRed = true;
            }
            //if (isActivateWow == true || isActivateValvran == true || isActivateBlue == true || isActivateGreen == true || isActivateYellow == true || isActivateEye == true || isActivateDarkElf == true || isActivateDraugr == true)                  //Vede che la runa uno è occupata dal valravn o dalle altre in questione quindi mette la runa due
            if(SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedRed == false)
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneRedTexture[0];    //Sostituisce la texture della runa due
                NumAmmoRed1.gameObject.SetActive(true);     //Attiva le ammo del red nello slots due
                AmmoRed = 10;                               //Setta le ammo del red a 10
                RuneRed = other.gameObject;                 //Mette in runa red in una variabile
                isFirstRuneRed = true;                      //Segna che la prima runa del red è stata presa
                Debug.Log(AmmoRed);                         //Scrivo a console quante rune ha il red
                NumAmmoRed1.text = AmmoRed.ToString();      //Aggiorno il testo
            }
        }
        else if (other.gameObject.tag == "RuneRed" && isFirstRuneRed == true)    //Se ho già raccolto la runa
        {
            AmmoRed += 10;
            if (InventorySystem.tempIImageOrange == 0)              //Se la runa sta nello slot 0
            {
                NumAmmoRed0.text = AmmoRed.ToString();              //Aumenta le ammo dello slot 0
            }
            if (InventorySystem.tempIImageOrange == 1)              //Se la runa sta nello slot 1
            {
                NumAmmoRed1.text = AmmoRed.ToString();              //Aumenta le ammo dello slot 1
            }
            Destroy(other.gameObject);
        }
        #endregion

        #region Rune Yellow
        if (other.gameObject.tag == "RuneYellow" && isFirstRuneYellow == false)   //Se non ho già raccolto la runa
        {
            if (InventorySystem.tempIImageYellow == 0 && (isActivateWow == false && isActivateValvran == false && isActivateBlue == false && isActivateGreen == false && isActivateRed == false && isActivateEye == false && isActivateDarkElf == false && isActivateDraugr == false))            //Slot runa uno
            {
                //RuneRawImageWilloWisp0.enabled = true;
                SlotRuneOne.texture = RuneYellowTexture[0];    //Sostituisce la texture della runa uno con la texture del yellow
                NumAmmoYellow0.gameObject.SetActive(true);     //Attiva le ammo del red nello slots uno
                AmmoYellow = 10;                               //Setta le ammo del yellow a 10
                RuneYellow = other.gameObject;                 //Mette in runa yellow in una variabile
                isFirstRuneYellow = true;                      //Segna che la prima runa del yellow è stata presa
                Debug.Log(AmmoYellow);                         //Scrivo a console quante ammo ha il yellow
                NumAmmoYellow0.text = AmmoYellow.ToString();   //Aggiorno il testo
                isActivateYellow = true;                       //Setto a vero l'attivazione del yellow
                tempIsActiveYellow = true;                     //Setto a vero la temp dell'attivazione 
                isSlotOneOccupiedYellow = true;
            }
            //if (isActivateWow == true || isActivateValvran == true || isActivateBlue == true || isActivateGreen == true || isActivateRed == true || isActivateEye == true || isActivateDarkElf == true || isActivateDraugr == true)                  //Vede che la runa uno è occupata dal valravn o dalle altre in questione quindi mette la runa due
            if(SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedYellow == false)
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneYellowTexture[0];    //Sostituisce la texture della runa due
                NumAmmoYellow1.gameObject.SetActive(true);     //Attiva le ammo del yellow nello slots due
                AmmoYellow = 10;                               //Setta le ammo del yellow a 10
                RuneYellow = other.gameObject;                 //Mette in runa yellow in una variabile
                isFirstRuneYellow = true;                      //Segna che la prima runa del yellow è stata presa
                Debug.Log(AmmoYellow);                         //Scrivo a console quante rune ha il yellow
                NumAmmoYellow1.text = AmmoYellow.ToString();   //Aggiorno il testo
            }
        }
        else if (other.gameObject.tag == "RuneYellow" && isFirstRuneYellow == true)    //Se ho già raccolto la runa
        {
            AmmoYellow += 10;
            if (InventorySystem.tempIImageYellow == 0)                      //Se la runa sta nello slot 0
            {
                NumAmmoYellow0.text = AmmoYellow.ToString();                //Aumenta le ammo dello slot 0
            }
            if (InventorySystem.tempIImageYellow == 1)                      //Se la runa sta nello slot 1
            {
                NumAmmoYellow1.text = AmmoYellow.ToString();                //Aumenta le ammo dello slot 1
            }
            Destroy(other.gameObject);
        }
        #endregion

        #region Rune Eye
        if (other.gameObject.tag == "RuneEye" && isFirstRuneEye == false)   //Se non ho già raccolto la runa
        {
            Debug.Log("Qui Occhio falso" + isSlotOneOccupiedEye);
            if (InventorySystem.tempIImageEye == 0 && (isActivateWow == false && isActivateValvran == false && isActivateBlue == false && isActivateGreen == false && isActivateRed == false && isActivateYellow == false && isActivateDarkElf == false && isActivateDraugr == false))            //Slot runa uno
            {
                Debug.Log("La prima parte si attiva");
                //RuneRawImageWilloWisp0.enabled = true;
                SlotRuneOne.texture = RuneEyeTexture[0];    //Sostituisce la texture della runa uno con la texture del eye
                NumAmmoEye0.gameObject.SetActive(true);     //Attiva le ammo del eye nello slots uno
                AmmoEye = 10;                               //Setta le ammo del eye a 10
                RuneEye = other.gameObject;                 //Mette in runa eye in una variabile
                isFirstRuneEye = true;                      //Segna che la prima runa del eye è stata presa
                Debug.Log(AmmoEye);                         //Scrivo a console quante ammo ha il eye
                NumAmmoEye0.text = AmmoEye.ToString();      //Aggiorno il testo
                isActivateEye = true;                       //Setto a vero l'attivazione del eye
                tempIsActiveEye = true;                     //Setto a vero la temp dell'attivazione
                isSlotOneOccupiedEye = true;
            }
            if (SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedEye == false)                  //Vede che la runa uno è occupata dal valravn o dalle altre in questione quindi mette la runa due
            {
                Debug.Log("La seconda parte si attiva");
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneEyeTexture[0];    //Sostituisce la texture della runa due
                NumAmmoEye1.gameObject.SetActive(true);     //Attiva le ammo del eye nello slots due
                AmmoEye = 10;                               //Setta le ammo del eye a 10
                RuneEye = other.gameObject;                 //Mette in runa eye in una variabile
                isFirstRuneEye = true;                      //Segna che la prima runa del eye è stata presa
                Debug.Log(AmmoEye);                         //Scrivo a console quante rune ha il eye
                NumAmmoEye1.text = AmmoEye.ToString();      //Aggiorno il testo
            }
        }
        else if (other.gameObject.tag == "RuneEye" && isFirstRuneEye == true)    //Se ho già raccolto la runa
        {
            Debug.Log("Qui Occhio");
            AmmoEye += 10;
            if (InventorySystem.tempIImageEye == 0)                 //Se la runa sta nello slot 0
            {
                NumAmmoEye0.text = AmmoEye.ToString();              //Aumenta le ammo dello slot 0
            }
            if (InventorySystem.tempIImageEye == 1)                 //Se la runa sta nello slot 1
            {
                NumAmmoEye1.text = AmmoEye.ToString();              //Aumenta le ammo dello slot 1
            }
            Destroy(other.gameObject);
        }
        #endregion

        #region Rune Dark Elf
        if (other.gameObject.tag == "RuneDarkElf" && isFirstRuneDarkElf == false)   //Se non ho già raccolto la runa
        {
            if (InventorySystem.tempIImageDarkElf == 0 && (isActivateWow == false && isActivateValvran == false && isActivateBlue == false && isActivateGreen == false && isActivateRed == false && isActivateYellow == false && isActivateEye == false && isActivateDraugr == false))            //Slot runa uno
            {
                //RuneRawImageWilloWisp0.enabled = true;
                SlotRuneOne.texture = RuneDarkElfTexture[0];    //Sostituisce la texture della runa uno con la texture del dark elf
                NumAmmoDarkElf0.gameObject.SetActive(true);     //Attiva le ammo del dark elf nello slots uno
                AmmoDarkElf = 10;                               //Setta le ammo del dark elf a 10
                RuneDarkElf = other.gameObject;                 //Mette in runa dark elf in una variabile
                isFirstRuneDarkElf = true;                      //Segna che la prima runa del dark elf è stata presa
                Debug.Log(AmmoDarkElf);                         //Scrivo a console quante ammo ha il dark elf
                NumAmmoDarkElf0.text = AmmoDarkElf.ToString();  //Aggiorno il testo
                isActivateDarkElf = true;                       //Setto a vero l'attivazione del dark elf
                tempIsActiveDarkElf = true;                     //Setto a vero la temp dell'attivazione
                isSlotOneOccupiedDarkElf = true;
            }
            //if (isActivateWow == true || isActivateValvran == true || isActivateBlue == true || isActivateGreen == true || isActivateRed == true || isActivateYellow == true || isActivateEye == true || isActivateDraugr == true)                  //Vede che la runa uno è occupata dal valravn o dalle altre in questione quindi mette la runa due
            if(SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedDarkElf == false)
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneDarkElfTexture[0];    //Sostituisce la texture della runa due
                NumAmmoDarkElf1.gameObject.SetActive(true);     //Attiva le ammo del dark elf nello slots due
                AmmoDarkElf = 10;                               //Setta le ammo del dark elf a 10
                RuneDarkElf = other.gameObject;                 //Mette in runa dark elf in una variabile
                isFirstRuneDarkElf = true;                      //Segna che la prima runa del dark elf è stata presa
                Debug.Log(AmmoDarkElf);                         //Scrivo a console quante rune ha il dark elf
                NumAmmoDarkElf1.text = AmmoDarkElf.ToString();  //Aggiorno il testo
            }
        }
        else if (other.gameObject.tag == "RuneDarkElf" && isFirstRuneDarkElf == true)    //Se ho già raccolto la runa
        {
            AmmoDarkElf += 10;
            if (InventorySystem.tempIImageDarkElf == 0)                     //Se la runa sta nello slot 0
            {
                NumAmmoDarkElf0.text = AmmoDarkElf.ToString();              //Aumenta le ammo dello slot 0
            }
            if (InventorySystem.tempIImageDarkElf == 1)                     //Se la runa sta nello slot 1
            {
                NumAmmoDarkElf1.text = AmmoDarkElf.ToString();              //Aumenta le ammo dello slot 1
            }
            Destroy(other.gameObject);
        }
        #endregion

        #region Rune Draugr
        if (other.gameObject.tag == "RuneDraugr" && isFirstRuneDraugr == false)   //Se non ho già raccolto la runa
        {
            if (InventorySystem.tempIImageDraugr == 0 && (isActivateWow == false && isActivateValvran == false && isActivateBlue == false && isActivateGreen == false && isActivateRed == false && isActivateYellow == false && isActivateEye == false && isActivateDarkElf == false))            //Slot runa uno
            {
                //RuneRawImageWilloWisp0.enabled = true;
                SlotRuneOne.texture = RuneDraugrTexture[0];    //Sostituisce la texture della runa uno con la texture del draugr
                NumAmmoDraugr0.gameObject.SetActive(true);     //Attiva le ammo del draugr nello slots uno
                AmmoDraugr = 10;                               //Setta le ammo del draugr a 10
                RuneDraugr = other.gameObject;                 //Mette in runa draugr in una variabile
                isFirstRuneDraugr = true;                      //Segna che la prima runa del draugr è stata presa
                Debug.Log(AmmoDraugr);                         //Scrivo a console quante ammo ha il draugr
                NumAmmoDraugr0.text = AmmoDraugr.ToString();   //Aggiorno il testo
                isActivateDraugr = true;                       //Setto a vero l'attivazione del draugr
                tempIsActiveDraugr = true;                     //Setto a vero la temp dell'attivazione
                isSlotOneOccupiedDraugr = true;
            }
            //if (isActivateWow == true || isActivateValvran == true || isActivateBlue == true || isActivateGreen == true || isActivateRed == true || isActivateYellow == true || isActivateEye == true || isActivateDarkElf == true)                  //Vede che la runa uno è occupata dal valravn o dalle altre in questione quindi mette la runa due
            if(SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedDraugr == false)
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneDraugrTexture[0];    //Sostituisce la texture della runa due
                NumAmmoDraugr1.gameObject.SetActive(true);     //Attiva le ammo del draugr nello slots due
                AmmoDraugr = 10;                               //Setta le ammo del draugr a 10
                RuneDraugr = other.gameObject;                 //Mette in runa draugr in una variabile
                isFirstRuneDraugr = true;                      //Segna che la prima runa del draugr è stata presa
                Debug.Log(AmmoDraugr);                         //Scrivo a console quante rune ha il draugr
                NumAmmoDraugr1.text = AmmoDraugr.ToString();   //Aggiorno il testo
            }
        }
        else if (other.gameObject.tag == "RuneDraugr" && isFirstRuneDraugr == true)    //Se ho già raccolto la runa
        {
            AmmoDraugr += 10;
            if (InventorySystem.tempIImageDraugr == 0)                      //Se la runa sta nello slot 0
            {
                NumAmmoDraugr0.text = AmmoDraugr.ToString();                //Aumenta le ammo dello slot 0
            }
            if (InventorySystem.tempIImageDraugr == 1)                      //Se la runa sta nello slot 1
            {
                NumAmmoDraugr1.text = AmmoDraugr.ToString();                //Aumenta le ammo dello slot 1
            }
            Destroy(other.gameObject);
        }
        #endregion

        #endregion
    }

    void Update()
    {
        #region Debug Ammo
        Debug.Log("Le ammo del will o wisp " +AmmoW);
        Debug.Log("Le ammo del valravn " +AmmoV);
        Debug.Log("Le ammo del cervo blu " +AmmoBlue);
        Debug.Log("Le ammo del cervo verde " +AmmoGreen);
        Debug.Log("Le ammo del cervo rosso " +AmmoRed);
        Debug.Log("Le ammo del cervo giallo " +AmmoYellow);
        Debug.Log("Le ammo dell'occhio " +AmmoEye);
        Debug.Log("Le ammo del dark elf " +AmmoDarkElf);
        Debug.Log("Le ammo del draugr " + AmmoDraugr);
        #endregion

        #region Delete Ammo

        #region Ammo Will o Wisp
        if (AmmoW <= 0)
            {
                if (CurrentScene.name == "FirstLevel")
                {
                    Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo");
                    Destroy(RuneWoW.gameObject);
                    isFirstRuneWow = false;
                    //RuneRawImageWilloWisp0.enabled = false;
                    //RuneRawImageCooldownWilloWisp0.enabled = false;
                    if(InventorySystem.tempIImageWow == 0)
                    {
                        SlotRuneOne.texture = AlphaTexture;
                    }
                    if (InventorySystem.tempIImageWow == 1)
                    {
                        SlotRuneTwo.texture = AlphaTexture;
                    }
                    NumAmmoW0.gameObject.SetActive(false);
                    //RuneRawImageWilloWisp1.enabled = false;
                    //RuneRawImageCooldownWilloWisp1.enabled = false;
                    NumAmmoW1.gameObject.SetActive(false);
                    
                }
                if (CurrentScene.name == "ThirdLevel")
                {
                    Destroy(InventorySystem.RuneWow.gameObject);
                    isFirstRuneWow = false;
                    //RuneRawImageWilloWisp0.enabled = false;
                    //RuneRawImageCooldownWilloWisp0.enabled = false;
                    if (InventorySystem.tempIImageWow == 0)
                    {
                        SlotRuneOne.texture = AlphaTexture;
                    }
                    if (InventorySystem.tempIImageWow == 1)
                    {
                        SlotRuneTwo.texture = AlphaTexture;
                    }
                    NumAmmoW0.gameObject.SetActive(false);
                    //RuneRawImageWilloWisp1.enabled = false;
                    //RuneRawImageCooldownWilloWisp1.enabled = false;
                    NumAmmoW1.gameObject.SetActive(false);
                }
            }
        #endregion

        #region Ammo Valvran
            if (AmmoV <= 0)
            {
                if (CurrentScene.name == "FirstLevel")
                {
                    Destroy(RuneValvran.gameObject);
                    isFirstRuneValvran = false;
                    //RuneRawImageValvran0.enabled = false;
                    //RuneRawImageCooldownValvran0.enabled = false;
                    if (InventorySystem.tempIImageValvran == 0)
                    {
                        SlotRuneOne.texture = AlphaTexture;
                    }
                    if (InventorySystem.tempIImageValvran == 1)
                    {
                        SlotRuneTwo.texture = AlphaTexture;
                    }

                    NumAmmoV0.gameObject.SetActive(false);
                    //RuneRawImageValvran1.enabled = false;
                    //RuneRawImageCooldownValvran1.enabled = false;
                    NumAmmoV1.gameObject.SetActive(false);
                }
                if (CurrentScene.name == "ThirdLevel")
                {
                    Destroy(InventorySystem.RuneValravn.gameObject);
                    isFirstRuneValvran = false;
                    //RuneRawImageValvran0.enabled = false;
                    //RuneRawImageCooldownValvran0.enabled = false;
                    if (InventorySystem.tempIImageValvran == 0)
                    {
                        SlotRuneOne.texture = AlphaTexture;
                    }
                    if (InventorySystem.tempIImageValvran == 1)
                    {
                        SlotRuneTwo.texture = AlphaTexture;
                    }
                    NumAmmoV0.gameObject.SetActive(false);
                    //RuneRawImageValvran1.enabled = false;
                    //RuneRawImageCooldownValvran1.enabled = false;
                    NumAmmoV1.gameObject.SetActive(false);
                }
            }
        #endregion

        #region Ammo Blue
        if (AmmoBlue <= 0)
        {
            if (CurrentScene.name == "ThirdLevel")
            {
                Destroy(InventorySystem.RuneBlue.gameObject);
                isFirstRuneBlue = false;
                if (InventorySystem.tempIImageBlue == 0)
                {
                    SlotRuneOne.texture = AlphaTexture;
                }
                if (InventorySystem.tempIImageBlue == 1)
                {
                    SlotRuneTwo.texture = AlphaTexture;
                }
                NumAmmoBlue0.gameObject.SetActive(false);
                NumAmmoBlue1.gameObject.SetActive(false);
            }
        }
        #endregion

        #region Ammo Green
        if (AmmoGreen <= 0)
        {
            Debug.Log("verdeddeeeeeeeeeeeeeee");
            if (CurrentScene.name == "FirstLevel")
            {
                Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo, verdeddeeeeeeeeeeeeeee");
                Destroy(RuneGreen.gameObject);
                isFirstRuneGreen = false;
                Debug.Log("temp i image green "+ InventorySystem.tempIImageGreen);
                if (InventorySystem.tempIImageGreen == 0)
                {
                    Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo, 11111111111111111111111111");
                    SlotRuneOne.texture = AlphaTexture;
                }
                if (InventorySystem.tempIImageGreen == 1)
                {
                    Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo, 22222222222222222222");
                    SlotRuneTwo.texture = AlphaTexture;
                }
                NumAmmoGreen0.gameObject.SetActive(false);
                NumAmmoGreen1.gameObject.SetActive(false);
            }
        }
        #endregion

        #region Ammo Red
        if (AmmoRed <= 0)
        {
            if (CurrentScene.name == "ThirdLevel")
            {
                Destroy(InventorySystem.RuneRed.gameObject);
                isFirstRuneRed = false;
                if (InventorySystem.tempIImageOrange == 0)
                {
                    SlotRuneOne.texture = AlphaTexture;
                }
                if (InventorySystem.tempIImageOrange == 1)
                {
                    SlotRuneTwo.texture = AlphaTexture;
                }
                NumAmmoRed0.gameObject.SetActive(false);
                NumAmmoRed1.gameObject.SetActive(false);
            }
        }
        #endregion

        #region Ammo Yellow
        if (AmmoYellow <= 0)
        {
            if (CurrentScene.name == "ThirdLevel")
            {
                Destroy(InventorySystem.RuneYellow.gameObject);
                isFirstRuneYellow = false;
                if (InventorySystem.tempIImageYellow == 0)
                {
                    SlotRuneOne.texture = AlphaTexture;
                }
                if (InventorySystem.tempIImageYellow == 1)
                {
                    SlotRuneTwo.texture = AlphaTexture;
                }
                NumAmmoYellow0.gameObject.SetActive(false);
                NumAmmoYellow1.gameObject.SetActive(false);
            }
        }
        #endregion

        #region Ammo Eye
        if (AmmoEye <= 0)
        {
            if (CurrentScene.name == "FirstLevel")
            {
                Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo");
                Destroy(RuneEye.gameObject);
                isFirstRuneEye = false;
                if (InventorySystem.tempIImageEye == 0)
                {
                    SlotRuneOne.texture = AlphaTexture;
                }
                if (InventorySystem.tempIImageEye == 1)
                {
                    SlotRuneTwo.texture = AlphaTexture;
                }
                NumAmmoEye0.gameObject.SetActive(false);
                NumAmmoEye1.gameObject.SetActive(false);
            }
        }
        #endregion

        #region Ammo Dark Elf
        if (AmmoDarkElf <= 0)
        {
            if (CurrentScene.name == "FirstLevel")
            {
                Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo");
                Destroy(RuneDarkElf.gameObject);
                isFirstRuneDarkElf = false;
                if (InventorySystem.tempIImageDarkElf == 0)
                {
                    SlotRuneOne.texture = AlphaTexture;
                }
                if (InventorySystem.tempIImageDarkElf == 1)
                {
                    SlotRuneTwo.texture = AlphaTexture;
                }
                NumAmmoDarkElf0.gameObject.SetActive(false);
                NumAmmoDarkElf1.gameObject.SetActive(false);
            }
        }
        #endregion

        #region Ammo Draugr
        if (AmmoDraugr <= 0)
        {
            if (CurrentScene.name == "ThirdLevel")
            {
                Destroy(InventorySystem.RuneDraugr.gameObject);
                isFirstRuneDraugr = false;
                if (InventorySystem.tempIImageDraugr == 0)
                {
                    SlotRuneOne.texture = AlphaTexture;
                }
                if (InventorySystem.tempIImageDraugr == 1)
                {
                    SlotRuneTwo.texture = AlphaTexture;
                }
                NumAmmoDraugr0.gameObject.SetActive(false);
                NumAmmoDraugr1.gameObject.SetActive(false);
            }
        }
        #endregion

        #endregion
    }
}