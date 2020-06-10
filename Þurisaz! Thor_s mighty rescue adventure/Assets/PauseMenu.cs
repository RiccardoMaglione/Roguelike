using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuPanel;
    public GameObject SettingsMenu;
    public GameObject ControlMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void SettingsPause()
    {
        PauseMenuPanel.SetActive(false);
        SettingsMenu.SetActive(true);
    }
    public void ControlsPause()
    {
        PauseMenuPanel.SetActive(false);
        ControlMenu.SetActive(true);
    }
    public void ContainerPause()
    {
        SettingsMenu.SetActive(false);
        ControlMenu.SetActive(false);
        PauseMenuPanel.SetActive(true);
    }


}
