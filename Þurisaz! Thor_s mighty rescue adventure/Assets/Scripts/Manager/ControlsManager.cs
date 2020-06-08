using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public static ControlsManager CM;

    public KeyCode jump { get; set; }
    public KeyCode forward { get; set; }
    public KeyCode backward { get; set; }
    public KeyCode left { get; set; }
    public KeyCode right { get; set; }



    public KeyCode runeOne { get; set; }
    public KeyCode runeTwo { get; set; }
    public KeyCode runeThree { get; set; }
    public KeyCode changeRune { get; set; }
    public KeyCode pause { get; set; }

    void Awake()
    {
        // Creating a singleton 
        if (CM == null)
        {
            DontDestroyOnLoad(gameObject);
            CM = this;
        }
        else if (CM != this)
        {
            Destroy(gameObject);
        }

        // Enum.Parse casts the preferred player input from the local machine to the keyCode
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("leftKey", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));

        runeOne = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("runeOneKey", "LeftArrow"));
        runeTwo = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("runeTwoKey", "RightArrow"));
        runeThree = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("runeThreeKey", "UpArrow"));
        changeRune = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("changeRuneKey", "F"));
        pause = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("pauseKey", "Escape"));
    }
}
