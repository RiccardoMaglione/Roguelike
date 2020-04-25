using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{

    public GameObject[] InventorySlotsEnemy = new GameObject[2];
    static public int i = 0;
    public bool isPresentWow = false;
    public bool isPresentValvran = false;
    public bool isPresentProve = false;

    static public bool isFirsPresentRuneWow = false;
    static public bool isFirsPresentRuneValvran = false;
    static public bool isFirsPresentRuneProva = false;

    public GameObject[] InventorySlotsBoss = new GameObject[1];
    static public int j = 0;
    public bool isPresentGammur = false;

    static public bool isFirsPresentRuneGammur = false;

    GameObject TempRuneOne;
    GameObject TempRuneTwo;
    GameObject TempRuneThree;

    GameObject Player;

    public static int tempIWow;
    public static int tempIValvran;

    public static int tempIImageWow;
    public static int tempIImageValvran;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(i < 2 && (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva"))
        {
            if(other.gameObject.tag == "RuneWow" && isPresentWow == false)
            {
                tempIWow = i;
                tempIImageWow = i;
                InventorySlotsEnemy[i] = other.gameObject;
                i++;
                isPresentWow = true;
            }
            if (other.gameObject.tag == "RuneValvran" && isPresentValvran == false)
            {
                tempIValvran = i;
                tempIImageValvran = i;
                InventorySlotsEnemy[i] = other.gameObject;
                i++;
                isPresentValvran = true;
            }
            if (other.gameObject.tag == "RuneProva" && isPresentProve == false)
            {
                InventorySlotsEnemy[i] = other.gameObject;
                i++;
                isPresentProve = true;
            }
        }
        if (j < 1 && other.gameObject.tag == "RuneGammur")
        {
            if (other.gameObject.tag == "RuneGammur" && isPresentGammur == false)
            {
                InventorySlotsBoss[j] = other.gameObject;
                j++;
                isPresentGammur = true;
            }
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.B))
        {
            if (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva")
            {
                Destroy(InventorySlotsEnemy[0]);
                InventorySlotsEnemy[0] = other.gameObject;
                InventorySlotsEnemy[0].transform.parent = Player.transform;
                InventorySlotsEnemy[0].transform.position = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.N))
        {
            if (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva")
            {
                Destroy(InventorySlotsEnemy[1]);
                InventorySlotsEnemy[1] = other.gameObject;
                InventorySlotsEnemy[1].transform.parent = Player.transform;
                InventorySlotsEnemy[1].transform.position = new Vector3(transform.position.x, transform.position.y + 20, transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.M))
        {
            if (other.gameObject.tag == "RuneWow" || other.gameObject.tag == "RuneValvran" || other.gameObject.tag == "RuneProva")
            {
                Destroy(InventorySlotsBoss[0]);
                InventorySlotsBoss[0] = other.gameObject;
                InventorySlotsBoss[0].transform.parent = Player.transform;
                InventorySlotsBoss[0].transform.position = new Vector3(transform.position.x, transform.position.y + 30, transform.position.z);
            }
        }
    }

}
