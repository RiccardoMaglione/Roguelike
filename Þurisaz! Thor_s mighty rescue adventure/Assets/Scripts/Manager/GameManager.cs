using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    #region Variables Graphics
    public int ValueGraphicsQuality;    //Valore relativo alla quality
    #endregion
    #region Variables Scene

    bool isPaused = false;              //Booleano che indica se la pausa è attiva o no
    public GameObject panel;            //Pannello relativo alla pausa
    bool state;                         //Booleano che indica se il pannello della pausa è attivo o no
    public GameObject loadingScreen;    //Raw image per il loading screen tra una scena e l'altra
    public Slider slider;               //Slider utilizzato come loading bar
    public Text progressText;           //Valore percentuale per la loading bar

    #endregion
    #region Variables Fog Minimap

    public GameObject FogLaterale1;     //Oggetti per la minimappa a scoperta
    public GameObject FogLaterale2;     //Oggetti per la minimappa a scoperta
    public GameObject FogLaterale3;     //Oggetti per la minimappa a scoperta
    public GameObject FogLaterale4;     //Oggetti per la minimappa a scoperta

    #endregion

    float differentAudio;

    private void Awake()
    {
        differentAudio = PlayerPrefs.GetFloat("MusicVolume");
    }

    #region Start Zone
    private void Start()
    {
        FogLaterale1.SetActive(true);   //Attiva la minimappa coperta
        FogLaterale2.SetActive(true);   //Attiva la minimappa coperta
        FogLaterale3.SetActive(true);   //Attiva la minimappa coperta
        FogLaterale4.SetActive(true);   //Attiva la minimappa coperta
        Scene CurrentScene = SceneManager.GetActiveScene();                     //Prendo la scena corrente
        if (CurrentScene.name == "FirstLevel")
        {
            FindObjectOfType<AudioManager>().Stop("MusicMenu");
            FindObjectOfType<AudioManager>().Play("FirstLevelOST", differentAudio);
        }
    }
    #endregion
    #region Update Zone
    void Update()
    {
        ValueGraphicsQuality = PlayerPrefs.GetInt("GraphicQuality");                                    //Setta la graphics quality
        StartToMain();                                                                                  //Richiama il metodo StartToMain nello starting screen
        if (Input.GetKeyDown(ControlsManager.CM.pause) || Input.GetKeyDown(KeyCode.JoystickButton7))    //Se schiaccio di default Esc o il button7 del gamepad, attivo o disattivo la pausa
        {
            Pause();                                                                                    //Mette il gioco in pausa
            SwitchShowHide();                                                                           //Fa vedere il menù di pausa tramite il pannello
        }
    }

    #endregion

    #region Scene

    #region StartingScreen
    public void StartToMain()
    {
        Scene CurrentScene = SceneManager.GetActiveScene();                     //Prendo la scena corrente
        if (CurrentScene.name == "StartingScreen" && Input.anyKeyDown)          //Se la scena corrente è Starting Screen e premo qualsiasi pulsante
        {
            SceneManager.LoadScene("MainMenu");                                 //Cambio scena in Main Menu
        }
    }
    #endregion

    #region MainMenu
    public void GoToMainMenu()
    {
        FindObjectOfType<AudioManager>().Stop("GameOverSound");
        FindObjectOfType<AudioManager>().Stop("FirstLevelOST");
        FindObjectOfType<AudioManager>().Play("MusicMenu", differentAudio);
        SceneManager.LoadScene("MainMenu");                 //Cambio Scena in Main Menu
        Time.timeScale = 1;                                 //Faccio ripartire il tempo se era in pausa
        WallTrigger.WallW = 1;                              //Setto il movimento dovuto ai muri a 1, quindi non viene bloccato, in direzione W
        WallTrigger.WallD = 1;                              //Setto il movimento dovuto ai muri a 1, quindi non viene bloccato, in direzione D
        WallTrigger.WallA = 1;                              //Setto il movimento dovuto ai muri a 1, quindi non viene bloccato, in direzione A
        WallTrigger.WallS = 1;                              //Setto il movimento dovuto ai muri a 1, quindi non viene bloccato, in direzione S
        Tutorial.open = false;

        #region Reset Inventory
        InventorySystem.i = 0;
        InventorySystem.j = 0;
        InventorySystem.isFirsPresentRuneGammur = false;
        //InventorySystem.isFirsPresentRuneProva = false;
        InventorySystem.isFirsPresentRuneValvran = false;
        InventorySystem.isFirsPresentRuneWow = false;

        InventorySystem.isFirsPresentRuneBlue = false;
        InventorySystem.isFirsPresentRuneGreen = false;
        InventorySystem.isFirsPresentRuneOrange = false;
        InventorySystem.isFirsPresentRuneYellow = false;
        InventorySystem.isFirsPresentRuneEye = false;
        InventorySystem.isFirsPresentRuneDarkElf = false;
        InventorySystem.isFirsPresentRuneDraugr = false;

        InventorySystem.tempIImageValvran = 0;
        InventorySystem.tempIImageWow = 0;
        InventorySystem.tempIImageBlue = 0;
        InventorySystem.tempIImageGreen = 0;
        InventorySystem.tempIImageOrange = 0;
        InventorySystem.tempIImageYellow = 0;
        InventorySystem.tempIImageEye = 0;
        InventorySystem.tempIImageDarkElf = 0;
        InventorySystem.tempIImageDraugr = 0;

        InventorySystem.tempIValvran = 0;
        InventorySystem.tempIWow = 0;
        InventorySystem.tempIBlue = 0;
        InventorySystem.tempIGreen = 0;
        InventorySystem.tempIOrange = 0;
        InventorySystem.tempIYellow = 0;
        InventorySystem.tempIEye = 0;
        InventorySystem.tempIDarkElf = 0;
        InventorySystem.tempIDraugr = 0;

        RuneToPlayer.isTimeToWow = false;
        RuneToPlayer.isTimeToValvran = false;
        RuneToPlayer.isTimeToBlue = false;
        RuneToPlayer.isTimeToGreen = false;
        RuneToPlayer.isTimeToOrange = false;
        RuneToPlayer.isTimeToYellow = false;
        RuneToPlayer.isTimeToEye = false;
        RuneToPlayer.isTimeToDarkElf = false;
        RuneToPlayer.isTimeToDraugr = false;

        Ammo.AmmoW = 0;
        Ammo.AmmoV = 0;
        Ammo.AmmoBlue = 0;
        Ammo.AmmoGreen = 0;
        Ammo.AmmoRed = 0;
        Ammo.AmmoYellow = 0;
        Ammo.AmmoEye = 0;
        Ammo.AmmoDarkElf = 0;
        Ammo.AmmoDraugr = 0;

        RuneToPlayer.NumberRuneEnemyCatch = 0;
        #endregion
    }
    public void GoToLoading()
    {
        SceneManager.LoadScene("LoadLevel");                //Cambio Scena in Load Level
        Time.timeScale = 1;                                 //Faccio ripartire il tempo se era in pausa
    }
    public void GoToPlay()
    {
        SceneManager.LoadScene("FirstLevel");               //Cambio Scena in First Level
        Time.timeScale = 1;                                 //Faccio ripartire il tempo se era in pausa
    }
    public void GoToMonsterpedia()
    {
        SceneManager.LoadScene("MonsterpediaScene");        //Cambio Scena in Monsterpedia Scene
    }
    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingMenu");              //Cambio Scena in Setting Menu
        Time.timeScale = 1;                                 //Faccio ripartire il tempo se era in pausa
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditsScene");             //Cambio Scena in CreditsScene
    }
    public static void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");                 //Cambio Scena in Game Over
    }
    public void GoToBackMenu()
    {
        SceneManager.LoadScene("MainMenu");                 //Cambio scena in Main Menu
        Time.timeScale = 1;                                 //Faccio ripartire il tempo se era in pausa
    }
    public void GoToExit()
    {
        Application.Quit();                                 //Esco dal gioco
    }
    public static void GoToThirdLevel()
    {
        SceneManager.LoadScene("ThirdLevel");               //Cambio scena in Third Level
    }
    public void GoToThirdLevel2()
    {
        SceneManager.LoadScene("ThirdLevel");               //Cambio scena in Third Level
    }
    public void GoToFirstLevelV2()
    {
        SceneManager.LoadScene("FirstLevelV2");               //Cambio scena in First Level V2
        Time.timeScale = 1;
    }
    #endregion

    #region Settings
    public void GoToControl()
    {
        SceneManager.LoadScene("ControlMenu");              //Cambio scena in Control Menu
    }
    public void GoToGraphics()
    {
        SceneManager.LoadScene("GraphicsMenu");             //Cambio scena in Graphics Menu
    }
    public void GoToAudio()
    {
        SceneManager.LoadScene("AudioMenu");                //Cambio scena in Audio Menu
    }
    public void GoToBackSetting()                                                      
    {
        SceneManager.LoadScene("SettingMenu");              //Cambio scena in Third Level
        Time.timeScale = 1;                                 //Faccio ripartire il tempo se era in pausa
    }
    #endregion

    #region PauseMenu
    void Pause()
    {
        if (isPaused == true)                       //Se è in pausa
        {
            Time.timeScale = 1;                     //Faccio ripartire il tempo
            isPaused = false;                       //Setto la variabile booleana della pausa a falso
        }
        else
        {
            Time.timeScale = 0;                     //Stoppo il tempo
            isPaused = true;                        //Setto la variabile booleana della pausa a vero
        }
    }
    public void SwitchShowHide()
    {
        state = !state;                             //Variabile che indica se il pannello si vede o no e cambia stato
        panel.gameObject.SetActive(state);          //Aggiorna lo stato del pannello
    }
    #endregion

    #region Load Level Asynchronously
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));                         //Fa partire una coroutine che carica in modo asyncrono una determinata scena
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);     //Fa partire l'operazione asincrona
        loadingScreen.SetActive(true);                                          //Attiva il loading screen
        while (!operation.isDone)                                               //Mentre l'operazione non è finita
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);          //Calcola il progresso della barra e blocca il valore tra 0 e 1
            slider.value = progress;                                            //Sincronizza il valore dello slider con il valore numerico del testo
            progressText.text = progress * 100 + "%";                           //Trasforma il valore in percentuale e aggiorna sullo schermo
            yield return null;
        }
    }
    #endregion
    
    #endregion
}