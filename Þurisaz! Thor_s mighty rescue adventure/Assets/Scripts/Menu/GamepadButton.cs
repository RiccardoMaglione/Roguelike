using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GamepadButton : MonoBehaviour
{
    public GameObject PlayFirstButton;
    public GameObject MonsterpediaFirstButton;
    public GameObject SettingFirstButton;
    public GameObject CreditsFirstButton;
    public GameObject ExitFirstButton;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(PlayFirstButton);
    }

}
