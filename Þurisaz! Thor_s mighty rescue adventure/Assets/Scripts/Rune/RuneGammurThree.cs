using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneGammurThree : MonoBehaviour
{
    public GameObject[] Player;                 //Inizializzo Player come array
    public GameObject ChickenMinion;            //Inizializzo il chicken minion
    bool SpellReady = true;                     //Setto la variabile booleana a vero, utilizzata per il cooldown
    RawImage GammurCooldownThree;               //Setto la raw image della runa cooldown di Gammur

    private void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");           //Setto l'oggetto Player con il tag Player
        GammurCooldownThree = GameObject.Find("RuneGammur3RawImageCooldown").GetComponent<RawImage>();  //Setto l'oggetto GammurCooldowThree con la componente raw image dell'oggetto con un determinato nome
        GammurCooldownThree.enabled = false;            //Setto la raw image a falso per disattivare il componente
    }
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button3)) && SpellReady == true)    //Se premo la ferccia su e il button 3 del gamepad e la speel ready è vera
        {
            SpawnMinion();                  //Richiamo la funzione
            SpellReady = false;             //Setto spell ready a falso
            StartCoroutine(cooldown());     //Richiamo la coroutine del cooldown
        }
    }

    void SpawnMinion()
    {
        float radius = 3f;              //Setto il radius a 3
        for (int i = 0; i < 3; i++)     //Per un ciclo di 3 volte
        {
            float angle = i * Mathf.PI * 2f / 3;        //Trovo la misura dell'angolo di un cerchio diviso in tre parti
            Vector3 newPos = new Vector3(Player[0].transform.position.x + Mathf.Cos(angle) * radius, Player[0].transform.position.y, Player[0].transform.position.z + Mathf.Sin(angle) * radius);   //Setto la nuova posizione tramite il player e l'angolo
            GameObject go1 = Instantiate(ChickenMinion, newPos, Quaternion.identity);       //Istanzion l'oggetto
            go1.tag = "EggcrackerPlayer";       //Assegno il tag EggcrackerPlayer
            go1.AddComponent<MinionLookAt>();   //Assegno lo script MinionLookAt all'oggetto
        }
    }
    public IEnumerator cooldown()
    {
        GammurCooldownThree.enabled = true;         //Setto il componente raw image a vero
        yield return new WaitForSeconds(20);        //Aspetto 20 secondi
        SpellReady = true;                          //Setto spell ready a vero
        GammurCooldownThree.enabled = false;        //Setto il componente raw image a falso
    }
}