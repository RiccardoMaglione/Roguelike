using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeControls : MonoBehaviour
{
    public GameObject PanelReset;
    Transform menuPanel;
    Event keyEvent;
    Text buttonText;
    KeyCode newKey;

    bool waitingForKey;


    void Start()
    {
        PanelReset.gameObject.SetActive(false);
        menuPanel = transform.Find("Area");
        waitingForKey = false;

        for (int i = 0; i < menuPanel.childCount; i++)
        {
            if (menuPanel.GetChild(i).name == "ForwardKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.forward.ToString();
            else if (menuPanel.GetChild(i).name == "BackwardKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.backward.ToString();
            else if (menuPanel.GetChild(i).name == "LeftKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.left.ToString();
            else if (menuPanel.GetChild(i).name == "RightKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.right.ToString();
            else if (menuPanel.GetChild(i).name == "JumpKey")
                menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.jump.ToString();


              else if (menuPanel.GetChild(i).name == "RuneOneKey")
                  menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.runeOne.ToString();
              else if (menuPanel.GetChild(i).name == "RuneTwoKey")
                  menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.runeTwo.ToString();
              else if (menuPanel.GetChild(i).name == "RuneThreeKey")
                  menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.runeThree.ToString();
              else if (menuPanel.GetChild(i).name == "ChangeRuneKey")
                  menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.changeRune.ToString();
              else if (menuPanel.GetChild(i).name == "PauseKey")
                  menuPanel.GetChild(i).GetComponentInChildren<Text>().text = ControlsManager.CM.pause.ToString();

        }
    }

    void OnGUI()
    {
        keyEvent = Event.current;

        //Executes if a button gets pressed and
        //the user presses a key
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode; //Assigns newKey to the key user presses
            waitingForKey = false;
        }
    }

    public void StartAssignment(string keyName)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyName));
    }

    //Assigns buttonText to the text component of
    //the button that was pressed
    public void SendText(Text text)
    {
        buttonText = text;
    }

    //Used for controlling the flow of our below Coroutine
    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }

    public IEnumerator AssignKey(string keyName)
    {
        waitingForKey = true;

        yield return WaitForKey(); //Executes endlessly until user presses a key

        switch (keyName)
        {
            case "forward":
                ControlsManager.CM.forward = newKey; //Set forward to new keycode
                buttonText.text = ControlsManager.CM.forward.ToString(); //Set button text to new key
                PlayerPrefs.SetString("forwardKey", ControlsManager.CM.forward.ToString()); //save new key to PlayerPrefs
                break;
            case "backward":
                ControlsManager.CM.backward = newKey; //set backward to new keycode
                buttonText.text = ControlsManager.CM.backward.ToString(); //set button text to new key
                PlayerPrefs.SetString("backwardKey", ControlsManager.CM.backward.ToString()); //save new key to PlayerPrefs
                break;
            case "left":
                ControlsManager.CM.left = newKey; //set left to new keycode
                buttonText.text = ControlsManager.CM.left.ToString(); //set button text to new key
                PlayerPrefs.SetString("leftKey", ControlsManager.CM.left.ToString()); //save new key to playerprefs
                break;
            case "right":
                ControlsManager.CM.right = newKey; //set right to new keycode
                buttonText.text = ControlsManager.CM.right.ToString(); //set button text to new key
                PlayerPrefs.SetString("rightKey", ControlsManager.CM.right.ToString()); //save new key to playerprefs
                break;
            case "jump":
                ControlsManager.CM.jump = newKey; //set jump to new keycode
                buttonText.text = ControlsManager.CM.jump.ToString(); //set button text to new key
                PlayerPrefs.SetString("jumpKey", ControlsManager.CM.jump.ToString()); //save new key to playerprefs
                break;


            case "runeOne":
                ControlsManager.CM.runeOne = newKey; //Set forward to new keycode
                buttonText.text = ControlsManager.CM.runeOne.ToString(); //Set button text to new key
                PlayerPrefs.SetString("runeOneKey", ControlsManager.CM.runeOne.ToString()); //save new key to PlayerPrefs
                break;
            case "runeTwo":
                ControlsManager.CM.runeTwo = newKey; //set backward to new keycode
                buttonText.text = ControlsManager.CM.runeTwo.ToString(); //set button text to new key
                PlayerPrefs.SetString("runeTwoKey", ControlsManager.CM.runeTwo.ToString()); //save new key to PlayerPrefs
                break;
            case "runeThree":
                ControlsManager.CM.runeThree = newKey; //set left to new keycode
                buttonText.text = ControlsManager.CM.runeThree.ToString(); //set button text to new key
                PlayerPrefs.SetString("runeThreeKey", ControlsManager.CM.runeThree.ToString()); //save new key to playerprefs
                break;
            case "changeRune":
                ControlsManager.CM.changeRune = newKey; //set right to new keycode
                buttonText.text = ControlsManager.CM.changeRune.ToString(); //set button text to new key
                PlayerPrefs.SetString("changeRuneKey", ControlsManager.CM.changeRune.ToString()); //save new key to playerprefs
                break;
            case "pause":
                ControlsManager.CM.pause = newKey; //set jump to new keycode
                buttonText.text = ControlsManager.CM.pause.ToString(); //set button text to new key
                PlayerPrefs.SetString("pauseKey", ControlsManager.CM.pause.ToString()); //save new key to playerprefs
                break;



        }

        yield return null;
    }



    public void ResetKey()
    {

        PanelReset.gameObject.SetActive(true);

        PlayerPrefs.SetString("forwardKey", "W");
        PlayerPrefs.SetString("backwardKey", "S");
        PlayerPrefs.SetString("leftKey", "A");
        PlayerPrefs.SetString("rightKey", "D");
        PlayerPrefs.SetString("jumpKey", "Space");
    }
}