using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RuneValravn : MonoBehaviour
{
    public GameObject PeckReference;        //Inizializzo la referenza alla beccata del valravn
    public GameObject[] player;             //Inizializzo l'array per il player
    bool SpellReady = true;                 //Setto la variabile booleana speel ready a vero

    public GameObject shadow;               //Inizializzo l'oggetto che farà da ombra all'attacco






    public GameObject[] see;
    public Vector3 go;
    bool move = false;
    float dist;









    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");       //Setto l'oggetto player con l'oggetto che ha il tag Player
    }
    void Update()
    {
        if(InventorySystem.tempIValvran == 0)       //Se la variabile temporanea i è uguale a 0
        {
            if ((Input.GetKeyDown(ControlsManager.CM.runeOne) || Input.GetKeyDown(KeyCode.JoystickButton2)) && SpellReady == true) //Se premo il tasto della runa uno o button 2 del gamepad e speel ready è vero
            {
                Attack(transform.position, 3f);                               //Faccio partire la coroutine
                Ammo.AmmoV--;                                           //Diminuisco di 1 le ammo del valravn
                Ammo.NumAmmoV0.text = Ammo.AmmoV.ToString();            //Aggiorno il testo nella ui
                SpellReady = false;                                     //Setto speel ready a falso
                Ammo.RuneRawImageValvran0.enabled = false;              //Setto a falso la componente raw image della runa nell'ui
                Ammo.RuneRawImageCooldownValvran0.enabled = true;       //Setto a vero la componente raw image della runa cooldown nell'ui
                StartCoroutine(cooldown());                             //Faccio partire la coroutine
                Ammo.RuneRawImageCooldownValvran0.enabled = false;      //Setto a falso la componente raw image della runa cooldown nell'ui
                Ammo.RuneRawImageValvran0.enabled = true;               //Setto a vero la componente raw image della runa nell'ui
            }
        }
        if (InventorySystem.tempIValvran == 1)  //Se la variabile temporanea i è uguale a 1
        {
            if ((Input.GetKeyDown(ControlsManager.CM.runeTwo) || Input.GetKeyDown(KeyCode.JoystickButton1)) && SpellReady == true)  //Se premo il tasto della runa due o button 1 del gamepad e speel ready è vero
            {
                Attack(transform.position, 3f);                               //Faccio partire la coroutine
                Ammo.AmmoV--;                                           //Diminuisco di 1 le ammo del valravn
                Ammo.NumAmmoV1.text = Ammo.AmmoV.ToString();            //Aggiorno il testo nella ui
                SpellReady = false;                                     //Setto speel ready a falso
                Ammo.RuneRawImageValvran1.enabled = false;              //Setto a falso la componente raw image della runa nell'ui
                Ammo.RuneRawImageCooldownValvran1.enabled = true;       //Setto a vero la componente raw image della runa cooldown nell'ui
                StartCoroutine(cooldown());                             //Faccio partire la coroutine
                Ammo.RuneRawImageCooldownValvran1.enabled = false;      //Setto a falso la componente raw image della runa cooldown nell'ui
                Ammo.RuneRawImageValvran1.enabled = true;               //Setto a vero la componente raw image della runa nell'ui
            }
        }
    }

    //IEnumerator Attack()
    //{
    //    yield return new WaitForSeconds((float)0.1f);
    //    GameObject newShot1 = Instantiate(PeckReference, player[0].transform.position, player[0].transform.rotation * Quaternion.Euler(0, 45, 0));      //Istanzio l'oggetto peck
    //    GameObject shadow1 = Instantiate(shadow, new Vector3(player[0].transform.localPosition.x, 0.1f, player[0].transform.localPosition.z)/* + (transform.forward * 0.6f)*/, player[0].transform.rotation * Quaternion.Euler(0, 45, 0));      //Istanzio l'ombra del peck
    //    newShot1.tag = "ShotPlayer";        //Assegno il tag ShotPlayer
    //    shadow1.tag = "ShotPlayer";         //Assegno il tag ShotPlayer
    //    shadow1.transform.parent = newShot1.transform;      //Setto newShot1 come parent di shadow1
    //
    //    yield return new WaitForSeconds((float)0.2f);
    //    GameObject newShot2 = Instantiate(PeckReference, player[0].transform.position, player[0].transform.rotation);//Istanzio l'oggetto peck
    //    GameObject shadow2 = Instantiate(shadow, new Vector3(player[0].transform.localPosition.x, 0.1f, player[0].transform.localPosition.z)/* + (transform.forward * 0.6f)*/, player[0].transform.rotation * Quaternion.Euler(0, 0, 0));//Istanzio l'ombra del peck
    //    newShot2.tag = "ShotPlayer";        //Assegno il tag ShotPlayer
    //    shadow2.tag = "ShotPlayer";         //Assegno il tag ShotPlayer
    //    shadow2.transform.parent = newShot2.transform;//Setto newShot2 come parent di shadow2
    //
    //    yield return new WaitForSeconds((float)0.3f);
    //    GameObject newShot3 = Instantiate(PeckReference, player[0].transform.position, player[0].transform.rotation * Quaternion.Euler(0, -45, 0));//Istanzio l'oggetto peck
    //    GameObject shadow3 = Instantiate(shadow, new Vector3(player[0].transform.localPosition.x, 0.1f, player[0].transform.localPosition.z)/* + (transform.forward * 0.6f)*/, player[0].transform.rotation * Quaternion.Euler(0, -45, 0));//Istanzio l'ombra del peck
    //    newShot3.tag = "ShotPlayer";//Assegno il tag ShotPlayer
    //    shadow3.tag = "ShotPlayer";//Assegno il tag ShotPlayer
    //    shadow3.transform.parent = newShot3.transform;//Setto newShot3 come parent di shadow3
    //
    //
    //
    //    Destroy(newShot1, 0.2f);        //Distruggo l'oggetto dopo 0.2f
    //    Destroy(newShot2, 0.4f);        //Distruggo l'oggetto dopo 0.4f
    //    Destroy(newShot3, 0.6f);        //Distruggo l'oggetto dopo 0.6f
    //}


    #region Pattern
    void Attack(Vector3 center, float radius)                                                                  //metodo dell'attacco del valravn
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);                                       //il nemico spara il tornado
        foreach (Collider detectedCollider in hitColliders)
        {
            if ((detectedCollider.tag == "Enemy" || detectedCollider.tag == "Boss") && detectedCollider.gameObject.GetComponent<EnemyManager>().Move == true)                                                              //controlla se dentero all'area del tornado c'è il giocatore
            {
                if(detectedCollider.tag == "Enemy")
                {
                    dist = Vector3.Distance(new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z), new Vector3((int)detectedCollider.transform.position.x, detectedCollider.transform.position.y, (int)detectedCollider.transform.position.z));              //calcola la distanza del giocatore dal valravn                                              
                    go = new Vector3((int)detectedCollider.transform.position.x, detectedCollider.transform.position.y, (int)detectedCollider.transform.position.z) + transform.forward * (4- dist);
                    detectedCollider.transform.position = Vector3.MoveTowards(detectedCollider.transform.position, new Vector3((int)go.x, go.y, (int)go.z), 3);
                }
                detectedCollider.gameObject.GetComponent<EnemyManager>().ColpitoDalVento = true;
            }
        }
    }
    #endregion


    public IEnumerator cooldown()
    {
        yield return new WaitForSeconds(0.70f);     //Aspetto 0.70f secondi
        SpellReady = true;                          //Setto spell ready uguale a vero
    }
}