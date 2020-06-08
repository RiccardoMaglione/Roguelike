using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.GoToThirdLevel();
        }
    }

    public void Cambia()
    {
        GameManager.GoToThirdLevel();
    }
}
