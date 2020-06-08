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
    public bool isPresentEye = false;
    public bool isPresentBlue = false;
    public bool isPresentGreen = false;
    public bool isPresentYellow = false;
    public bool isPresentOrange = false;
    static public bool tempIsPresentEye = false;
    static public bool tempIsPresentBlue = false;
    static public bool tempIsPresentGreen = false;
    static public bool tempIsPresentYellow = false;
    static public bool tempIsPresentOrange = false;
    public static int tempIEye;
    public static int tempIBlue;
    public static int tempIGreen;
    public static int tempIYellow;
    public static int tempIOrange;
    public static int tempIImageEye;
    public static int tempIImageBlue;
    public static int tempIImageGreen;
    public static int tempIImageYellow;
    public static int tempIImageOrange;
    static public bool isFirsPresentRuneEye = false;
    static public bool isFirsPresentRuneBlue = false;
    static public bool isFirsPresentRuneGreen = false;
    static public bool isFirsPresentRuneYellow = false;
    static public bool isFirsPresentRuneOrange = false;
    #endregion

    public int ciao;
    public int ciao2;

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

        
        if(i < 2 && (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva" || other.gameObject.tag == "RuneEye" || other.gameObject.tag == "RuneBlue" || other.gameObject.tag == "RuneGreen" || other.gameObject.tag == "RuneYellow" || other.gameObject.tag == "RuneOrange"))        //Se i<2 e l'altro oggetto ha un particolare tag
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
        if (Input.GetKey(KeyCode.B))                                                                                                                //Se schiaccio B (da cambiare poi in F + LeftArrow)
        {
            if (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva" || other.gameObject.tag == "RuneEye" || other.gameObject.tag == "RuneBlue" || other.gameObject.tag == "RuneGreen" || other.gameObject.tag == "RuneYellow" || other.gameObject.tag == "RuneOrange")                  //Se l'altro oggetto è uno di quelli proposti
            {
                Destroy(InventorySlotsEnemy[0]);                                                                                                    //Distruggi l'oggetto nell'invetario Enemy alla posizione 0
                InventorySlotsEnemy[0] = other.gameObject;                                                                                          //Setta l'altro oggetto nell'inventario Enemy alla posizione 0
                InventorySlotsEnemy[0].transform.parent = Player.transform;                                                                         //Setta come parent il player
                InventorySlotsEnemy[0].transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);     //Setta la posizione dell'oggetto appena scambiato
                //if runa tag, setto il present rune
                //Sistemare 
                if (other.gameObject.tag == "RuneEye")
                {
                    isPresentEye = true;
                    InventorySlotsEnemy[0].GetComponent<RuneEye>().enabled = true;
                }
                if (other.gameObject.tag == "RuneBlue")
                {
                    isPresentBlue = true;
                    InventorySlotsEnemy[0].GetComponent<RuneBlue>().enabled = true;
                }
                if (other.gameObject.tag == "RuneGreen")
                {
                    isPresentGreen = true;
                    InventorySlotsEnemy[0].GetComponent<RuneGreen>().enabled = true;
                }
                if (other.gameObject.tag == "RuneYellow")
                {
                    isPresentYellow = true;
                    InventorySlotsEnemy[0].GetComponent<RuneYellow>().enabled = true;
                }
                if (other.gameObject.tag == "RuneOrange")
                {
                    isPresentOrange = true;
                    InventorySlotsEnemy[0].GetComponent<RuneOrange>().enabled = true;
                }
            }
        }
        if (Input.GetKey(KeyCode.N))                                                                                                                //Se schiaccio N (da cambiare poi in F + RightArrow)
        {
            if (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva" || other.gameObject.tag == "RuneEye" || other.gameObject.tag == "RuneBlue" || other.gameObject.tag == "RuneGreen" || other.gameObject.tag == "RuneYellow" || other.gameObject.tag == "RuneOrange")                  //Se l'altro oggetto è uno di quelli proposti
            {
                Destroy(InventorySlotsEnemy[1]);                                                                                                    //Distruggi l'oggetto nell'invetario Enemy alla posizione 1
                InventorySlotsEnemy[1] = other.gameObject;                                                                                          //Setta l'altro oggetto nell'inventario Enemy alla posizione 1
                InventorySlotsEnemy[1].transform.parent = Player.transform;                                                                         //Setta come parent il player
                InventorySlotsEnemy[1].transform.position = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);     //Setta la posizione dell'oggetto appena scambiato
                //Sistemare                                                                                                                                    //if runa tag, setto il present rune
                if (other.gameObject.tag == "RuneEye")
                {
                    isPresentEye = true;
                    InventorySlotsEnemy[1].GetComponent<RuneEye>().enabled = true;
                }
                if (other.gameObject.tag == "RuneBlue")
                {
                    isPresentBlue = true;
                    InventorySlotsEnemy[1].GetComponent<RuneBlue>().enabled = true;
                }
                if (other.gameObject.tag == "RuneGreen")
                {
                    isPresentGreen = true;
                    InventorySlotsEnemy[1].GetComponent<RuneGreen>().enabled = true;
                }
                if (other.gameObject.tag == "RuneYellow")
                {
                    isPresentYellow = true;
                    InventorySlotsEnemy[1].GetComponent<RuneYellow>().enabled = true;
                }
                if (other.gameObject.tag == "RuneOrange")
                {
                    isPresentOrange = true;
                    InventorySlotsEnemy[1].GetComponent<RuneOrange>().enabled = true;
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