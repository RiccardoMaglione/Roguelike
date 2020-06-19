using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject Arrow6;       //Inizializzo l'oggetto arrow 6
    public GameObject Arrow9;       //Inizializzo l'oggetto arrow 9
    public GameObject ArrowOE;       //Inizializzo l'oggetto arrow 6
    public GameObject ArrowEO;       //Inizializzo l'oggetto arrow 9

    public float sfx;

    void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");    //Setto l'audio della freccia come sfx
    }

    void Start()
    {
        if (this.gameObject.name == "Traps6")       //Se il nome dell'oggetto è Traps6
        {
            StartCoroutine(shot6());                //Faccio partire la coroutine
        }
        
        if (this.gameObject.name == "Traps9")       //Se il nome dell'oggetto è Traps6
        {
            StartCoroutine(shot9());                //Faccio partire la coroutine
        }
        if (this.gameObject.name == "Traps6New1")       //Se il nome dell'oggetto è Traps6
        {
            StartCoroutine(shotOvestEst());                //Faccio partire la coroutine
        }
        if (this.gameObject.name == "Traps6New2")       //Se il nome dell'oggetto è Traps6
        {
            StartCoroutine(shotEstOvest());                //Faccio partire la coroutine
        }
    }

    IEnumerator shot6()     // Da W a S
    {
        while (true)                                                                //Mentre è vero
        {
            Quaternion rot = new Quaternion(0, 180, 0, 0);                          //Definisco la rotazione
            GameObject stalactite = Instantiate(Arrow6, transform.position, rot);   //Istanzio la freccia
            if (ActivateEnemy.isRoom3ArrowSound == true)                            //Se isRoom3ArrowSound è vero
            {
                FindObjectOfType<AudioManager>().Play("ArrowTrap", sfx);            //Faccio partire l'audio della freccia
            }
            yield return new WaitForSeconds(1);                                     //Aspetto 1 secondo
        }
    }

    IEnumerator shot9()     // Da S a W
    {
        while (true)                                                                                        //Mentre è vero
        {
            Quaternion rot = new Quaternion(0, 180, 0, 0);                                                  //Definisco la rotazione
            GameObject stalactite = Instantiate(Arrow9, transform.localPosition, Quaternion.identity);      //Istanzio la freccia
            //if (ActivateEnemy.isRoom4ArrowSound == true)                                                    //Se isRoom3ArrowSound è vero
            if (ActivateEnemy.isRoom3ArrowSound == true)
            {
                FindObjectOfType<AudioManager>().Play("ArrowTrap", sfx);                                    //Faccio partire l'audio della freccia
            }
            yield return new WaitForSeconds(1);                                                             //Aspetto 1 secondo
        }
    }

    IEnumerator shotOvestEst()     // Da W a S
    {
        while (true)                                                                //Mentre è vero
        {
            Quaternion rot = new Quaternion(0, 0, 0, 0);                          //Definisco la rotazione
            GameObject stalactite = Instantiate(ArrowOE, transform.position, rot);   //Istanzio la freccia
            if (ActivateEnemy.isRoom3ArrowSound == true)                            //Se isRoom3ArrowSound è vero
            {
                FindObjectOfType<AudioManager>().Play("ArrowTrap", sfx);            //Faccio partire l'audio della freccia
            }
            yield return new WaitForSeconds(1);                                     //Aspetto 1 secondo
        }
    }
    IEnumerator shotEstOvest()     // Da W a S
    {
        while (true)                                                                //Mentre è vero
        {
            Quaternion rot = new Quaternion(0, 0, 0, 0);                          //Definisco la rotazione
            GameObject stalactite = Instantiate(ArrowEO, transform.position, rot);   //Istanzio la freccia
            if (ActivateEnemy.isRoom3ArrowSound == true)                            //Se isRoom3ArrowSound è vero
            {
                FindObjectOfType<AudioManager>().Play("ArrowTrap", sfx);            //Faccio partire l'audio della freccia
            }
            yield return new WaitForSeconds(1);                                     //Aspetto 1 secondo
        }
    }
}