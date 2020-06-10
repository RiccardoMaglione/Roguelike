using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChasmTrap : MonoBehaviour
{
    public GameObject Player;                       //Inizializzo l'oggetto Player
    public GameObject OneCameraReferences;          //Inizializzo l'oggetto camera della prima stanza
    public GameObject TwoCameraReferences;          //Inizializzo l'oggetto camera della seconda stanza
    public GameObject ThreeCameraReferences;        //Inizializzo l'oggetto camera della terza stanza

    public GameObject SixCameraReferences;          //Inizializzo l'oggetto camera della seconda stanza
    public GameObject SevenCameraReferences;        //Inizializzo l'oggetto camera della terza stanza
    public GameObject EightCameraReferences;        //Inizializzo l'oggetto camera della terza stanza

    public GameObject TrapBreak;                    //Inizializzo l'oggetto della trappola rotta
    public GameObject HalfTrapBreak;                    //Inizializzo l'oggetto della trappola rotta
    public float sfx;
    public bool FirstPass = true;

    Scene CurrentScene;

    public void OnTriggerEnter(Collider other)
    {
        if (CurrentScene.name == "FirstLevel")              //Se la scena corrente è First Level
        {
            if (other.gameObject.tag == "Player")          //Se l'oggetto ha il tag Player
            {
                if (FirstPass == true)
                {
                    Destroy(HalfTrapBreak);
                    FindObjectOfType<AudioManager>().Play("HoleTrap", sfx);
                    FirstPass = false;
                }
                else
                {
                    CameraTrigger.TempHead.SetActive(false);
                    Destroy(TrapBreak);
                    FindObjectOfType<AudioManager>().Play("HoleTrap", sfx);
                    Player.transform.position = new Vector3(-55, 0.5f, 1);
                    //PlayerManager.startPosition = new Vector3(-55, 0.5f, 1);
                    PlayerManager.endpos = new Vector3(-55, 0.5f, 1);

                    if (TwoCameraReferences.activeSelf)                         //Se la camera 2 è attiva
                    {
                        CameraTrigger.TempHead.SetActive(false);
                        TwoCameraReferences.SetActive(false);                   //Disattiva l'oggetto
                        OneCameraReferences.SetActive(true);                    //Attiva l'oggetto
                        //PlayerManager.startPosition = new Vector3(-55, 0.5f, 1);
                        PlayerManager.endpos = new Vector3(-55, 0.5f, 1);       //Setta la posizione finale
                    }
                    else if (ThreeCameraReferences.activeSelf)                  //Se la camera 3 è attiva
                    {
                        CameraTrigger.TempHead.SetActive(false);
                        ThreeCameraReferences.SetActive(false);                 //Disattiva l'oggetto
                        OneCameraReferences.SetActive(true);                    //Attiva l'oggetto
                        //PlayerManager.startPosition = new Vector3(-55, 0.5f, 1);
                        PlayerManager.endpos = new Vector3(-55, 0.5f, 1);       //Setta la posizione finale
                    }
                }
            }
        }
        if (CurrentScene.name == "ThirdLevel")              //Se la scena corrente è First Level
        {
            if (other.gameObject.tag == "Player")          //Se l'oggetto ha il tag Player
            {
                if (FirstPass == true)
                {
                    Destroy(HalfTrapBreak);
                    FindObjectOfType<AudioManager>().Play("HoleTrap", sfx);
                    FirstPass = false;
                }
                else
                {
                    CameraTrigger.TempHead.SetActive(false);
                    Destroy(TrapBreak);
                    FindObjectOfType<AudioManager>().Play("HoleTrap", sfx);
                    Player.transform.position = new Vector3(16, 0.5f, -2);
                    //PlayerManager.startPosition = new Vector3(16, 0.5f, -2);
                    PlayerManager.endpos = new Vector3(16, 0.5f, -2);

                    if (SixCameraReferences.activeSelf)                         //Se la camera 2 è attiva
                    {
                        CameraTrigger.TempHead.SetActive(false);
                        SixCameraReferences.SetActive(false);                   //Disattiva l'oggetto
                        OneCameraReferences.SetActive(true);                    //Attiva l'oggetto
                        //PlayerManager.startPosition = new Vector3(16, 0.5f, -2);
                        PlayerManager.endpos = new Vector3(16, 0.5f, -2);       //Setta la posizione finale
                    }
                    if (SevenCameraReferences.activeSelf)                         //Se la camera 2 è attiva
                    {
                        CameraTrigger.TempHead.SetActive(false);
                        SevenCameraReferences.SetActive(false);                   //Disattiva l'oggetto
                        OneCameraReferences.SetActive(true);                    //Attiva l'oggetto
                        //PlayerManager.startPosition = new Vector3(16, 0.5f, -2);
                        PlayerManager.endpos = new Vector3(16, 0.5f, -2);       //Setta la posizione finale
                    }
                    else if (EightCameraReferences.activeSelf)                  //Se la camera 3 è attiva
                    {
                        CameraTrigger.TempHead.SetActive(false);
                        EightCameraReferences.SetActive(false);                 //Disattiva l'oggetto
                        OneCameraReferences.SetActive(true);                    //Attiva l'oggetto
                        //PlayerManager.startPosition = new Vector3(16, 0.5f, -2);
                        PlayerManager.endpos = new Vector3(16, 0.5f, -2);       //Setta la posizione finale
                    }
                }
            }
        }
    }
    void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");            //Setto l'audio del chasm come sfx
    }
    private void Start()
    {
        CurrentScene = SceneManager.GetActiveScene();
    }
}