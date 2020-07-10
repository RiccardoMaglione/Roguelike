using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class InventorySystem : MonoBehaviour
{

    public GameObject[] InventorySlotsEnemy = new GameObject[2];        //Crea un array con due slots che farà da inventario per le rune degli enemy
    static public int i = 0;                                            //Setto la variabile i = 0 e la utilizzerò come contatore per l'invetario degli enemey, statica così che è raggiungibile e in memoria
    public bool isPresentWow = false;                                   //Setto a falso la variabile booleana che indica la presenza della runa del will o wisp nell'inventario
    public bool isPresentValvran = false;                               //Setto a falso la variabile booleana che indica la presenza della runa del valravn nell'inventario
    public bool isPresentProve = false;

    static public bool tempIsPresentWow = false;                        //Setto a falso le corrispondenti variabili temporane di isPresentWow, verrà utilizzata per il cambio di piano
    static public bool tempIsPresentValvran = false;                    //Setto a falso le corrispondenti variabili temporane di isPresentValravn, verrà utilizzata per il cambio di piano

    static public bool isFirsPresentRuneWow = false;                    //Setto una variabile booleana che indica se è presente per la prima volta la runa del will o wisp, a falso
    static public bool isFirsPresentRuneValvran = false;                //Setto una variabile booleana che indica se è presente per la prima volta la runa del valravn, a falso
    static public bool isFirsPresentRuneProva = false;

    public GameObject[] InventorySlotsBoss = new GameObject[1];         //Crea un array con uno slot che farà da inventario per le rune dei boss
    static public int j = 0;                                            //Setto la variabile j = 0 e la utilizzerò come contatore per l'invetario dei boss, statica così che è raggiungibile e in memoria
    public bool isPresentGammur = false;

    static public bool tempIsPresentGammur = false;                     //Variabile temporaneo per indicare se è presente la runa di Gammur quando si passa di scena

    static public bool isFirsPresentRuneGammur = false;                 //Setto una variabile booleana che indica se è presente per la prima volta la runa di Gammur, a falso

    GameObject TempRuneOne;
    GameObject TempRuneTwo;
    GameObject TempRuneThree;

    GameObject Player;                                                  //Istanzio la variabile Player

    public static int tempIWow;                                         //Variabile temporanea usata per contenere il valore della i del will o wisp
    public static int tempIValvran;                                     //Variabile temporanea usata per contenere il valore della i del valravn
    public static int tempJGammur;                                      //Variabile temporanea usata per contenere il valore della j di Gammur

    public static int tempIImageWow;                                    //Variabile temporanea usata per contenere il valore della i per la ui del will o wisp
    public static int tempIImageValvran;                                //Variabile temporanea usata per contenere il valore della i per la ui del valravn

    public GameObject TempRuneWow;                                      //Variabile temporanea usata per contenere la runa del will o wisp
    public GameObject TempRuneValravn;                                  //Variabile temporanea usata per contenere la runa del valravn
    public GameObject TempRuneGammur1;                                  //Variabile temporanea usata per contenere la runa di Gammur
    public GameObject TempRuneGammur2;                                  //Variabile temporanea usata per contenere la runa di Gammur
    public GameObject TempRuneGammur3;                                  //Variabile temporanea usata per contenere la runa di Gammur

    public static GameObject RuneWow;                                   //Variabile per contenere la runa e in modalità statica
    public static GameObject RuneValravn;                               //Variabile per contenere la runa e in modalità statica

    static public RawImage tempRawImageRuneGammur1;                     //Variabile temporanea che contiene la ui della runa di Gammur
    static public RawImage tempRawImageRuneGammur2;                     //Variabile temporanea che contiene la ui della runa di Gammur
    static public RawImage tempRawImageRuneGammur3;                     //Variabile temporanea che contiene la ui della runa di Gammur


    #region Nuove variabili per rune nuove inventario

    public static GameObject RuneBlue;
    public static GameObject RuneGreen;
    public static GameObject RuneRed;
    public static GameObject RuneYellow;
    public static GameObject RuneEye;
    public static GameObject RuneDarkElf;
    public static GameObject RuneDraugr;

    public bool isPresentEye = false;
    public bool isPresentBlue = false;
    public bool isPresentGreen = false;
    public bool isPresentYellow = false;
    public bool isPresentOrange = false;

    public bool isPresentDarkElf = false;
    public bool isPresentDraugr = false;

    static public bool tempIsPresentEye = false;
    static public bool tempIsPresentBlue = false;
    static public bool tempIsPresentGreen = false;
    static public bool tempIsPresentYellow = false;
    static public bool tempIsPresentOrange = false;

    static public bool tempIsPresentDarkElf = false;
    static public bool tempIsPresentDraugr = false;

    public static int tempIEye;
    public static int tempIBlue;
    public static int tempIGreen;
    public static int tempIYellow;
    public static int tempIOrange;

    public static int tempIDarkElf;
    public static int tempIDraugr;

    public static int tempIImageEye;
    public static int tempIImageBlue;
    public static int tempIImageGreen;
    public static int tempIImageYellow;
    public static int tempIImageOrange;

    public static int tempIImageDarkElf;
    public static int tempIImageDraugr;

    static public bool isFirsPresentRuneEye = false;
    static public bool isFirsPresentRuneBlue = false;
    static public bool isFirsPresentRuneGreen = false;
    static public bool isFirsPresentRuneYellow = false;
    static public bool isFirsPresentRuneOrange = false;

    static public bool isFirsPresentRuneDarkElf = false;
    static public bool isFirsPresentRuneDraugr = false;
    #endregion

    public int ciao;
    public int ciao2;


    #region Change
    static public bool ChangeRuneSinistra = false;
    static public bool ChangeRuneDestra = false;


    static public bool WoWChange = false;
    static public bool ValravnChange = false;
    static public bool EyeChange = false;
    static public bool BlueChange = false;
    static public bool GreenChange = false;    
    static public bool RedChange = false;
    static public bool YellowChange = false;
    static public bool DarkElfChange = false;
    static public bool DraugrChange = false;

    #endregion

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;         //Trova l'oggetto con il tag player e lo setta in Player
        Scene CurrentScene = SceneManager.GetActiveScene();                     //Prende la scena corrente
        #region First Level Reset
        if (CurrentScene.name == "FirstLevel")                                  //Se il nome della scena corrente è First Level
        {
            isPresentWow = false;                                               //Setta la variabile booleana "Se è presente la runa del Will o Wisp" a false
            isPresentValvran = false;                                           //Setta la variabile booleana "Se è presente la runa del Valravn" a false
            isPresentEye = false;
            isPresentGreen = false;
            isPresentDarkElf = false;

            WoWChange = false;
            ValravnChange = false;
            EyeChange = false;
            BlueChange = false;
            GreenChange = false;
            RedChange = false;
            YellowChange = false;
            DarkElfChange = false;
            DraugrChange = false;

            Array.Clear(InventorySlotsEnemy, 0, InventorySlotsEnemy.Length);    //Svuota l'array dell'inventario enemy
            Array.Clear(InventorySlotsBoss, 0, InventorySlotsBoss.Length);      //Svuota l'array dell'inventario Boss
        }
        #endregion
        RuneToPlayer.NumberRuneEnemyCatch = 0;
    }

    private void Update()
    {
        ciao = i;
        ciao2 = RuneToPlayer.NumberRuneEnemyCatch;
    }
    private void OnTriggerEnter(Collider other)
    {

        
        if(i < 2 && (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva" || other.gameObject.tag == "RuneEye" || other.gameObject.tag == "RuneBlue" || other.gameObject.tag == "RuneGreen" || other.gameObject.tag == "RuneYellow" || other.gameObject.tag == "RuneOrange" || other.gameObject.tag == "RuneDarkElf" || other.gameObject.tag == "RuneDraugr"))        //Se i<2 e l'altro oggetto ha un particolare tag
        {
            if (other.gameObject.tag == "RuneWow" && isPresentWow == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIWow = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageWow = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                //TempRuneWow = other.gameObject;
                i++;                                                                    //Aumenta i di 1
                isPresentWow = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentWow = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
                Debug.Log("Eseguo Inventory System 1");
            }
            if (other.gameObject.tag == "RuneValvran" && isPresentValvran == false)     //Se l'altro oggetto è la runa del valravn ed è la runa non è già presente nell'inventario
            {
                tempIValvran = i;                                                       //Setta la variabile temporanea tempI del valravn uguale a i
                tempIImageValvran = i;                                                  //Setta la variabile temporanea tempI relativa alla ui del valravn uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                //TempRuneValravn = other.gameObject;
                i++;                                                                    //Aumenta i di 1
                isPresentValvran = true;                                                //Setta a vero la presenza della runa del valravn
                tempIsPresentValvran = true;                                            //Setta a vero la presenza della runa del valravn nella variabile temporanea
                Debug.Log("Eseguo Inventory System 2");
            }
            if (other.gameObject.tag == "RuneEye" && isPresentEye == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIEye = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageEye = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                i++;                                                                    //Aumenta i di 1
                isPresentEye = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentEye = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
                Debug.Log("Eseguo Inventory System 3");
            }
            if (other.gameObject.tag == "RuneGreen" && isPresentGreen == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIGreen = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageGreen = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                i++;                                                                    //Aumenta i di 1
                isPresentGreen = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentGreen = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
                Debug.Log("Eseguo Inventory System 4");
            }
            if (other.gameObject.tag == "RuneDarkElf" && isPresentDarkElf == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIDarkElf = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageDarkElf = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                i++;                                                                    //Aumenta i di 1
                isPresentDarkElf = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentDarkElf = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
                Debug.Log("Eseguo Inventory System 5");
            }

        }
        if (j < 1 && other.gameObject.tag == "RuneGammur")                              //Se j<1 e l'altro oggetto ha un particolare tag
        {
            if (other.gameObject.tag == "RuneGammur" && isPresentGammur == false)       //Se l'altro oggetto è la runa di Gammur ed è la runa non è già presente nell'inventario
            {
                tempJGammur = j;                                                        //Setta la variabile temporanea tempI di Gammur uguale a j
                InventorySlotsBoss[j] = other.gameObject;                               //Assegna alla posizione j l'oggetto appena raccolto
                //TempRuneGammur = other.gameObject;
                j++;                                                                    //Aumenta j di 1
                isPresentGammur = true;                                                 //Setta a vero la presenza della runa di Gammur
                tempIsPresentGammur = true;                                             //Setta a vero la presenza della runa di Gammur nella variabile temporanea
                Debug.Log("Eseguo Inventory System 6");
            }
        }
    }



    private void OnTriggerStay(Collider other)
    {
        #region Change rune
        if (Input.GetKey(KeyCode.F))                                                                                                                //Se schiaccio B (da cambiare poi in F + LeftArrow)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton2))                                                                                                                //Se schiaccio B (da cambiare poi in F + LeftArrow)
            {
                if (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva" || other.gameObject.tag == "RuneEye" || other.gameObject.tag == "RuneBlue" || other.gameObject.tag == "RuneGreen" || other.gameObject.tag == "RuneYellow" || other.gameObject.tag == "RuneOrange" || other.gameObject.tag == "RuneDarkElf" || other.gameObject.tag == "RuneDraugr")                  //Se l'altro oggetto è uno di quelli proposti
                {
                    if (InventorySlotsEnemy[0].gameObject.tag == "RuneWow")
                    {
                        GetComponent<Ammo>().isFirstRuneWow = false;
                        GetComponent<Ammo>().isSlotOneOccupiedWow = false;
                        GetComponent<Ammo>().isActivateWow = false;
                        isPresentWow = false;
                        isFirsPresentRuneWow = false;
                        RuneToPlayer.isTimeToWow = false;
                        Debug.Log("Eseguo Inventory System 7"); ;
                    }
                    if (InventorySlotsEnemy[0].gameObject.tag == "RuneValvran")
                    {
                        GetComponent<Ammo>().isFirstRuneValvran = false;
                        GetComponent<Ammo>().isSlotOneOccupiedValravn = false;
                        GetComponent<Ammo>().isActivateValvran = false;
                        isPresentValvran = false;
                        isFirsPresentRuneValvran = false;
                        RuneToPlayer.isTimeToValvran = false;
                        Debug.Log("Eseguo Inventory System 8");
                    }
                    if (InventorySlotsEnemy[0].gameObject.tag == "RuneEye")
                    {
                        GetComponent<Ammo>().isFirstRuneEye = false;
                        GetComponent<Ammo>().isSlotOneOccupiedEye = false;
                        GetComponent<Ammo>().isActivateEye = false;
                        isPresentEye = false;
                        isFirsPresentRuneEye = false;
                        RuneToPlayer.isTimeToEye = false;
                        Debug.Log("Eseguo Inventory System 9");
                    }
                    if (InventorySlotsEnemy[0].gameObject.tag == "RuneGreen")
                    {
                        GetComponent<Ammo>().isFirstRuneGreen = false;
                        GetComponent<Ammo>().isSlotOneOccupiedGreen = false;
                        GetComponent<Ammo>().isActivateGreen = false;
                        isPresentGreen = false;
                        isFirsPresentRuneGreen = false;
                        RuneToPlayer.isTimeToGreen = false;
                        Debug.Log("Eseguo Inventory System 10");
                    }
                    if (InventorySlotsEnemy[0].gameObject.tag == "RuneDarkElf")
                    {
                        GetComponent<Ammo>().isFirstRuneDarkElf = false;
                        GetComponent<Ammo>().isSlotOneOccupiedDarkElf = false;
                        GetComponent<Ammo>().isActivateDarkElf = false;
                        isPresentDarkElf = false;
                        isFirsPresentRuneDarkElf = false;
                        RuneToPlayer.isTimeToDarkElf = false;
                        Debug.Log("Eseguo Inventory System 11");
                    }

                    Destroy(InventorySlotsEnemy[0]);                                                                                                    //Distruggi l'oggetto nell'invetario Enemy alla posizione 0
                    InventorySlotsEnemy[0] = other.gameObject;                                                                                          //Setta l'altro oggetto nell'inventario Enemy alla posizione 0
                    InventorySlotsEnemy[0].transform.parent = Player.transform;                                                                         //Setta come parent il player
                    InventorySlotsEnemy[0].transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);     //Setta la posizione dell'oggetto appena scambiato
                    Debug.Log("E' ora di cambiare runa");
                    //ChangeRuneSinistra = true;
                    //if runa tag, setto il present rune
                    //Sistemare 
                    if (other.gameObject.tag == "RuneWow")
                    {
                        Ammo.RuneWoW = other.gameObject;
                        Debug.Log("Ciccia");
                        isPresentWow = true;
                        InventorySlotsEnemy[0].GetComponent<RuneWow>().enabled = true;
                        GetComponent<Ammo>().isActivateWow = true;
                        //EyeChange = true;
                        GetComponent<Ammo>().SlotRuneOne.texture = GetComponent<Ammo>().RuneWowTexture[0];
                        tempIWow = 0;
                        GetComponent<Ammo>().isFirstRuneWow = true;
                        Ammo.NumAmmoW0.gameObject.SetActive(true);
                        Ammo.NumAmmoV0.gameObject.SetActive(false);
                        Ammo.NumAmmoEye0.gameObject.SetActive(false);
                        Ammo.NumAmmoGreen0.gameObject.SetActive(false);
                        Ammo.NumAmmoDarkElf0.gameObject.SetActive(false);
                        Ammo.AmmoW = 5;
                        Ammo.NumAmmoW0.text = Ammo.AmmoW.ToString();
                        tempIImageWow = 0;
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
                        Debug.Log("Eseguo Inventory System 12");
                    }
                    if (other.gameObject.tag == "RuneValvran")
                    {
                        Ammo.RuneValvran = other.gameObject;
                        Debug.Log("Ciccia");
                        isPresentValvran = true;
                        InventorySlotsEnemy[0].GetComponent<RuneValravn>().enabled = true;
                        GetComponent<Ammo>().isActivateValvran = true;
                        //EyeChange = true;
                        GetComponent<Ammo>().SlotRuneOne.texture = GetComponent<Ammo>().RuneValravnTexture[0];
                        tempIValvran = 0;
                        GetComponent<Ammo>().isFirstRuneValvran = true;
                        Ammo.NumAmmoV0.gameObject.SetActive(true);
                        Ammo.NumAmmoW0.gameObject.SetActive(false);
                        Ammo.NumAmmoEye0.gameObject.SetActive(false);
                        Ammo.NumAmmoGreen0.gameObject.SetActive(false);
                        Ammo.NumAmmoDarkElf0.gameObject.SetActive(false);
                        Ammo.AmmoV = 7;
                        Ammo.NumAmmoV0.text = Ammo.AmmoV.ToString();
                        tempIImageValvran = 0;
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
                        Debug.Log("Eseguo Inventory System 13");
                    }
                    if (other.gameObject.tag == "RuneEye")
                    {
                        Ammo.RuneEye = other.gameObject;
                        Debug.Log("Ciccia");
                        isPresentEye = true;
                        InventorySlotsEnemy[0].GetComponent<RuneEye>().enabled = true;
                        GetComponent<Ammo>().isActivateEye = true;
                        //EyeChange = true;
                        GetComponent<Ammo>().SlotRuneOne.texture = GetComponent<Ammo>().RuneEyeTexture[0];
                        tempIEye = 0;
                        GetComponent<Ammo>().isFirstRuneEye = true;
                        Ammo.NumAmmoEye0.gameObject.SetActive(true);
                        Ammo.NumAmmoV0.gameObject.SetActive(false);
                        Ammo.NumAmmoW0.gameObject.SetActive(false);
                        Ammo.NumAmmoGreen0.gameObject.SetActive(false);
                        Ammo.NumAmmoDarkElf0.gameObject.SetActive(false);
                        Ammo.AmmoEye = 10;
                        Ammo.NumAmmoEye0.text = Ammo.AmmoEye.ToString();
                        tempIImageEye = 0;
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
                        InventorySlotsEnemy[0].GetComponent<RotateParticle>().enabled = false;
                        InventorySlotsEnemy[0].transform.rotation = Quaternion.Euler(-90, 0, 90);
                        InventorySlotsEnemy[0].transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
                        Debug.Log("Eseguo Inventory System 14");
                    }
                    if (other.gameObject.tag == "RuneGreen")
                    {
                        Ammo.RuneGreen = other.gameObject;
                        isPresentGreen = true;
                        InventorySlotsEnemy[0].GetComponent<RuneGreen>().enabled = true;
                        GetComponent<Ammo>().isActivateGreen = true;
                        //GreenChange = true;
                        GetComponent<Ammo>().SlotRuneOne.texture = GetComponent<Ammo>().RuneGreenTexture[0];
                        tempIGreen = 0;
                        GetComponent<Ammo>().isFirstRuneGreen = true;
                        Ammo.NumAmmoGreen0.gameObject.SetActive(true);
                        Ammo.NumAmmoV0.gameObject.SetActive(false);
                        Ammo.NumAmmoEye0.gameObject.SetActive(false);
                        Ammo.NumAmmoW0.gameObject.SetActive(false);
                        Ammo.NumAmmoDarkElf0.gameObject.SetActive(false);
                        Ammo.AmmoGreen = 10;
                        Ammo.NumAmmoGreen0.text = Ammo.AmmoGreen.ToString();
                        tempIImageGreen = 0;
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
                        Debug.Log("Ci arrivi qua nella verde image");
                        Debug.Log("Eseguo Inventory System 15");
                    }
                    if (other.gameObject.tag == "RuneDarkElf")
                    {
                        Ammo.RuneDarkElf = other.gameObject;
                        isPresentDarkElf = true;
                        InventorySlotsEnemy[0].GetComponent<RuneDarkElf>().enabled = true;
                        GetComponent<Ammo>().isActivateDarkElf = true;
                        //DarkElfChange = true;
                        GetComponent<Ammo>().SlotRuneOne.texture = GetComponent<Ammo>().RuneDarkElfTexture[0];
                        tempIDarkElf = 0;
                        GetComponent<Ammo>().isFirstRuneDarkElf = true;
                        Ammo.NumAmmoDarkElf0.gameObject.SetActive(true);
                        Ammo.NumAmmoV0.gameObject.SetActive(false);
                        Ammo.NumAmmoEye0.gameObject.SetActive(false);
                        Ammo.NumAmmoGreen0.gameObject.SetActive(false);
                        Ammo.NumAmmoW0.gameObject.SetActive(false);
                        Ammo.AmmoDarkElf = 10;
                        Ammo.NumAmmoDarkElf0.text = Ammo.AmmoDarkElf.ToString();
                        tempIImageDarkElf = 0;
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
                        Debug.Log("Eseguo Inventory System 16");
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.F))                                                                                                                //Se schiaccio N (da cambiare poi in F + RightArrow)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton1))                                                                                                                //Se schiaccio B (da cambiare poi in F + LeftArrow)
            {
                if (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva" || other.gameObject.tag == "RuneEye" || other.gameObject.tag == "RuneBlue" || other.gameObject.tag == "RuneGreen" || other.gameObject.tag == "RuneYellow" || other.gameObject.tag == "RuneOrange" || other.gameObject.tag == "RuneDarkElf" || other.gameObject.tag == "RuneDraugr")                  //Se l'altro oggetto è uno di quelli proposti
                {
                    if (InventorySlotsEnemy[1].gameObject.tag == "RuneWow")
                    {
                        GetComponent<Ammo>().isFirstRuneWow = false;
                        GetComponent<Ammo>().isSlotOneOccupiedWow = false;
                        isPresentWow = false;
                        isFirsPresentRuneWow = false;
                        RuneToPlayer.isTimeToWow = false;
                        Debug.Log("Eseguo Inventory System 17");
                    }
                    if (InventorySlotsEnemy[1].gameObject.tag == "RuneValvran")
                    {
                        GetComponent<Ammo>().isFirstRuneValvran = false;
                        GetComponent<Ammo>().isSlotOneOccupiedValravn = false;
                        isPresentValvran = false;
                        isFirsPresentRuneValvran = false;
                        RuneToPlayer.isTimeToValvran = false;
                        Debug.Log("Eseguo Inventory System 18");
                    }
                    if (InventorySlotsEnemy[1].gameObject.tag == "RuneEye")
                    {
                        GetComponent<Ammo>().isFirstRuneEye = false;
                        GetComponent<Ammo>().isSlotOneOccupiedEye = false;
                        isPresentEye = false;
                        isFirsPresentRuneEye = false;
                        RuneToPlayer.isTimeToEye = false;
                        Debug.Log("Eseguo Inventory System 19");
                    }
                    if (InventorySlotsEnemy[1].gameObject.tag == "RuneGreen")
                    {
                        GetComponent<Ammo>().isFirstRuneGreen = false;
                        GetComponent<Ammo>().isSlotOneOccupiedGreen = false;
                        isPresentGreen = false;
                        isFirsPresentRuneGreen = false;
                        RuneToPlayer.isTimeToGreen = false;
                        Debug.Log("Eseguo Inventory System 20");
                    }
                    if (InventorySlotsEnemy[1].gameObject.tag == "RuneDarkElf")
                    {
                        GetComponent<Ammo>().isFirstRuneDarkElf = false;
                        GetComponent<Ammo>().isSlotOneOccupiedDarkElf = false;
                        isPresentDarkElf = false;
                        isFirsPresentRuneDarkElf = false;
                        RuneToPlayer.isTimeToDarkElf = false;
                        Debug.Log("Eseguo Inventory System 21");
                    }

                    Destroy(InventorySlotsEnemy[1]);                                                                                                    //Distruggi l'oggetto nell'invetario Enemy alla posizione 1
                    InventorySlotsEnemy[1] = other.gameObject;                                                                                          //Setta l'altro oggetto nell'inventario Enemy alla posizione 1
                    InventorySlotsEnemy[1].transform.parent = Player.transform;                                                                         //Setta come parent il player
                    InventorySlotsEnemy[1].transform.position = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);     //Setta la posizione dell'oggetto appena scambiato
                                                                                                                                                        //ChangeRuneDestra = true;
                                                                                                                                                        //Sistemare                                                                                                                                    //if runa tag, setto il present rune
                    if (other.gameObject.tag == "RuneWow")
                    {
                        Ammo.RuneWoW = other.gameObject;
                        isPresentWow = true;
                        InventorySlotsEnemy[1].GetComponent<RuneWow>().enabled = true;
                        //EyeChange = true;
                        GetComponent<Ammo>().SlotRuneTwo.texture = GetComponent<Ammo>().RuneWowTexture[0];
                        tempIWow = 1;
                        GetComponent<Ammo>().isFirstRuneWow = true;
                        Ammo.NumAmmoW1.gameObject.SetActive(true);
                        Ammo.NumAmmoV1.gameObject.SetActive(false);
                        Ammo.NumAmmoEye1.gameObject.SetActive(false);
                        Ammo.NumAmmoGreen1.gameObject.SetActive(false);
                        Ammo.NumAmmoDarkElf1.gameObject.SetActive(false);
                        Ammo.AmmoW = 5;
                        Ammo.NumAmmoW1.text = Ammo.AmmoW.ToString();
                        tempIImageWow = 1;
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
                        Debug.Log("Eseguo Inventory System 22");
                    }
                    if (other.gameObject.tag == "RuneValvran")
                    {
                        Ammo.RuneValvran = other.gameObject;
                        isPresentValvran = true;
                        InventorySlotsEnemy[1].GetComponent<RuneValravn>().enabled = true;
                        //EyeChange = true;
                        GetComponent<Ammo>().SlotRuneTwo.texture = GetComponent<Ammo>().RuneValravnTexture[0];
                        tempIValvran = 1;
                        GetComponent<Ammo>().isFirstRuneValvran = true;
                        Ammo.NumAmmoV1.gameObject.SetActive(true);
                        Ammo.NumAmmoW1.gameObject.SetActive(false);
                        Ammo.NumAmmoEye1.gameObject.SetActive(false);
                        Ammo.NumAmmoGreen1.gameObject.SetActive(false);
                        Ammo.NumAmmoDarkElf1.gameObject.SetActive(false);
                        Ammo.AmmoV = 7;
                        Ammo.NumAmmoV1.text = Ammo.AmmoV.ToString();
                        tempIImageValvran = 1;
                        Debug.Log("Ci arrivi qua nella verde image1");
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
                        Debug.Log("Eseguo Inventory System 23");
                    }
                    if (other.gameObject.tag == "RuneEye")
                    {
                        Ammo.RuneEye = other.gameObject;
                        isPresentEye = true;
                        InventorySlotsEnemy[1].GetComponent<RuneEye>().enabled = true;
                        //EyeChange = true;
                        GetComponent<Ammo>().SlotRuneTwo.texture = GetComponent<Ammo>().RuneEyeTexture[0];
                        tempIEye = 1;
                        GetComponent<Ammo>().isFirstRuneEye = true;
                        Ammo.NumAmmoEye1.gameObject.SetActive(true);
                        Ammo.NumAmmoV1.gameObject.SetActive(false);
                        Ammo.NumAmmoW1.gameObject.SetActive(false);
                        Ammo.NumAmmoGreen1.gameObject.SetActive(false);
                        Ammo.NumAmmoDarkElf1.gameObject.SetActive(false);
                        Ammo.AmmoEye = 10;
                        Ammo.NumAmmoEye1.text = Ammo.AmmoEye.ToString();
                        tempIImageEye = 1;
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
                        Debug.Log("ciaociaocicciacicciaentra");
                        InventorySlotsEnemy[1].GetComponent<RotateParticle>().enabled = false;
                        InventorySlotsEnemy[1].transform.rotation = Quaternion.Euler(-90, 0, 90);
                        InventorySlotsEnemy[1].transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
                        Debug.Log("Eseguo Inventory System 24");
                    }
                    if (other.gameObject.tag == "RuneGreen")
                    {
                        Ammo.RuneGreen = other.gameObject;
                        isPresentGreen = true;
                        InventorySlotsEnemy[1].GetComponent<RuneGreen>().enabled = true;
                        //GreenChange = true;
                        GetComponent<Ammo>().SlotRuneTwo.texture = GetComponent<Ammo>().RuneGreenTexture[0];
                        tempIGreen = 1;
                        GetComponent<Ammo>().isFirstRuneGreen = true;
                        Ammo.NumAmmoGreen1.gameObject.SetActive(true);
                        Ammo.NumAmmoV1.gameObject.SetActive(false);
                        Ammo.NumAmmoEye1.gameObject.SetActive(false);
                        Ammo.NumAmmoW1.gameObject.SetActive(false);
                        Ammo.NumAmmoDarkElf1.gameObject.SetActive(false);
                        Ammo.AmmoGreen = 10;
                        Ammo.NumAmmoGreen1.text = Ammo.AmmoGreen.ToString();
                        tempIImageGreen = 1;
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
                        Debug.Log("Eseguo Inventory System 25");
                    }
                    if (other.gameObject.tag == "RuneDarkElf")
                    {
                        Ammo.RuneDarkElf = other.gameObject;
                        isPresentDarkElf = true;
                        InventorySlotsEnemy[1].GetComponent<RuneDarkElf>().enabled = true;
                        //DarkElfChange = true;
                        GetComponent<Ammo>().SlotRuneTwo.texture = GetComponent<Ammo>().RuneDarkElfTexture[0];
                        tempIDarkElf = 1;
                        GetComponent<Ammo>().isFirstRuneDarkElf = true;
                        Ammo.NumAmmoDarkElf1.gameObject.SetActive(true);
                        Ammo.NumAmmoV1.gameObject.SetActive(false);
                        Ammo.NumAmmoEye1.gameObject.SetActive(false);
                        Ammo.NumAmmoGreen1.gameObject.SetActive(false);
                        Ammo.NumAmmoW1.gameObject.SetActive(false);
                        Ammo.AmmoDarkElf = 10;
                        Ammo.NumAmmoDarkElf1.text = Ammo.AmmoDarkElf.ToString();
                        tempIImageDarkElf = 1;
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
                        Debug.Log("Eseguo Inventory System 26");
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.M))                                                                                                                //Se schiaccio B (da cambiare poi in F + UpArrow)
        {
            if (other.gameObject.tag == "RuneGammur")                  //Se l'altro oggetto è uno di quelli proposti
            {
                Destroy(InventorySlotsBoss[0]);                                                                                                     //Distruggi l'oggetto nell'invetario Boss alla posizione 0
                InventorySlotsBoss[0] = other.gameObject;                                                                                           //Setta l'altro oggetto nell'inventario Boss alla posizione 0
                InventorySlotsBoss[0].transform.parent = Player.transform;                                                                          //Setta come parent il player
                InventorySlotsBoss[0].transform.position = new Vector3(transform.position.x, transform.position.y + 30, transform.position.z);      //Setta la posizione dell'oggetto appena scambiato
                Debug.Log("Eseguo Inventory System 27");
            }
        }
        #endregion
    }
}