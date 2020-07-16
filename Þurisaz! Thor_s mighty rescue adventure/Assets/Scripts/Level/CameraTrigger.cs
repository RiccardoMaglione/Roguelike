using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraTrigger : MonoBehaviour
{
    public GameObject previousCamera;       //Inizializzo l'oggetto previous camera
    public GameObject nextCamera;           //Inizializzo l'oggetto next camera
    public GameObject fog;                  //Inizializzo l'oggetto fog

    public GameObject HeadThorPrevious;
    public GameObject HeadThorNext;

    public static GameObject TempHead;

    public GameObject CameraMinimap;

    private void Start()
    {
        fog.SetActive(true);                //Attivo la fog
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")    //Se l'altro oggetto ha il tag Player
        {
            previousCamera.SetActive(false);    //Setto l'oggetto falso
            nextCamera.SetActive(true);         //Setto l'oggetto vero
            HeadThorPrevious.SetActive(false);
            HeadThorNext.SetActive(true);
            CameraMinimap.transform.position = new Vector3(HeadThorNext.transform.position.x, CameraMinimap.transform.position.y, HeadThorNext.transform.position.z);
            TempHead = HeadThorNext;
            fog.SetActive(false);               //Setto l'oggetto falso
            if(this.name == "22Trigger")
            {
                ProvaLoki.isActivate = true;
                ProvaLoki.Is8 = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")    //Se l'altro oggetto ha il tag Player
        //{
        //    previousCamera.SetActive(false);    //Setto l'oggetto falso
        //    nextCamera.SetActive(true);         //Setto l'oggetto vero
        //    HeadThorPrevious.SetActive(false);
        //    HeadThorNext.SetActive(true);
        //    CameraMinimap.transform.position = new Vector3(HeadThorNext.transform.position.x, CameraMinimap.transform.position.y, HeadThorNext.transform.position.z);
        //    TempHead = HeadThorNext;
        //    fog.SetActive(false);               //Setto l'oggetto falso
        //    if (this.name == "22Trigger")
        //    {
        //        ProvaLoki.isActivate = true;
        //        ProvaLoki.Is8 = true;
        //    }
        //}
        if (this.gameObject.name == "Room1CameraTrigger")
        {
            if (other.gameObject.tag == "Player")    //Se l'altro oggetto ha il tag Player
            {
                previousCamera.SetActive(false);    //Setto l'oggetto falso
                nextCamera.SetActive(true);         //Setto l'oggetto vero
                HeadThorNext.SetActive(true);
                CameraMinimap.transform.position = new Vector3(HeadThorNext.transform.position.x, CameraMinimap.transform.position.y, HeadThorNext.transform.position.z);
            }
        }
    }
}