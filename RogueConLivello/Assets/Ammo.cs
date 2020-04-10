using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    GameObject RuneWoW;
    GameObject RuneValvran;
    public static int AmmoW = 0;
    public static int AmmoV = 0;
    bool isFirstRuneWow = false;
    bool isFirstRuneValvran = false;

    private void OnTriggerEnter(Collider other)
    {
        #region Rune Will o Wisp
        if (other.gameObject.tag == "RuneWow" && isFirstRuneWow == false)
        {
            AmmoW = 10;
            RuneWoW = other.gameObject;
            isFirstRuneWow = true;
            Debug.Log(AmmoW);
        }
        else if(other.gameObject.tag == "RuneWow" && isFirstRuneWow == true)
        {
            AmmoW += 10;
            Destroy(other.gameObject);
        }
        #endregion

        #region Rune Valvran
        if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == false)
        {   
            AmmoV = 10;
            RuneValvran = other.gameObject;
            isFirstRuneValvran = true;
            Debug.Log(AmmoV);
        }
        else if (other.gameObject.tag == "RuneValvran" && isFirstRuneValvran == true)
        {
            AmmoV += 10;
            Destroy(other.gameObject);
        }
        #endregion
    }

    void Update()
    {
        Debug.Log(AmmoW);
        Debug.Log(AmmoV);
        #region Ammo Will o Wisp
            if (AmmoW <= -1)
            {
                Destroy(RuneWoW.gameObject);
                isFirstRuneWow = false;
            }
        #endregion

        #region Ammo Valvran
            if (AmmoV <= -1)
            {
                Destroy(RuneValvran.gameObject);
                isFirstRuneValvran = false;
            }
        #endregion
    }
}
