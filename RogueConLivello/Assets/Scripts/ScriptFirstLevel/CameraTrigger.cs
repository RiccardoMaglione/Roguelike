using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraTrigger : MonoBehaviour
{
    public GameObject previousCamera;
    public GameObject nextCamera;

    private void OnTriggerExit(Collider other)
    {
        //if (previousCamera.activeSelf)
        //{
        //    previousCamera.SetActive(false);
        //    nextCamera.SetActive(true);
        //}
        //else if (!previousCamera.activeSelf)
        //{
        //    nextCamera.SetActive(false);
        //    previousCamera.SetActive(true);
        //
        //}

        previousCamera.SetActive(false);
        nextCamera.SetActive(true);
    }
}