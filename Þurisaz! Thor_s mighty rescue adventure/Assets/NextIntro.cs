using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextIntro : MonoBehaviour
{
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    int press = 0;
    bool once;

    public void Next()
    {
        if(once == true)
        {
            press += 1;
            once = false;
        }
        if (press == 0)
        {
            Debug.Log("Schiaccia");
            Image1.SetActive(false);
            Image2.SetActive(true);
            once = true;
        }
        if (press == 1)
        {
            Image2.SetActive(false);
            Image3.SetActive(true);
            once = true;
        }
        if (press == 2)
        {
            Image3.SetActive(false);
            SceneManager.LoadScene("StartingScreen");
        }
    }
}
