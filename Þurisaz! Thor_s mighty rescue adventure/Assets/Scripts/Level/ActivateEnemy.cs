using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateEnemy : MonoBehaviour
{
    public static bool isRoom2 = false;
    public static bool isRoom3Wow = false;
    public static bool isRoom3Valravn = false;
    public static bool isRoom4Valravn2 = false;
    public static bool isRoom4Valravn3 = false;
    public static bool isRoom5 = false;

    public static bool isRoom3ArrowSound = false;
    public static bool isRoom4ArrowSound = false;

    public static bool isroom4Wow4IceLevel = false;
    public static bool isroom4Wow5IceLevel = false;

    Scene CurrentScene;






    public static bool isRoom7Wow1 = false;
    public static bool isRoom7Wow2 = false;
    public static bool isRoom8DarkElf1 = false;
    public static bool isRoom8DarkElf2 = false;
    public static bool isRoom9Eye1 = false;
    public static bool isRoom9Eye2 = false;
    public static bool isRoom9Green1 = false;
    public static bool isRoom6NewGreen1 = false;
    public static bool isRoom6NewValravn1 = false;




    private void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CurrentScene.name == "FirstLevel")              //Se la scena corrente è First Level
        {
            if (other.gameObject.tag == "Player")
            {
                if (this.name == "2Trigger")
                {
                    isRoom2 = true;
                }
                if (this.name == "3Trigger")
                {
                    isRoom3ArrowSound = false;
                }
                if (this.name == "4Trigger")
                {
                    isRoom3Wow = true;
                    isRoom3Valravn = true;
                    isRoom3ArrowSound = true;
                }
                if (this.name == "5Trigger")
                {
                    isRoom4ArrowSound = false;
                }
                if (this.name == "6Trigger")
                {
                    isRoom3ArrowSound = false;
                    isRoom4Valravn2 = true;
                    isRoom4Valravn3 = true;
                    isRoom4ArrowSound = true;
                }
                if (this.name == "7Trigger")
                {
                    isRoom4ArrowSound = false;
                }
                if (this.name == "8Trigger")
                {
                    isRoom5 = true;
                }



                //if (this.name == "9Trigger")
                //{
                //
                //}
                //if (this.name == "10Trigger")
                //{
                //
                //}
                //if (this.name == "11Trigger")   //Entro nella stanza 3 dalla 7
                //{
                //
                //}
                if (this.name == "12Trigger")   //Entro nella stanza 7 dalla 3
                {
                    //Attivo nemici will o wisp
                    isRoom7Wow1 = true;
                    isRoom7Wow2 = true;
                }
                //if (this.name == "13Trigger")   //Entro nella stanza 4 dalla 8
                //{
                //    
                //}
                if (this.name == "14Trigger")   //Entro nella stanza 8 dalla 4
                {
                    //Attivo nemici Dark Elf
                    isRoom8DarkElf1 = true;
                    isRoom8DarkElf2 = true;
                }
                //if (this.name == "15Trigger")   //Entro nella stanza 8 dalla 9
                //{
                //
                //}
                if (this.name == "16Trigger")   //Entro nella stanza 9 dalla 8
                {
                    //Attivo occhi e cervo
                    isRoom9Eye1 = true;
                    isRoom9Eye2 = true;
                    isRoom9Green1 = true;
                }
                if (this.name == "17Trigger")   //Entro nella stanza 6 (New) dalla 5
                {
                    //Attivo cervo e valravn
                    isRoom6NewGreen1 = true;
                    isRoom6NewValravn1 = true;
                }
                //if (this.name == "18Trigger")   //Entro nella stanza 5 dalla 6 (New)
                //{
                //
                //}
                if (this.name == "19Trigger")   //Entro nella stanza 7 dalla 8
                {
                    //Attivo will o wisp
                    isRoom7Wow1 = true;
                    isRoom7Wow2 = true;
                }
                if (this.name == "20Trigger")   //Entro nella stanza 8 dalla 7
                {
                    //Attivo dark elf
                    isRoom8DarkElf1 = true;
                    isRoom8DarkElf2 = true;
                }
            }
        }
        #region Piano Ghiacciato
        //if (CurrentScene.name == "ThirdLevel")              //Se la scena corrente è Third Level
        //{
        //    if (other.gameObject.tag == "Player")
        //    {
        //        if (this.name == "1Trigger")
        //        {
        //
        //        }
        //        if (this.name == "2Trigger")
        //        {
        //
        //        }
        //        if (this.name == "3Trigger")
        //        {
        //
        //        }
        //        if (this.name == "4Trigger")
        //        {
        //
        //        }
        //        if (this.name == "5Trigger")
        //        {
        //
        //        }
        //        if (this.name == "6Trigger")
        //        {
        //            //Quarta stanza wisp4 e wisp5
        //            isroom4Wow4IceLevel = true;
        //            isroom4Wow5IceLevel = true;
        //        }
        //        if (this.name == "7Trigger")
        //        {
        //
        //        }
        //        if (this.name == "8Trigger")
        //        {
        //
        //        }
        //        if (this.name == "9Trigger")
        //        {
        //
        //        }
        //        if (this.name == "10Trigger")
        //        {
        //
        //        }
        //        if (this.name == "11Trigger")
        //        {
        //
        //        }
        //        if (this.name == "12Trigger")
        //        {
        //
        //        }
        //        if (this.name == "13Trigger")
        //        {
        //
        //        }
        //        if (this.name == "14Trigger")
        //        {
        //
        //        }
        //        if (this.name == "15Trigger")
        //        {
        //
        //        }
        //        if (this.name == "16Trigger")
        //        {
        //
        //        }
        //        if (this.name == "17Trigger")
        //        {
        //
        //        }
        //        if (this.name == "18Trigger")
        //        {
        //
        //        }
        //        if (this.name == "19Trigger")
        //        {
        //
        //        }
        //        if (this.name == "20Trigger")
        //        {
        //
        //        }
        //        if (this.name == "21Trigger")
        //        {
        //
        //        }
        //        if (this.name == "22Trigger")
        //        {
        //
        //        }
        //    }
        //}
        #endregion
    }
}
