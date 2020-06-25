using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    public static int WallW = 1;
    public static int WallS = 1;
    public static int WallA = 1;
    public static int WallD = 1;

    public GameObject go1;
    public GameObject go2;
    public GameObject go3;
    public GameObject go4;

    public GameObject go6;
    public GameObject go7;
    public GameObject go8;

    public GameObject go9;
    public GameObject go10;
    public GameObject go11;
    public GameObject go12;
    public GameObject go13;
    public GameObject go14;
    public GameObject go15;
    public GameObject go16;
    public GameObject go17;

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "WallW")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 0;
            }
        }
        if (gameObject.tag == "WallS")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 0;
            }
        }
        if (gameObject.tag == "WallA")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 0;
            }
        }
        if (gameObject.tag == "WallD")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyWow1")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyWow2")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyWow3")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyWow4")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 0;
            }
        }

        if (this.gameObject.name == "WallEnemyWow6")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyWow7")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyWow8")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 0;
            }
        }










        if (this.gameObject.name == "WallEnemyValravn1")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn2")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn3")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn4")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn5")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn6")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn7")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 0;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn8")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 0;
            }
        }



        if (this.gameObject.name == "WallDGammur")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 0;
            }
        }



    }
    private void OnTriggerStay(Collider other)
    {
        if (gameObject.tag == "WallW")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 0;
            }
        }
        if (gameObject.tag == "WallS")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 0;
            }
        }
        if (gameObject.tag == "WallA")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 0;
            }
        }
        if (gameObject.tag == "WallD")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "WallW")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 1;
            }
        }
        if (gameObject.tag == "WallS")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 1;
            }
        }
        if (gameObject.tag == "WallA")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 1;
            }
        }
        if (gameObject.tag == "WallD")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyWow1")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyWow2")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyWow3")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyWow4")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyWow6")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyWow7")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyWow8")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn1")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn2")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn3")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn4")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn5")
        {
            if (other.gameObject.tag == "Player")
            {
                WallW = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn6")
        {
            if (other.gameObject.tag == "Player")
            {
                WallS = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn7")
        {
            if (other.gameObject.tag == "Player")
            {
                WallA = 1;
            }
        }
        if (this.gameObject.name == "WallEnemyValravn8")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 1;
            }
        }
        if (this.gameObject.name == "WallDGammur")
        {
            if (other.gameObject.tag == "Player")
            {
                WallD = 1;
            }
        }
    }


    private void Update()
    {
        if (EnemyManager.WallWow2 == true)
        {
            StartCoroutine(WallEnemyWow2());
        }
        if (EnemyManager.WallWow3 == true)
        {
            StartCoroutine(WallEnemyWow3());
        }
        if (EnemyManager.WallValravn2 == true)
        {
            StartCoroutine(WallEnemyValravn2());
        }
        if (EnemyManager.WallValravn3 == true)
        {
            StartCoroutine(WallEnemyValravn3());
        }
        if (EnemyManager.GammurDeath == true)
        {
            StartCoroutine(WallEnemyGammur());
        }
    }

    IEnumerator WallEnemyWow2()
    {
        if (EnemyManager.WallWow2 == true)
        {
            print("funziona? aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa 2");
            WallW = 1;
            WallS = 1;
            WallA = 1;
            WallD = 1;
            yield return new WaitForSeconds(0.2f);
            Destroy(go1);
            Destroy(go2);
            Destroy(go3);
            Destroy(go4);
            EnemyManager.WallWow2 = false;
        }
    }
    IEnumerator WallEnemyWow3()
    {
        if (EnemyManager.WallWow3 == true)
        {
            print("funziona? aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa 3");
            WallW = 1;
            WallS = 1;
            WallA = 1;
            WallD = 1;
            yield return new WaitForSeconds(0.2f);
            Destroy(go6);
            Destroy(go7);
            Destroy(go8);
            EnemyManager.WallWow3 = false;
        }
    }
    IEnumerator WallEnemyValravn2()
    {
        if (EnemyManager.WallValravn2 == true)
        {
            print("funziona? aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa 4");
            WallW = 1;
            WallS = 1;
            WallA = 1;
            WallD = 1;
            yield return new WaitForSeconds(0.2f);
            Destroy(go9);
            Destroy(go10);
            Destroy(go11);
            Destroy(go12);
            EnemyManager.WallValravn2 = false;
        }
    }
    IEnumerator WallEnemyValravn3()
    {
        if (EnemyManager.WallValravn3 == true)
        {
            print("funziona? aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa 5");
            WallW = 1;
            WallS = 1;
            WallA = 1;
            WallD = 1;
            yield return new WaitForSeconds(0.2f);
            Destroy(go13);
            Destroy(go14);
            Destroy(go15);
            Destroy(go16);
            EnemyManager.WallValravn3 = false;
        }
    }



    IEnumerator WallEnemyGammur()
    {
        if (EnemyManager.GammurDeath == true)
        {
            print("funziona? aaaaaaaaaaaaaaaaaaaaaaaaaaaaaa 5");
            WallW = 1;
            WallS = 1;
            WallA = 1;
            WallD = 1;
            yield return new WaitForSeconds(0.2f);
            Destroy(go17);
            EnemyManager.GammurDeath = false;
        }
    }
}