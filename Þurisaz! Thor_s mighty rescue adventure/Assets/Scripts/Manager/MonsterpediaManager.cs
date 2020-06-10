using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterpediaManager : MonoBehaviour
{
    public GameObject ButtonWowPedia;
    public GameObject ButtonValravnPedia;
    public GameObject ButtonGammurPedia;

    public GameObject ButtonEyePedia;
    public GameObject ButtonDáinnPedia;
    public GameObject ButtonDvalinnPedia;
    public GameObject ButtonDuneyrrPedia;
    public GameObject ButtonDuraþrórPedia;

    public GameObject ButtonGullinburstiPedia;
    public GameObject ButtonDraugrPedia;

    public GameObject ButtonLokiPedia;

    private void Start()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(false);
    }
    public void WillOWispPedia()
    {
        ButtonWowPedia.SetActive(true);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(false);
    }
    public void ValravnPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(true);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(false);

    }
    public void GammurPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(true);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(false);
    }
    public void EyePedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(true);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(false);
    }
    public void DáinnPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(true);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(false);
    }
    public void DvalinnPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(true);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(false);
    }
    public void DuneyrrPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(true);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(false);
    }
    public void DuraþrórPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(true);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(false);
    }

    public void GullinburstiPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(true);
        ButtonDraugrPedia.SetActive(false);
    }

    public void DraugrPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(true);
    }

    public void LokiPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
        ButtonEyePedia.SetActive(false);
        ButtonDáinnPedia.SetActive(false);
        ButtonDvalinnPedia.SetActive(false);
        ButtonDuneyrrPedia.SetActive(false);
        ButtonDuraþrórPedia.SetActive(false);
        ButtonGullinburstiPedia.SetActive(false);
        ButtonDraugrPedia.SetActive(false);
        ButtonLokiPedia.SetActive(true);
    }
}