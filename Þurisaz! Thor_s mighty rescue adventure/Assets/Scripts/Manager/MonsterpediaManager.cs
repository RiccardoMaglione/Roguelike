using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterpediaManager : MonoBehaviour
{
    #region Variables
    #region ButtonPedia
    public GameObject ButtonWowPedia;
    public GameObject ButtonValravnPedia;
    public GameObject ButtonGammurPedia;
    public GameObject ButtonEyePedia;
    public GameObject ButtonDáinnPedia;
    public GameObject ButtonDarkElfPedia;
    
    #endregion
    #region QM
    public GameObject WowQM;
    public GameObject ValravnQM;
    public GameObject GammurQM;
    
    public GameObject OdinQM;
    public GameObject GreenQM;
    public GameObject DarkElfQM;
    
    public GameObject YellowQM;
    public GameObject RedQM;
    public GameObject BlueQM;
    public GameObject GullinburstiQM;
    public GameObject DraugrQM;
    public GameObject LokiQM;
    #endregion
    #region Act
    public GameObject WowAct;
    public GameObject ValravnAct;
    public GameObject GammurAct;
    public GameObject OdinAct;
    public GameObject GreenAct;
    public GameObject DarkElfAct;

    #endregion
    public MonsterpediaManager monsterManager;
    #endregion
    
    private void Start()
    {
        #region Distattivo
        if (EnemyManager.WowFound == 0)
        {
            WowQM.SetActive(true);
            ButtonWowPedia.SetActive(false);
            WowAct.SetActive(false);
        }
        if (EnemyManager.ValravnFound == 0)
        {
            ValravnQM.SetActive(true);
            ButtonValravnPedia.SetActive(false);
            ValravnAct.SetActive(false);
        }
        if (EnemyManager.GammurFound == 0)
        {
            GammurQM.SetActive(true);
            ButtonGammurPedia.SetActive(false);
            GammurAct.SetActive(false);
        }
        if (EnemyManager.OdinEyeFound == 0)
        {
            OdinQM.SetActive(true);
            ButtonEyePedia.SetActive(false);
            OdinAct.SetActive(false);
        }
        if (EnemyManager.GreenFound == 0)
        {
            GreenQM.SetActive(true);
            ButtonDáinnPedia.SetActive(false);
            GreenAct.SetActive(false);
        }
      
        if (EnemyManager.DarkElfFound == 0)
        {
            DarkElfQM.SetActive(true);
            ButtonDarkElfPedia.SetActive(false);
            DarkElfAct.SetActive(false);
        }
        #endregion

        #region Attivo
        if (EnemyManager.WowFound == 1)
        {
            WowQM.SetActive(false);
            ButtonWowPedia.SetActive(false);
            WowAct.SetActive(true);
        }
        if (EnemyManager.ValravnFound == 1)
        {
            ValravnQM.SetActive(false);
            ButtonValravnPedia.SetActive(false);
            ValravnAct.SetActive(true);
        }
        if (EnemyManager.GammurFound == 1)
        {
            GammurQM.SetActive(false);
            ButtonGammurPedia.SetActive(false);
            GammurAct.SetActive(true);
        }
        if (EnemyManager.OdinEyeFound == 1)
        {
            OdinQM.SetActive(false);
            ButtonEyePedia.SetActive(false);
            OdinAct.SetActive(true);
        }
        if (EnemyManager.GreenFound == 1)
        {
            GreenQM.SetActive(false);
            ButtonDáinnPedia.SetActive(false);
            GreenAct.SetActive(true);
        }
        
        if (EnemyManager.DarkElfFound == 1)
        {
            DarkElfQM.SetActive(false);
            ButtonDarkElfPedia.SetActive(false);
            DarkElfAct.SetActive(true);
        }
        #endregion
    }
    public void WillOWispPedia()
    {
        ButtonWowPedia.SetActive(true);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDarkElfPedia.SetActive(false);
    }
    public void ValravnPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(true);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDarkElfPedia.SetActive(false);

    }
    public void GammurPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(true);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDarkElfPedia.SetActive(false);
    }
    public void EyePedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(true);
        ButtonDáinnPedia.SetActive(false);
        ButtonDarkElfPedia.SetActive(false);
    }
    public void DáinnPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(true);
        ButtonDarkElfPedia.SetActive(false);
    }   //verde
    public void DarkElfPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDarkElfPedia.SetActive(true);
    }
}