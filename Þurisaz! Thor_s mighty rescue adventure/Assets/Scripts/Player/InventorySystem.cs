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
            isPresentBlue = false;
            isPresentGreen = false;
            isPresentYellow = false;
            isPresentOrange = false;

            isPresentDarkElf = false;
            isPresentDraugr = false;

            isPresentProve = false;
            
            Array.Clear(InventorySlotsEnemy, 0, InventorySlotsEnemy.Length);    //Svuota l'array dell'inventario enemy
            Array.Clear(InventorySlotsBoss, 0, InventorySlotsBoss.Length);      //Svuota l'array dell'inventario Boss
        }
        #endregion

        #region ThirdLevel Passaggio di valori
        if (CurrentScene.name == "ThirdLevel")                                                              //Se il nome della scena corrente è Third Level
        {
            tempRawImageRuneGammur1 = GameObject.Find("RuneGammur1RawImage").GetComponent<RawImage>();      //Trova l'oggetto con un determinato nome e lo setta in una variabile dedicata
            tempRawImageRuneGammur2 = GameObject.Find("RuneGammur2RawImage").GetComponent<RawImage>();      //Trova l'oggetto con un determinato nome e lo setta in una variabile dedicata
            tempRawImageRuneGammur3 = GameObject.Find("RuneGammur3RawImage").GetComponent<RawImage>();      //Trova l'oggetto con un determinato nome e lo setta in una variabile dedicata
            #region Passaggio rune mostri comuni presenti nel primo piano
            if (tempIsPresentWow == true)                                   //Se la variabile temporanea "Se è presente la runa del Will o Wisp" è vera
            {
                isPresentWow = true;                                        //Setta la variabile "Se è presente la runa del Will o Wisp" a vero
                RuneWow = Instantiate(TempRuneWow);                         //Instanzia nel nuovo piano la runa del will o wisp
                RuneWow.transform.parent = Player.transform;                //Setta la parentela al Player
                InventorySlotsEnemy[tempIWow] = RuneWow;                    //Inserisco l'oggetto nell'invetario degli enemy
                RuneWow.GetComponent<MeshRenderer>().enabled = false;       //Setto il MeshRenderer a falso per renderlo invisibile
            }
            if (tempIsPresentValvran == true)                               //Se la variabile temporanea "Se è presente la runa del Valravn" è vera
            {
                isPresentValvran = true;                                    //Setta la variabile "Se è presente la runa del Valravn" a vero
                RuneValravn = Instantiate(TempRuneValravn);                 //Instanzia nel nuovo piano la runa del Valravn
                RuneValravn.transform.parent = Player.transform;            //Setta la parentela al Player
                InventorySlotsEnemy[tempIValvran] = RuneValravn;            //Inserisco l'oggetto nell'invetario degli enemy
                RuneValravn.GetComponent<MeshRenderer>().enabled = false;   //Setto il MeshRenderer a falso per renderlo invisibile
            }
            #endregion
            #region Passaggio rune boss presenti nel primo piano
            if (tempIsPresentGammur == true)                                        //Se la variabile temporanea "Se è presente la runa di Gammur" è vera
            {
                isPresentGammur = true;                                             //Setta la variabile "Se è presente la runa di Gammur" a vero
                if (EnemyManager.rangeGammur == 1)                                  //Se la runa spawnata è contrassegnata con 1
                {
                    GameObject RuneGammur1 = Instantiate(TempRuneGammur1);          //Instanzia la runa di Gammur corrispondente all'urlo
                    RuneGammur1.transform.parent = Player.transform;                //Setta la parentela al Player
                    RuneGammur1.GetComponent<RuneGammurOne>().enabled = true;       //Attiva lo script del primo attacco
                    RuneGammur1.GetComponent<RuneGammurTwo>().enabled = false;      //Disattiva lo script del secondo attacco
                    RuneGammur1.GetComponent<RuneGammurThree>().enabled = false;    //Disattiva lo script del terzo attacco
                    RuneGammur1.GetComponent<MeshRenderer>().enabled = false;       //Setto il MeshRenderer a falso per renderlo invisibile
                    InventorySlotsBoss[tempJGammur] = RuneGammur1;                  //Inserisco l'oggetto nell'invetario dei boss
                    tempRawImageRuneGammur1.enabled = true;                         //Attivo la raw image presente nella ui che indica al player quale runa ha delle tre di Gammur
                }
                if (EnemyManager.rangeGammur == 2)                                  //Se la runa spawnata è contrassegnata con 2
                {
                    GameObject RuneGammur2 = Instantiate(TempRuneGammur2);          //Instanzia la runa di Gammur corrispondente alle uova che cadono dal cielo
                    RuneGammur2.transform.parent = Player.transform;                //Setta la parentela al Player
                    RuneGammur2.GetComponent<RuneGammurOne>().enabled = false;      //Disattiva lo script del primo attacco
                    RuneGammur2.GetComponent<RuneGammurTwo>().enabled = true;       //Attiva lo script del seocndo attacco
                    RuneGammur2.GetComponent<RuneGammurThree>().enabled = false;    //Disattiva lo script del terzo attacco
                    RuneGammur2.GetComponent<MeshRenderer>().enabled = false;       //Setto il MeshRenderer a falso per renderlo invisibile
                    InventorySlotsBoss[tempJGammur] = RuneGammur2;                  //Inserisco l'oggetto nell'invetario dei boss
                    tempRawImageRuneGammur2.enabled = true;                         //Attivo la raw image presente nella ui che indica al player quale runa ha delle tre di Gammur
                }
                if (EnemyManager.rangeGammur == 3)                                  //Se la runa spawnata è contrassegnata con 3
                {
                    GameObject RuneGammur3 = Instantiate(TempRuneGammur3);          //Instanzia la runa di Gammur corrispondente ai minion esplosivi
                    RuneGammur3.transform.parent = Player.transform;                //Setta la parentela al Player
                    RuneGammur3.GetComponent<RuneGammurOne>().enabled = false;      //Disattiva lo script del primo attacco
                    RuneGammur3.GetComponent<RuneGammurTwo>().enabled = false;      //Disattiva lo script del secondo attacco
                    RuneGammur3.GetComponent<RuneGammurThree>().enabled = true;     //Attiva lo script del terzo attacco
                    RuneGammur3.GetComponent<MeshRenderer>().enabled = false;       //Setto il MeshRenderer a falso per renderlo invisibile
                    InventorySlotsBoss[tempJGammur] = RuneGammur3;                  //Inserisco l'oggetto nell'invetario dei boss
                    tempRawImageRuneGammur3.enabled = true;                         //Attivo la raw image presente nella ui che indica al player quale runa ha delle tre di Gammur
                }
            }
            #endregion
        }
        #endregion
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
            }






            if (other.gameObject.tag == "RuneProva" && isPresentProve == false)
            {
                InventorySlotsEnemy[i] = other.gameObject;
                i++;
                isPresentProve = true;
            }





            #region Nuove rune con inventario

            if (other.gameObject.tag == "RuneEye" && isPresentEye == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIEye = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageEye = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                i++;                                                                    //Aumenta i di 1
                isPresentEye = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentEye = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
            }
            if (other.gameObject.tag == "RuneBlue" && isPresentBlue == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIBlue = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageBlue = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                i++;                                                                    //Aumenta i di 1
                isPresentBlue = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentBlue = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
            }
            if (other.gameObject.tag == "RuneGreen" && isPresentGreen == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIGreen = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageGreen = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                i++;                                                                    //Aumenta i di 1
                isPresentGreen = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentGreen = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
            }
            if (other.gameObject.tag == "RuneYellow" && isPresentYellow == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIYellow = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageYellow = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                i++;                                                                    //Aumenta i di 1
                isPresentYellow = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentYellow = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
            }
            if (other.gameObject.tag == "RuneOrange" && isPresentOrange == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIOrange = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageOrange = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                i++;                                                                    //Aumenta i di 1
                isPresentOrange = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentOrange = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
            }
            if (other.gameObject.tag == "RuneDarkElf" && isPresentDarkElf == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIDarkElf = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageDarkElf = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                i++;                                                                    //Aumenta i di 1
                isPresentDarkElf = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentDarkElf = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
            }
            if (other.gameObject.tag == "RuneDraugr" && isPresentDraugr == false)             //Se l'altro oggetto è la runa del will o wisp ed è la runa non è già presente nell'inventario
            {
                tempIDraugr = i;                                                           //Setta la variabile temporanea tempI del will o wisp uguale a i
                tempIImageDraugr = i;                                                      //Setta la variabile temporanea tempI relativa alla ui del will o wisp uguale a i
                InventorySlotsEnemy[i] = other.gameObject;                              //Assegna alla posizione i l'oggetto appena raccolto
                i++;                                                                    //Aumenta i di 1
                isPresentDraugr = true;                                                    //Setta a vero la presenza della runa del will o wisp
                tempIsPresentDraugr = true;                                                //Setta a vero la presenza della runa del will o wisp nella variabile temporanea
            }

            #endregion





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
            }
        }
    }



    private void OnTriggerStay(Collider other)
    {
        #region Change rune
        if (Input.GetKey(KeyCode.F))                                                                                                                //Se schiaccio B (da cambiare poi in F + LeftArrow)
        {
            if (Input.GetKey(KeyCode.LeftArrow))                                                                                                                //Se schiaccio B (da cambiare poi in F + LeftArrow)
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
                    }
                    if (InventorySlotsEnemy[0].gameObject.tag == "RuneValvran")
                    {
                        GetComponent<Ammo>().isFirstRuneValvran = false;
                        GetComponent<Ammo>().isSlotOneOccupiedValravn = false;
                        GetComponent<Ammo>().isActivateValvran = false;
                        isPresentValvran = false;
                        isFirsPresentRuneValvran = false;
                        RuneToPlayer.isTimeToValvran = false;
                    }
                    if (InventorySlotsEnemy[0].gameObject.tag == "RuneEye")
                    {
                        GetComponent<Ammo>().isFirstRuneEye = false;
                        GetComponent<Ammo>().isSlotOneOccupiedEye = false;
                        GetComponent<Ammo>().isActivateEye = false;
                        isPresentEye = false;
                        isFirsPresentRuneEye = false;
                        RuneToPlayer.isTimeToEye = false;
                    }
                    if (InventorySlotsEnemy[0].gameObject.tag == "RuneGreen")
                    {
                        GetComponent<Ammo>().isFirstRuneGreen = false;
                        GetComponent<Ammo>().isSlotOneOccupiedGreen = false;
                        GetComponent<Ammo>().isActivateGreen = false;
                        isPresentGreen = false;
                        isFirsPresentRuneGreen = false;
                        RuneToPlayer.isTimeToGreen = false;
                    }
                    if (InventorySlotsEnemy[0].gameObject.tag == "RuneDarkElf")
                    {
                        GetComponent<Ammo>().isFirstRuneDarkElf = false;
                        GetComponent<Ammo>().isSlotOneOccupiedDarkElf = false;
                        GetComponent<Ammo>().isActivateDarkElf = false;
                        isPresentDarkElf = false;
                        isFirsPresentRuneDarkElf = false;
                        RuneToPlayer.isTimeToDarkElf = false;
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
                        Ammo.AmmoW = 10;
                        Ammo.NumAmmoW0.text = Ammo.AmmoW.ToString();
                        tempIImageWow = 0;
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
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
                        Ammo.AmmoV = 10;
                        Ammo.NumAmmoV0.text = Ammo.AmmoV.ToString();
                        tempIImageValvran = 0;
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[0].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
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
                    }
                    if (other.gameObject.tag == "RuneBlue")
                    {
                        isPresentBlue = true;
                        InventorySlotsEnemy[0].GetComponent<RuneBlue>().enabled = true;
                        //BlueChange = true;
                        GetComponent<Ammo>().SlotRuneOne.texture = GetComponent<Ammo>().RuneBlueTexture[0];
                        tempIBlue = 1;
                        GetComponent<Ammo>().isFirstRuneBlue = true;
                        Ammo.NumAmmoBlue0.gameObject.SetActive(true);
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
                    }
                    if (other.gameObject.tag == "RuneYellow")
                    {
                        isPresentYellow = true;
                        InventorySlotsEnemy[0].GetComponent<RuneYellow>().enabled = true;
                        //YellowChange = true;
                        GetComponent<Ammo>().SlotRuneOne.texture = GetComponent<Ammo>().RuneYellowTexture[0];
                        tempIYellow = 0;
                        GetComponent<Ammo>().isFirstRuneYellow = true;
                        Ammo.NumAmmoYellow0.gameObject.SetActive(true);
                    }
                    if (other.gameObject.tag == "RuneOrange")
                    {
                        isPresentOrange = true;
                        InventorySlotsEnemy[0].GetComponent<RuneOrange>().enabled = true;
                        //RedChange = true;
                        GetComponent<Ammo>().SlotRuneOne.texture = GetComponent<Ammo>().RuneRedTexture[0];
                        tempIOrange = 0;
                        GetComponent<Ammo>().isFirstRuneRed = true;
                        Ammo.NumAmmoRed0.gameObject.SetActive(true);
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
                    }
                    if (other.gameObject.tag == "RuneDraugr")
                    {
                        isPresentDraugr = true;
                        InventorySlotsEnemy[0].GetComponent<RuneDraugr>().enabled = true;
                        //DraugrChange = true;
                        GetComponent<Ammo>().SlotRuneOne.texture = GetComponent<Ammo>().RuneDraugrTexture[0];
                        tempIDraugr = 0;
                        GetComponent<Ammo>().isFirstRuneDraugr = true;
                        Ammo.NumAmmoDraugr0.gameObject.SetActive(true);
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.F))                                                                                                                //Se schiaccio N (da cambiare poi in F + RightArrow)
        {
            if (Input.GetKey(KeyCode.RightArrow))                                                                                                                //Se schiaccio B (da cambiare poi in F + LeftArrow)
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
                    }
                    if (InventorySlotsEnemy[1].gameObject.tag == "RuneValvran")
                    {
                        GetComponent<Ammo>().isFirstRuneValvran = false;
                        GetComponent<Ammo>().isSlotOneOccupiedValravn = false;
                        isPresentValvran = false;
                        isFirsPresentRuneValvran = false;
                        RuneToPlayer.isTimeToValvran = false;
                    }
                    if (InventorySlotsEnemy[1].gameObject.tag == "RuneEye")
                    {
                        GetComponent<Ammo>().isFirstRuneEye = false;
                        GetComponent<Ammo>().isSlotOneOccupiedEye = false;
                        isPresentEye = false;
                        isFirsPresentRuneEye = false;
                        RuneToPlayer.isTimeToEye = false;
                    }
                    if (InventorySlotsEnemy[1].gameObject.tag == "RuneGreen")
                    {
                        GetComponent<Ammo>().isFirstRuneGreen = false;
                        GetComponent<Ammo>().isSlotOneOccupiedGreen = false;
                        isPresentGreen = false;
                        isFirsPresentRuneGreen = false;
                        RuneToPlayer.isTimeToGreen = false;
                    }
                    if (InventorySlotsEnemy[1].gameObject.tag == "RuneDarkElf")
                    {
                        GetComponent<Ammo>().isFirstRuneDarkElf = false;
                        GetComponent<Ammo>().isSlotOneOccupiedDarkElf = false;
                        isPresentDarkElf = false;
                        isFirsPresentRuneDarkElf = false;
                        RuneToPlayer.isTimeToDarkElf = false;
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
                        Ammo.AmmoW = 10;
                        Ammo.NumAmmoW1.text = Ammo.AmmoW.ToString();
                        tempIImageWow = 1;
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
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
                        Ammo.AmmoV = 10;
                        Ammo.NumAmmoV1.text = Ammo.AmmoV.ToString();
                        tempIImageValvran = 1;
                        Debug.Log("Ci arrivi qua nella verde image1");
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Particle.SetActive(false);
                        InventorySlotsEnemy[1].GetComponent<RuneToPlayer>().Shadow.SetActive(false);
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
                    }
                    if (other.gameObject.tag == "RuneBlue")
                    {
                        isPresentBlue = true;
                        InventorySlotsEnemy[1].GetComponent<RuneBlue>().enabled = true;
                        //BlueChange = true;
                        GetComponent<Ammo>().SlotRuneTwo.texture = GetComponent<Ammo>().RuneBlueTexture[0];
                        tempIBlue = 1;
                        GetComponent<Ammo>().isFirstRuneBlue = true;
                        Ammo.NumAmmoBlue1.gameObject.SetActive(true);
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
                    }
                    if (other.gameObject.tag == "RuneYellow")
                    {
                        isPresentYellow = true;
                        InventorySlotsEnemy[1].GetComponent<RuneYellow>().enabled = true;
                        //YellowChange = true;
                        GetComponent<Ammo>().SlotRuneTwo.texture = GetComponent<Ammo>().RuneYellowTexture[0];
                        tempIYellow = 1;
                        GetComponent<Ammo>().isFirstRuneYellow = true;
                        Ammo.NumAmmoYellow1.gameObject.SetActive(true);
                    }
                    if (other.gameObject.tag == "RuneOrange")
                    {
                        isPresentOrange = true;
                        InventorySlotsEnemy[1].GetComponent<RuneOrange>().enabled = true;
                        //RedChange = true;
                        GetComponent<Ammo>().SlotRuneTwo.texture = GetComponent<Ammo>().RuneRedTexture[0];
                        tempIOrange = 1;
                        GetComponent<Ammo>().isFirstRuneRed = true;
                        Ammo.NumAmmoRed1.gameObject.SetActive(true);
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
                    }
                    if (other.gameObject.tag == "RuneDraugr")
                    {
                        isPresentDraugr = true;
                        InventorySlotsEnemy[1].GetComponent<RuneDraugr>().enabled = true;
                        DraugrChange = true;
                        GetComponent<Ammo>().SlotRuneTwo.texture = GetComponent<Ammo>().RuneDraugrTexture[0];
                        tempIDraugr = 1;
                        GetComponent<Ammo>().isFirstRuneDraugr = true;
                        Ammo.NumAmmoDraugr1.gameObject.SetActive(true);
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.M))                                                                                                                //Se schiaccio B (da cambiare poi in F + UpArrow)
        {
            if (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva")                  //Se l'altro oggetto è uno di quelli proposti
            {
                Destroy(InventorySlotsBoss[0]);                                                                                                     //Distruggi l'oggetto nell'invetario Boss alla posizione 0
                InventorySlotsBoss[0] = other.gameObject;                                                                                           //Setta l'altro oggetto nell'inventario Boss alla posizione 0
                InventorySlotsBoss[0].transform.parent = Player.transform;                                                                          //Setta come parent il player
                InventorySlotsBoss[0].transform.position = new Vector3(transform.position.x, transform.position.y + 30, transform.position.z);      //Setta la posizione dell'oggetto appena scambiato
            }
        }
        #endregion
    }
}