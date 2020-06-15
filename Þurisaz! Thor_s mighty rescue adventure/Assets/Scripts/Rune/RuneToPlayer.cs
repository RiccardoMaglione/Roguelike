using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneToPlayer : MonoBehaviour
{
    GameObject Player;
    RawImage RuneRawImageGammur1;
    RawImage RuneRawImageGammur2;
    RawImage RuneRawImageGammur3;
    public static int NumberRuneEnemyCatch = 0;
    static int NumberRuneBossCatch = 0;

    static public bool isTimeToWow = false;
    static public bool isTimeToValvran = false;

    public MeshRenderer GraphicsRuneWow;
    public MeshRenderer GraphicsRuneValravn;
    public MeshRenderer GraphicsRuneGammur1;
    public MeshRenderer GraphicsRuneGammur2;
    public MeshRenderer GraphicsRuneGammur3;

    #region Altre rune

    static public bool isTimeToEye = false;
    static public bool isTimeToBlue = false;
    static public bool isTimeToGreen = false;
    static public bool isTimeToYellow = false;
    static public bool isTimeToOrange = false;
    static public bool isTimeToDarkElf = false;
    static public bool isTimeToDraugr = false;


    public MeshRenderer GraphicsRuneEye;
    public MeshRenderer GraphicsRuneDeerBlue;
    public MeshRenderer GraphicsRuneDeerGreen;
    public MeshRenderer GraphicsRuneDeerYellow;
    public MeshRenderer GraphicsRuneDeerOrange;
    public MeshRenderer GraphicsRuneDarkElf;
    public MeshRenderer GraphicsRuneDraugr;
    #endregion

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        RuneRawImageGammur1 = GameObject.Find("RuneGammur1RawImage").GetComponent<RawImage>();
        RuneRawImageGammur2 = GameObject.Find("RuneGammur2RawImage").GetComponent<RawImage>();
        RuneRawImageGammur3 = GameObject.Find("RuneGammur3RawImage").GetComponent<RawImage>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(NumberRuneEnemyCatch < 2)
            {
                Debug.Log("Questo è il numero delle rune degli enemy prese finora "+NumberRuneEnemyCatch);
                if (InventorySystem.isFirsPresentRuneWow == false)
                {
                    if (gameObject.tag == "RuneWow")
                    {
                        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                        transform.parent = Player.transform;
                        NumberRuneEnemyCatch++;
                        InventorySystem.isFirsPresentRuneWow = true;
                    }
                }
                if (InventorySystem.isFirsPresentRuneValvran == false)
                {
                    if (gameObject.tag == "RuneValvran")
                    {
                        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                        transform.parent = Player.transform;
                        NumberRuneEnemyCatch++;
                        InventorySystem.isFirsPresentRuneValvran = true;
                    }
                }
                //if (InventorySystem.isFirsPresentRuneProva == false)
                //{
                //    if (gameObject.tag == "RuneProva")
                //    {
                //        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                //        transform.parent = Player.transform;
                //        NumberRuneEnemyCatch++;
                //        InventorySystem.isFirsPresentRuneProva = true;
                //    }
                //}

                #region Inventario rune nuove
                if (InventorySystem.isFirsPresentRuneEye == false)
                {
                    if (gameObject.tag == "RuneEye")
                    {
                        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                        transform.parent = Player.transform;
                        NumberRuneEnemyCatch++;
                        InventorySystem.isFirsPresentRuneEye = true;
                    }
                }
                if (InventorySystem.isFirsPresentRuneBlue == false)
                {
                    if (gameObject.tag == "RuneBlue")
                    {
                        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                        transform.parent = Player.transform;
                        NumberRuneEnemyCatch++;
                        InventorySystem.isFirsPresentRuneBlue = true;
                    }
                }
                if (InventorySystem.isFirsPresentRuneGreen == false)
                {
                    if (gameObject.tag == "RuneGreen")
                    {
                        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                        transform.parent = Player.transform;
                        NumberRuneEnemyCatch++;
                        InventorySystem.isFirsPresentRuneGreen = true;
                    }
                }
                if (InventorySystem.isFirsPresentRuneYellow == false)
                {
                    if (gameObject.tag == "RuneYellow")
                    {
                        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                        transform.parent = Player.transform;
                        NumberRuneEnemyCatch++;
                        InventorySystem.isFirsPresentRuneYellow = true;
                    }
                }
                if (InventorySystem.isFirsPresentRuneOrange == false)
                {
                    if (gameObject.tag == "RuneOrange")
                    {
                        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                        transform.parent = Player.transform;
                        NumberRuneEnemyCatch++;
                        InventorySystem.isFirsPresentRuneOrange = true;
                    }
                }
                if (InventorySystem.isFirsPresentRuneDarkElf == false)
                {
                    if (gameObject.tag == "RuneDarkElf")
                    {
                        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                        transform.parent = Player.transform;
                        NumberRuneEnemyCatch++;
                        InventorySystem.isFirsPresentRuneDarkElf = true;
                    }
                }
                if (InventorySystem.isFirsPresentRuneDraugr == false)
                {
                    if (gameObject.tag == "RuneDraugr")
                    {
                        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                        transform.parent = Player.transform;
                        NumberRuneEnemyCatch++;
                        InventorySystem.isFirsPresentRuneDraugr = true;
                    }
                }
                #endregion
            }
            if (NumberRuneBossCatch < 1)
            {
                if (InventorySystem.isFirsPresentRuneGammur == false)
                {
                    if (gameObject.tag == "RuneGammur")
                    {
                        print("Questa è il numero delle rune prese dai boss " + NumberRuneBossCatch);
                        transform.parent = Player.transform;
                        NumberRuneBossCatch++;
                        InventorySystem.isFirsPresentRuneGammur = true;
                    }
                }
            }


            #region Rune Wow
            if (gameObject.tag == "RuneWow" && InventorySystem.isFirsPresentRuneWow == true)
            {
                Debug.Log("Almeno qua?");
                if (isTimeToWow == false)
                {
                    Debug.Log("Entro qui dentro");
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    GetComponent<RuneWow>().enabled = true;
                    isTimeToWow = true;
                    GraphicsRuneWow.enabled = false;
                }
            }
            #endregion
            #region Rune Valvran
            if (gameObject.tag == "RuneValvran" && InventorySystem.isFirsPresentRuneValvran == true)
            {
                if (isTimeToValvran == false)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                    GetComponent<RuneValravn>().enabled = true;
                    isTimeToValvran = true;
                    GraphicsRuneValravn.enabled = false;
                }
            }
            #endregion
            #region Rune Gammur
            if (gameObject.tag == "RuneGammur")
            {
                if(EnemyManager.rangeGammur == 1)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                    GetComponent<RuneGammurOne>().enabled = true;
                    RuneRawImageGammur1.enabled = true;
                    GraphicsRuneGammur1.enabled = false;
                }
                if (EnemyManager.rangeGammur == 2)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                    GetComponent<RuneGammurTwo>().enabled = true;
                    RuneRawImageGammur2.enabled = true;
                    GraphicsRuneGammur2.enabled = false;
                }
                if (EnemyManager.rangeGammur == 3)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                    GetComponent<RuneGammurThree>().enabled = true;
                    RuneRawImageGammur3.enabled = true;
                    GraphicsRuneGammur3.enabled = false;
                }
            }
            #endregion
            //Rune wow
            //rune valravn
            //rune gammur
            #region Rune da sistemare
            
            #region Eye
            if (gameObject.tag == "RuneEye" && InventorySystem.isFirsPresentRuneEye == true)
            {
                if (isTimeToEye == false)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z);
                    GetComponent<RuneEye>().enabled = true;
                    GetComponent<BoxCollider>().enabled = false;
                    isTimeToEye = true;
                    GraphicsRuneEye.enabled = false;
                }
            }
            #endregion
            #region Blue Deer
            if (gameObject.tag == "RuneBlue" && InventorySystem.isFirsPresentRuneBlue == true)
            {
                if (isTimeToBlue == false)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    GetComponent<RuneBlue>().enabled = true;
                    isTimeToBlue = true;
                    GraphicsRuneDeerBlue.enabled = false;
                }
            }
            #endregion
            #region Green Deer
            if (gameObject.tag == "RuneGreen" && InventorySystem.isFirsPresentRuneGreen == true)
            {
                if (isTimeToGreen == false)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    GetComponent<RuneGreen>().enabled = true;
                    isTimeToGreen = true;
                    GraphicsRuneDeerGreen.enabled = false;
                }
            }
            #endregion
            #region Yellow Deer
            if (gameObject.tag == "RuneYellow" && InventorySystem.isFirsPresentRuneYellow == true)
            {
                if (isTimeToYellow == false)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    GetComponent<RuneYellow>().enabled = true;
                    isTimeToYellow = true;
                    GraphicsRuneDeerYellow.enabled = false;
                }
            }
            #endregion
            #region Orange Deer
            if (gameObject.tag == "RuneOrange" && InventorySystem.isFirsPresentRuneOrange == true)
            {
                if (isTimeToOrange == false)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    GetComponent<RuneOrange>().enabled = true;
                    isTimeToOrange = true;
                    GraphicsRuneDeerOrange.enabled = false;
                }
            }
            #endregion
            #region Dark Elf
            if (gameObject.tag == "RuneDarkElf" && InventorySystem.isFirsPresentRuneDarkElf == true)
            {
                if (isTimeToDarkElf == false)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    GetComponent<RuneDarkElf>().enabled = true;
                    isTimeToDarkElf = true;
                    GraphicsRuneDarkElf.enabled = false;
                }
            }
            #endregion
            #region Draugr
            if (gameObject.tag == "RuneDraugr" && InventorySystem.isFirsPresentRuneDraugr == true)
            {
                if (isTimeToDraugr == false)
                {
                    transform.parent = Player.transform;
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    GetComponent<RuneDraugr>().enabled = true;
                    isTimeToDraugr = true;
                    GraphicsRuneDraugr.enabled = false;
                }
            }
            #endregion
            //rune eye
            //rune deer blue
            //rune deer green
            //rune deer yellow
            //rune deer orange

            #endregion

        }
    }

    private void Update()
    {
        Debug.Log("saddddddddddddddddddddddddd "+NumberRuneEnemyCatch);
    }
}
