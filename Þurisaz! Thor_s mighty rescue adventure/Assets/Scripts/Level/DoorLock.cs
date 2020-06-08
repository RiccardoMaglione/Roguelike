using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorLock : MonoBehaviour
{
    public GameObject EntranceDoor;             //Inizializzo l'oggetto entrance door
    public GameObject ExitDoor;                 //Inizializzo l'oggetto exit door
    public GameObject AnotherDoor;
    public GameObject EntranceCollider;         //Inizializzo l'oggetto entrance collider
    public GameObject ExitCollider;             //Inizializzo l'oggetto exit collider
    public GameObject ColliderAnother;
    public GameObject PrecedentColliderA;       //Inizializzo l'oggetto precedent collider a
    public GameObject PrecedentColliderD;       //Inizializzo l'oggetto precendent collider d
    public GameObject PrecedentColliderAnother;

    bool isFirst = true;                        //Inizializzo la variabile booleana isFirst a vero

    private void Start()
    {
        EntranceDoor.SetActive(false);          //Setto a falso l'oggetto, disattivandolo
        EntranceCollider.SetActive(false);      //Setto a falso l'oggetto, disattivandolo
        PrecedentColliderA.SetActive(true);     //Setto a vero l'oggetto, disattivandolo
        
        ExitCollider.SetActive(false);          //Setto a falso l'oggetto, disattivandolo
        ExitDoor.SetActive(false);              //Setto a falso l'oggetto, disattivandolo
        PrecedentColliderD.SetActive(true);     //Setto a vero l'oggetto, disattivandolo
        
        AnotherDoor.SetActive(false);
        ColliderAnother.SetActive(false);
        PrecedentColliderAnother.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isFirst == true)        //Se l'altro oggetto ha il tag Player e isFirst è vero
        {
            isFirst = false;                                            //Setto isFirst a falso
            EntranceDoor.SetActive(true);                               //Setto a vero l'oggetto, attivandolo
            EntranceCollider.SetActive(true);                           //Setto a vero l'oggetto, attivandolo
            PrecedentColliderA.SetActive(false);                        //Setto a falso l'oggetto, disattivandolo
            
            ExitDoor.SetActive(true);                                   //Setto a vero l'oggetto, attivandolo
            ExitCollider.SetActive(true);                               //Setto a vero l'oggetto, attivandolo
            PrecedentColliderD.SetActive(false);                        //Setto a falso l'oggetto, disattivandolo

            AnotherDoor.SetActive(true);
            ColliderAnother.SetActive(true);
            PrecedentColliderAnother.SetActive(false);
        }
    }
}
