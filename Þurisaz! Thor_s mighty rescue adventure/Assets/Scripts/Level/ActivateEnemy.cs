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
            }
        }
        if (CurrentScene.name == "ThirdLevel")              //Se la scena corrente è Third Level
        {
            if (other.gameObject.tag == "Player")
            {
                if (this.name == "1Trigger")
                {

                }
                if (this.name == "2Trigger")
                {

                }
                if (this.name == "3Trigger")
                {

                }
                if (this.name == "4Trigger")
                {

                }
                if (this.name == "5Trigger")
                {

                }
                if (this.name == "6Trigger")
                {
                    //Quarta stanza wisp4 e wisp5
                    isroom4Wow4IceLevel = true;
                    isroom4Wow5IceLevel = true;
                }
                if (this.name == "7Trigger")
                {

                }
                if (this.name == "8Trigger")
                {

                }
                if (this.name == "9Trigger")
                {

                }
                if (this.name == "10Trigger")
                {

                }
                if (this.name == "11Trigger")
                {

                }
                if (this.name == "12Trigger")
                {

                }
                if (this.name == "13Trigger")
                {

                }
                if (this.name == "14Trigger")
                {

                }
                if (this.name == "15Trigger")
                {

                }
                if (this.name == "16Trigger")
                {

                }
                if (this.name == "17Trigger")
                {

                }
                if (this.name == "18Trigger")
                {

                }
                if (this.name == "19Trigger")
                {

                }
                if (this.name == "20Trigger")
                {

                }
                if (this.name == "21Trigger")
                {

                }
                if (this.name == "22Trigger")
                {

                }
            }
        }
    }
}
