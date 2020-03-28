using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gif : MonoBehaviour
{
    public GameObject[] myObjects;
    private void Start()
    {
            StartCoroutine(fuoco());
    }
    
    IEnumerator fuoco()
    {
            while (true)
            {
                myObjects[0].SetActive(true);
                yield return new WaitForSeconds((float)0.1);
                myObjects[0].SetActive(false);
                myObjects[1].SetActive(true);
                yield return new WaitForSeconds((float)0.1);
                myObjects[1].SetActive(false);
                myObjects[2].SetActive(true);
                yield return new WaitForSeconds((float)0.1);
                myObjects[2].SetActive(false);
                myObjects[3].SetActive(true);
                yield return new WaitForSeconds((float)0.1);
                myObjects[3].SetActive(false);
            }
    }
}




    
     

