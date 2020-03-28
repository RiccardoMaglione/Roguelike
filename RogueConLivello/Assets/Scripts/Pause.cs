using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject panel;
    bool isPaused = false;
    bool state;
    void PauseMenu()
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu(); //mette il pausa
            SwitchShowHide(); //fa vedere il menù di pausa
        }
    }
}
