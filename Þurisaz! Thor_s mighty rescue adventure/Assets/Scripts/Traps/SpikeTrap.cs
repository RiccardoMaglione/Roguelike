using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour

{
    public Transform SpikePos;
    public GameObject SpikeNormal;
    public GameObject SpikeBlood;
    public GameObject SpikeBaseBlood;

    public float upSpeed = 30;
    public float downSpeed = 1;

    private bool open = false;
    static public bool isRune = true;

    public float sfx;

    private void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");            //Setto l'audio delle spike come sfx
    }

    private void Start()
    {
        SpikeBaseBlood.SetActive(false);
        SpikeBlood.SetActive(false);
    }

    void Update()
    {
        if (open)
        {
            SpikePos.position = Vector3.Lerp(SpikePos.position, new Vector3(SpikePos.transform.position.x, 0, SpikePos.transform.position.z), Time.deltaTime * upSpeed);
        }
        else
        {
            SpikePos.position = Vector3.Lerp(SpikePos.position, new Vector3(SpikePos.transform.position.x, -1, SpikePos.transform.position.z), Time.deltaTime * downSpeed);
        }
        Collider[] RuneOnTrap = Physics.OverlapSphere(transform.position, 1);
        foreach (Collider other in RuneOnTrap)
        {
            if (other.gameObject.tag == "RuneWow")              //Se l'altro oggetto ha il tag RuneWow
            {
                SpikeDown();                                    //Richiamo la funzione che abbassa le spike
                SpikeNormal.SetActive(true);                    //Attivo le spike normali, cioè senza sangue
                SpikeBlood.SetActive(false);                    //Disattivo le spike con il sangue
                SpikeBaseBlood.SetActive(false);                //Disattivo la base delle spike con il sangue
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")      //Se l'altro oggetto ha il tag Player o il tag Enemy
        {
            FindObjectOfType<AudioManager>().Play("SpikeTrap", sfx);
            SpikeUp();                                          //Richiamo la funzione che alza le spike
            SpikeNormal.SetActive(false);                       //Disattivo le spike normali, cioè senza sangue
            SpikeBlood.SetActive(true);                         //Attivo le spike con il sangue
            SpikeBaseBlood.SetActive(true);                     //Attivo la base delle spike con il sangue
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "RuneWow")                             //Se l'altro oggetto ha il tag RuneWow
        {
            SpikeDown();                                        //Richiamo la funzione che abbassa le spike
            SpikeNormal.SetActive(true);                        //Attivo le spike normali, cioè senza sangue
            SpikeBlood.SetActive(false);                        //Disattivo le spike con il sangue
            SpikeBaseBlood.SetActive(false);                    //Disattivo la base delle spike con il sangue
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")      //Se l'altro oggetto ha il tag Player o il tag Enemy
        {
            SpikeDown();                                        //Richiamo la funzione che abbassa le spike
            SpikeNormal.SetActive(true);                        //Attivo le spike normali, cioè senza sangue
            SpikeBlood.SetActive(false);                        //Disattivo le spike con il sangue
            SpikeBaseBlood.SetActive(false);                    //Disattivo la base delle spike con il sangue
        }
    }


    public void SpikeUp()
    {
        open = true;            //Setto open a vero
    }

    public void SpikeDown()
    {
        open = false;           //Setto open a falso
    }
}