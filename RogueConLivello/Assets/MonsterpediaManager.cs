using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterpediaManager : MonoBehaviour
{
    public GameObject ButtonWowPedia;
    public GameObject ButtonValravnPedia;
    public GameObject ButtonGammurPedia;

    private void Start()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
    }

    public void WillOWispPedia()
    {
        ButtonWowPedia.SetActive(true);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(false);
    }
    public void ValravnPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(true);
        ButtonGammurPedia.SetActive(false);

    }
    public void GammurPedia()
    {
        ButtonWowPedia.SetActive(false);
        ButtonValravnPedia.SetActive(false);
        ButtonGammurPedia.SetActive(true);
    }
}
