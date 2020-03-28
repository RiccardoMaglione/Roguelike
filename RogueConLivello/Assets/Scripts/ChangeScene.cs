using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    bool isPaused = false;
    public GameObject panel;
    bool state;

    #region MainMenu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToPlay()
    {
        SceneManager.LoadScene("FirstLevel");
    }
    /*public void GoToMonsterpedia()
    {
        SceneManager.LoadScene("Monsterpedia");
    }*/
    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingMenu");
    }
    /*public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }*/
    public void GoToBackMenu()                                                      //ripetere?
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void GoToExit()
    {
        Application.Quit();
    }
    #endregion

    #region Settings
    public void GoToControl()
    {
        SceneManager.LoadScene("ControlMenu");
    }
    public void GoToGraphics()
    {
        SceneManager.LoadScene("GraphicsMenu");
    }
    public void GoToAudio()
    {
        SceneManager.LoadScene("AudioMenu");
    }
    public void GoToBackSetting()                                                      //ripetere?
    {
        SceneManager.LoadScene("SettingMenu");
        Time.timeScale = 1;
    }
    #endregion

    #region PauseMenu
    void Pause()
    {
        if (isPaused == true) //se è in pausa
        {
            Time.timeScale = 1; //riprende il tempo normalizzandolo
            isPaused = false; //setta la variabile booleana della pausa a falso
        }
        else
        {
            Time.timeScale = 0; //stoppa il tempo
            isPaused = true; //setta la variabile booleana della pausa a vero
        }
    }
    public void SwitchShowHide()
    {
        state = !state; //variabile che indica se il pannello si vede o no e cambia stato
        panel.gameObject.SetActive(state); //aggiorna lo stato del pannello
    }
    #endregion

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(); //mette il pausa
            SwitchShowHide(); //fa vedere il menù di pausa
        }
    }
}