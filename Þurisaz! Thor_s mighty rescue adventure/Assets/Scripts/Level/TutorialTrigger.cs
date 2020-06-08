using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    bool isFirstTime = true;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player" && isFirstTime == true)
        {
            Tutorial.open = true;
            isFirstTime = false;
        }
    }
}