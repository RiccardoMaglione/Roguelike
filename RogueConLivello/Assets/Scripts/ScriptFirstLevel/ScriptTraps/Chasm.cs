using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasm : MonoBehaviour
{
    public GameObject Player;
    public GameObject OneCameraReferences;
    public GameObject TwoCameraReferences;
    public GameObject ThreeCameraReferences;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            //yield return new WaitForSeconds(0f);
            Destroy(gameObject);
            Player.transform.position = new Vector3(-55, 0.5f, 1);
            
            if (TwoCameraReferences.activeSelf)
            {
                TwoCameraReferences.SetActive(false);
                OneCameraReferences.SetActive(true);
                MovementInGrid.endpos = new Vector3(-55, 0.5f, 1);
            }
            else if (ThreeCameraReferences.activeSelf)
            {
                ThreeCameraReferences.SetActive(false);
                OneCameraReferences.SetActive(true);
                MovementInGrid.endpos = new Vector3(-55, 0.5f, 1);
            }
        }
    }
}
