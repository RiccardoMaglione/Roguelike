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
    public static int AmmoW = 1;
    public static int AmmoV = 1;

    public static int AmmoBlue = 1;
    public static int AmmoGreen = 1;
    public static int AmmoYellow = 1;
    public static int AmmoRed = 1;
    public static int AmmoEye = 1;
    public static int AmmoDarkElf = 1;
    public static int AmmoDraugr = 1;
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

    public static bool tempIsFirstRuneGreen = false;
    public static bool tempIsFirstRuneEye = false;
    public static bool tempIsFirstRuneDarkElf = false;
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

    public bool isSlotOneOccupiedWow = false;
    public bool isSlotOneOccupiedValravn = false;
    public bool isSlotOneOccupiedEye = false;
    public bool isSlotOneOccupiedGreen = false;
    public bool isSlotOneOccupiedBlue = false;
    public bool isSlotOneOccupiedRed = false;
    public bool isSlotOneOccupiedYellow = false;
    public bool isSlotOneOccupiedDraugr = false;
    public bool isSlotOneOccupiedDarkElf = false;


    Scene CurrentScene;

    public static bool RestartWow = true;
    public static bool RestartValravn = true;
    public static bool RestartEye = true;
    public static bool RestartGreen = true;
    public static bool RestartDarkElf = true;

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

        isSlotOneOccupiedWow = false;
        isSlotOneOccupiedValravn = false;
        isSlotOneOccupiedEye = false;
        isSlotOneOccupiedGreen = false;
        isSlotOneOccupiedBlue = false;
        isSlotOneOccupiedRed = false;
        isSlotOneOccupiedYellow = false;
        isSlotOneOccupiedDraugr = false;
        isSlotOneOccupiedDarkElf = false;

        SlotRuneOne.texture = AlphaTexture;
        SlotRuneTwo.texture = AlphaTexture;

        isActivateWow = tempIsActiveWow;
        isActivateValvran = tempIsActiveValravn;
        isActivateGreen = tempIsActiveGreen;
        isActivateEye = tempIsActiveEye;
        isActivateDarkElf = tempIsActiveDarkElf;

        isFirstRuneWow = tempIsFirstRuneWow;
        isFirstRuneValvran = tempIsFirstRuneValvran;
        isFirstRuneGreen = tempIsFirstRuneGreen;
        isFirstRuneEye = tempIsFirstRuneEye;
        isFirstRuneDarkElf = tempIsFirstRuneDarkElf;

        //InventorySystem.i += 5;
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
                AmmoW = 4;                                 //Setta le ammo del wow a 10
                RuneWoW = other.gameObject;                 //Mette in runa wow in una variabile
                isFirstRuneWow = true;                      //Segna che la prima runa del wow è stata presa
                tempIsFirstRuneWow = true;
                Debug.Log(AmmoW);                           //Scrivo a console quante ammo ha il willowisp
                NumAmmoW0.text = AmmoW.ToString();          //Aggiorno il testo
                isActivateWow = true;                       //Setto a vero l'attivazione del wow
                tempIsActiveWow = true;                     //Setto a vero la temp dell'attivazione 
                isSlotOneOccupiedWow = true;
                Debug.Log("Eseguo Ammo 1");
            }
            //if (isActivateValvran == true || isActivateBlue == true || isActivateGreen == true || isActivateRed == true || isActivateYellow == true || isActivateEye == true || isActivateDarkElf == true || isActivateDraugr == true)                  //Vede che la runa uno è occupata dal valravn o dalle altre in questione quindi mette la runa due
            if(SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedWow == false)
            {
                //RuneRawImageWilloWisp1.enabled = true;
                SlotRuneTwo.texture = RuneWowTexture[0];    //Sostituisce la texture della runa due
                NumAmmoW1.gameObject.SetActive(true);       //Attiva le ammo del wisp nello slots due
                AmmoW = 4;                                 //Setta le ammo del wow a 10
                RuneWoW = other.gameObject;                 //Mette in runa wow in una variabile
                isFirstRuneWow = true;                      //Segna che la prima runa del wow è stata presa
                tempIsFirstRuneWow = true;
                Debug.Log(AmmoW);                           //Scrivo a console quante rune ha il willowisp
                NumAmmoW1.text = AmmoW.ToString();          //Aggiorno il testo
                Debug.Log("Eseguo Ammo 2");
            }
        }
        else if(other.gameObject.tag == "RuneWow" && isFirstRuneWow == true)    //Se ho già raccolto la runa
        {
            AmmoW += 5;
            Debug.Log("Aumenta");
            if (InventorySystem.tempIImageWow == 0) //Se la runa sta nello slot 0
            {
                NumAmmoW0.text = AmmoW.ToString();  //Aumenta le ammo dello slot 0
                Debug.Log("Eseguo Ammo 3");
            }
            if (InventorySystem.tempIImageWow == 1) //Se la runa sta nello slot 1
            {
                NumAmmoW1.text = AmmoW.ToString();  //Aumenta le ammo dello slot 1
                Debug.Log("Eseguo Ammo 4");
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
                AmmoV = 5;                                     //Setta le ammo del valravn a 10
                RuneValvran = other.gameObject;                 //Mette in runa valravn in una variabile
                isFirstRuneValvran = true;                      //Segna che la prima runa del valravn è stata presa
                tempIsFirstRuneValvran = true;
                Debug.Log(AmmoV);                               //Scrivo a console quante ammo ha il valravn
                NumAmmoV0.text = AmmoV.ToString();              //Aggiorno il testo
                isActivateValvran = true;                       //Setto a vero l'attivazione del wow
                tempIsActiveValravn = true;                     //Setto a vero la temp dell'attivazione 
                isSlotOneOccupiedValravn = true;
                Debug.Log("Eseguo Ammo 5");
            }
            //if (isActivateWow == true || isActivateBlue == true || isActivateGreen == true || isActivateRed == true || isActivateYellow == true || isActivateEye == true || isActivateDarkElf == true || isActivateDraugr == true)              //Vede che la runa uno è occupata dal wow o dalle altre in questione quindi mette la runa due
            if(SlotRuneTwo.texture == AlphaTexture && isSlotOneOccupiedValravn == false)
            {
                //RuneRawImageValvran1.enabled = true;
                SlotRuneTwo.texture = RuneValravnTexture[0];
                NumAmmoV1.gameObject.SetActive(true);
                AmmoV = 5;
                RuneValvran = other.gameObject;
                isFirstRuneValvran = true;
                tempIsFirstRuneValvran = true;
                Debug.Log(AmmoV);
                NumAmmoV1.text = AmmoV.ToString();
                Debug.Log("Eseguo Ammo 6");
            }
        }
        else if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == true)
        {
            AmmoV += 7;
            if (InventorySystem.tempIImageValvran == 0)
            {
                NumAmmoV0.text = AmmoV.ToString();
                Debug.Log("AumentaValravn0");
                Debug.Log("Eseguo Ammo 7");
            }
            if (InventorySystem.tempIImageValvran == 1)
            {
                NumAmmoV1.text = AmmoV.ToString();
                Debug.Log("AumentaValravn1");
                Debug.Log("Eseguo Ammo 8");
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
                Debug.Log("Eseguo Ammo 9");
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
                Debug.Log("Eseguo Ammo 10");
            }
        }
        else if (other.gameObject.tag == "RuneGreen" && isFirstRuneGreen == true)    //Se ho già raccolto la runa
        {
            Debug.Log("Qui Verde");
            AmmoGreen += 10;
            if (InventorySystem.tempIImageGreen == 0)            //Se la runa sta nello slot 0
            {
                NumAmmoGreen0.text = AmmoGreen.ToString();      //Aumenta le ammo dello slot 0
                Debug.Log("Eseguo Ammo 11");
            }
            if (InventorySystem.tempIImageGreen == 1)            //Se la runa sta nello slot 1
            {
                NumAmmoGreen1.text = AmmoGreen.ToString();      //Aumenta le ammo dello slot 1
                Debug.Log("Eseguo Ammo 12");
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
                Debug.Log("Eseguo Ammo 13");
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
                Debug.Log("Eseguo Ammo 14");
            }
        }
        else if (other.gameObject.tag == "RuneEye" && isFirstRuneEye == true)    //Se ho già raccolto la runa
        {
            Debug.Log("Qui Occhio");
            AmmoEye += 10;
            if (InventorySystem.tempIImageEye == 0)                 //Se la runa sta nello slot 0
            {
                NumAmmoEye0.text = AmmoEye.ToString();              //Aumenta le ammo dello slot 0
                Debug.Log("Eseguo Ammo 15");
            }
            if (InventorySystem.tempIImageEye == 1)                 //Se la runa sta nello slot 1
            {
                NumAmmoEye1.text = AmmoEye.ToString();              //Aumenta le ammo dello slot 1
                Debug.Log("Eseguo Ammo 16");
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
                Debug.Log("Eseguo Ammo 17");
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
                Debug.Log("Eseguo Ammo 18");
            }
        }
        else if (other.gameObject.tag == "RuneDarkElf" && isFirstRuneDarkElf == true)    //Se ho già raccolto la runa
        {
            AmmoDarkElf += 10;
            if (InventorySystem.tempIImageDarkElf == 0)                     //Se la runa sta nello slot 0
            {
                NumAmmoDarkElf0.text = AmmoDarkElf.ToString();              //Aumenta le ammo dello slot 0
                Debug.Log("Eseguo Ammo 19");
            }
            if (InventorySystem.tempIImageDarkElf == 1)                     //Se la runa sta nello slot 1
            {
                NumAmmoDarkElf1.text = AmmoDarkElf.ToString();              //Aumenta le ammo dello slot 1
                Debug.Log("Eseguo Ammo 20");
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
        Debug.Log("Le ammo del cervo verde " +AmmoGreen);
        Debug.Log("Le ammo dell'occhio " +AmmoEye);
        Debug.Log("Le ammo del dark elf " +AmmoDarkElf);
        #endregion

        #region Delete Ammo

        #region Ammo Will o Wisp
        if (AmmoW <= 0)
            {
                if (CurrentScene.name == "FirstLevel")
                {
                    //if (InventorySystem.i != 0)
                        //InventorySystem.i--;
                    AmmoW = 1;
                    Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo");
                    Destroy(RuneWoW.gameObject);
                    isFirstRuneWow = false;
                    isActivateWow = false;
                    GetComponent<InventorySystem>().isPresentWow = false;
                    if (InventorySystem.tempIImageWow == 0)
                    {
                        SlotRuneOne.texture = AlphaTexture;
                        Debug.Log("Eseguo Ammo 21");
                        InventorySystem.i--;
                    }
                    if (InventorySystem.tempIImageWow == 1)
                    {
                        SlotRuneTwo.texture = AlphaTexture;
                        Debug.Log("Eseguo Ammo 22");
                        InventorySystem.i--;
                    }
                    NumAmmoW0.gameObject.SetActive(false);
                    NumAmmoW1.gameObject.SetActive(false);
                    InventorySystem.isFirsPresentRuneWow = false;
                    RuneToPlayer.isTimeToWow = false;
                    if (RestartWow == true)
                    {
                        RuneToPlayer.NumberRuneEnemyCatch--;
                        RestartWow = false;
                        Debug.Log("Eseguo Ammo 23");
                    }
                    Debug.Log("Vacci "+ RuneToPlayer.NumberRuneEnemyCatch);
                    Debug.Log("Eseguo Ammo 24");
                }
        }
        #endregion

        #region Ammo Valvran
            if (AmmoV <= 0)
            {
                if (CurrentScene.name == "FirstLevel")
                {
                    //InventorySystem.i--;
                    AmmoV = 1;
                    Destroy(RuneValvran.gameObject);
                    isFirstRuneValvran = false;
                    GetComponent<InventorySystem>().isPresentValvran = false;
                    isActivateValvran = false;
                    //RuneRawImageValvran0.enabled = false;
                    //RuneRawImageCooldownValvran0.enabled = false;
                    if (InventorySystem.tempIImageValvran == 0)
                    {
                        SlotRuneOne.texture = AlphaTexture;
                        Debug.Log("Eseguo Ammo 25");
                        InventorySystem.i--;
                    }
                    if (InventorySystem.tempIImageValvran == 1)
                    {
                        SlotRuneTwo.texture = AlphaTexture;
                        Debug.Log("Eseguo Ammo 26");
                        InventorySystem.i--;
                    }
                    NumAmmoV0.gameObject.SetActive(false);
                    //RuneRawImageValvran1.enabled = false;
                    //RuneRawImageCooldownValvran1.enabled = false;
                    NumAmmoV1.gameObject.SetActive(false);
                    InventorySystem.isFirsPresentRuneValvran = false;
                    RuneToPlayer.isTimeToValvran = false;
                    if (RestartValravn == true)
                    {
                        RuneToPlayer.NumberRuneEnemyCatch--;
                        RestartValravn = false;
                        Debug.Log("Eseguo Ammo 7");

                    }
                Debug.Log("Vacci " + RuneToPlayer.NumberRuneEnemyCatch);
                Debug.Log("Eseguo Ammo 28");
            }
        }
        #endregion

        #region Ammo Green
        if (AmmoGreen <= 0)
        {
            Debug.Log("verdeddeeeeeeeeeeeeeee");
            if (CurrentScene.name == "FirstLevel")
            {   
                //InventorySystem.i--;
                AmmoGreen = 1;
                Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo, verdeddeeeeeeeeeeeeeee");
                Destroy(RuneGreen.gameObject);
                isFirstRuneGreen = false;
                GetComponent<InventorySystem>().isPresentGreen = false;
                isActivateGreen = false;
                Debug.Log("temp i image green "+ InventorySystem.tempIImageGreen);
                if (InventorySystem.tempIImageGreen == 0)
                {
                    Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo, 11111111111111111111111111");
                    SlotRuneOne.texture = AlphaTexture;
                    Debug.Log("Eseguo Ammo 29");
                    InventorySystem.i--;
                }
                if (InventorySystem.tempIImageGreen == 1)
                {
                    Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo, 22222222222222222222");
                    SlotRuneTwo.texture = AlphaTexture;
                    Debug.Log("Eseguo Ammo 30");
                    InventorySystem.i--;
                }
                NumAmmoGreen0.gameObject.SetActive(false);
                NumAmmoGreen1.gameObject.SetActive(false);
                InventorySystem.isFirsPresentRuneGreen = false;
                RuneToPlayer.isTimeToGreen = false;
                if (RestartGreen == true)
                {
                    RuneToPlayer.NumberRuneEnemyCatch--;
                    RestartGreen = false;
                    Debug.Log("Eseguo Ammo 31");

                }
                Debug.Log("Vacci " + RuneToPlayer.NumberRuneEnemyCatch);
                Debug.Log("Eseguo Ammo 32");
            }
        }
        #endregion

        #region Ammo Eye
        if (AmmoEye <= 0)
        {
            if (CurrentScene.name == "FirstLevel")
            {
                //InventorySystem.i--;
                Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo");
                AmmoEye = 1;
                Destroy(RuneEye.gameObject);
                isFirstRuneEye = false;
                isActivateEye = false;
                GetComponent<InventorySystem>().isPresentEye = false;
                if (InventorySystem.tempIImageEye == 0)
                {
                    SlotRuneOne.texture = AlphaTexture;
                    Debug.Log("Eseguo Ammo 33");
                    InventorySystem.i--;
                }
                if (InventorySystem.tempIImageEye == 1)
                {
                    SlotRuneTwo.texture = AlphaTexture;
                    Debug.Log("Eseguo Ammo 34");
                    InventorySystem.i--;
                }
                NumAmmoEye0.gameObject.SetActive(false);
                NumAmmoEye1.gameObject.SetActive(false);
                InventorySystem.isFirsPresentRuneEye = false;
                RuneToPlayer.isTimeToEye = false;
                if (RestartEye == true)
                {
                    RuneToPlayer.NumberRuneEnemyCatch--;
                    RestartEye = false;
                    Debug.Log("Eseguo Ammo 35");

                }
                Debug.Log("Vacci " + RuneToPlayer.NumberRuneEnemyCatch);
                Debug.Log("Eseguo Ammo 36");
            }
        }
        #endregion

        #region Ammo Dark Elf
        if (AmmoDarkElf <= 0)
        {
            if (CurrentScene.name == "FirstLevel")
            {
                //InventorySystem.i--;
                AmmoDarkElf = 1;
                Debug.Log("Dovresti togliere la texture dalla runa 1, vediamo");
                Destroy(RuneDarkElf.gameObject);
                isFirstRuneDarkElf = false;
                GetComponent<InventorySystem>().isPresentDarkElf = false;
                isActivateDarkElf = false;
                if (InventorySystem.tempIImageDarkElf == 0)
                {
                    SlotRuneOne.texture = AlphaTexture;
                    Debug.Log("Eseguo Ammo 37");
                    InventorySystem.i--;

                }
                if (InventorySystem.tempIImageDarkElf == 1)
                {
                    SlotRuneTwo.texture = AlphaTexture;
                    Debug.Log("Eseguo Ammo 38");
                    InventorySystem.i--;
                }
                NumAmmoDarkElf0.gameObject.SetActive(false);
                NumAmmoDarkElf1.gameObject.SetActive(false);
                InventorySystem.isFirsPresentRuneDarkElf = false;
                RuneToPlayer.isTimeToDarkElf = false;
                if (RestartDarkElf == true)
                {
                    RuneToPlayer.NumberRuneEnemyCatch--;
                    RestartDarkElf = false;
                    Debug.Log("Eseguo Ammo 39");

                }
                Debug.Log("Vacci " + RuneToPlayer.NumberRuneEnemyCatch);
                Debug.Log("Eseguo Ammo 40");
            }
        }
        #endregion

        #endregion
    }
}