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
    static int NumberRuneEnemyCatch = 0;
    static int NumberRuneBossCatch = 0;

    static bool isTimeToWow = false;
    static bool isTimeToValvran = false;

    public MeshRenderer GraphicsRuneWow;
    public MeshRenderer GraphicsRuneValravn;
    public MeshRenderer GraphicsRuneGammur1;
    public MeshRenderer GraphicsRuneGammur2;
    public MeshRenderer GraphicsRuneGammur3;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
        RuneRawImageGammur1 = GameObject.Find("RuneGammur1RawImage").GetComponent<RawImage>();
        RuneRawImageGammur2 = GameObject.Find("RuneGammur2RawImage").GetComponent<RawImage>();
        RuneRawImageGammur3 = GameObject.Find("RuneGammur3RawImage").GetComponent<RawImage>();
        //RuneRawImageGammur1.enabled = false;
        //RuneRawImageGammur2.enabled = false;
        //RuneRawImageGammur3.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(NumberRuneEnemyCatch < 2)
            {
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
                if (InventorySystem.isFirsPresentRuneProva == false)
                {
                    if (gameObject.tag == "RuneProva")
                    {
                        print("Questa è il numero delle rune prese " + NumberRuneEnemyCatch);
                        transform.parent = Player.transform;
                        NumberRuneEnemyCatch++;
                        InventorySystem.isFirsPresentRuneProva = true;
                    }
                }
            }
            if(NumberRuneBossCatch < 1)
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
            if (gameObject.tag == "RuneWow")
            {
                if(isTimeToWow == false)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                    GetComponent<RuneAttack1>().enabled = true;
                    isTimeToWow = true;
                    GraphicsRuneWow.enabled = false;
                }
            }
            #endregion
            #region Rune Valvran
            if (gameObject.tag == "RuneValvran")
            {
                if (isTimeToValvran == false)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                    GetComponent<RuneAttackValvran>().enabled = true;
                    isTimeToValvran = true;
                    GraphicsRuneValravn.enabled = false;
                }
            }
            #endregion
            #region Rune Gammur
            if (gameObject.tag == "RuneGammur")
            {
                if(EnemyStats.rangeGammur == 1)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                    GetComponent<RuneAttackGammurOne>().enabled = true;
                    RuneRawImageGammur1.enabled = true;
                    GraphicsRuneGammur1.enabled = false;
                }
                if (EnemyStats.rangeGammur == 2)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                    GetComponent<RuneAttackGammurTwo>().enabled = true;
                    RuneRawImageGammur2.enabled = true;
                    GraphicsRuneGammur2.enabled = false;
                }
                if (EnemyStats.rangeGammur == 3)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                    GetComponent<RuneAttackGammurThree>().enabled = true;
                    RuneRawImageGammur3.enabled = true;
                    GraphicsRuneGammur3.enabled = false;
                }
            }
            #endregion
        }
    }
}
