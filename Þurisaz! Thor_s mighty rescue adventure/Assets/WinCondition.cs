using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public GameObject Popup;
    public GameObject Advertise;
    public int TimeShow = 5;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Popup.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (EnemyManager.CountEnemyWin == 15)
                {
                    Debug.Log("Count enemy win scene"+EnemyManager.CountEnemyWin);
                    Popup.SetActive(false);
                    SceneManager.LoadScene("WinScene");
                }
                else
                {
                    Popup.SetActive(false);
                    Advertise.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Popup.SetActive(false);
            Advertise.SetActive(false);
        }
    }
}
