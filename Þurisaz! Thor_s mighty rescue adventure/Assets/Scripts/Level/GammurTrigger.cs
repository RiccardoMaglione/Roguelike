using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GammurTrigger : MonoBehaviour
{
    static public bool GP = false;
    public bool GT = false;
    public GameObject Intro;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && GT == false)
        {
            StartCoroutine(IntroB());
        }
    }


    IEnumerator IntroB()
    {
        WallTrigger.WallW = 0;
        WallTrigger.WallA = 0;
        WallTrigger.WallS = 0;
        WallTrigger.WallD = 0;
        Intro.SetActive(true);
        yield return new WaitForSeconds(4f);
        Intro.SetActive(false);
        GP = true;
        GT = true;
        WallTrigger.WallW = 1;
        WallTrigger.WallA = 1;
        WallTrigger.WallS = 1;
        WallTrigger.WallD = 1;
    }
}
