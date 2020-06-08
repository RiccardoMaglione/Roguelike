using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneDraugr : MonoBehaviour
{

    //manca il calare l'ascia e rimetterla in posizione di partenza e quando calata fa danno cioè attiva tag, e manca il bloccare il movimento del player

    public GameObject Axe;
    public GameObject PlayerContainer;

    public float yAngleTarget = 360f;      //Specifica quanti di quanti gradi deve girare sull'asse y
    public float secondsToLerp = 5f;     //Specifica in quanti secondi deve compiera la rotazione
    public float Delay = 2f;        //Specifica il tempo tra una rotazione e l'altra
    public float CooldownFlash = 0.5f;
    float t = 0;                    //Setto la variabile utilizzata come timer per la rotazione clockwise a 0
    float f = 0;                    //Setto la variabile utilizzata come timer per la rotazione counterclockwise a 0

    bool isFirstActivate = true;
    bool isStartAttack = true;

    bool isPress = false;

    Quaternion initialRotation;
    public Quaternion rotPlayer;
    // Start is called before the first frame update
    void Start()
    {
        PlayerContainer = GameObject.FindGameObjectWithTag("Player");
        initialRotation = Axe.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && isPress == false)
        {
            if (PlayerManager.Look == 1) //guarda avanti e gira z
            {
                rotPlayer = Quaternion.LookRotation(Vector3.left, Vector3.up); //guarda w
            }
            if (PlayerManager.Look == 2) //guarda indietro e gira z
            {
                rotPlayer = Quaternion.LookRotation(Vector3.right, Vector3.up); //guarda s
            }
            
            if (PlayerManager.Look == 3) //guarda destra e gira z
            {
                rotPlayer = transform.rotation = Quaternion.LookRotation(Vector3.back, Vector3.up); //guarda a
            }
            if (PlayerManager.Look == 4) //guarda sinistra e gira z
            {
                rotPlayer = Quaternion.LookRotation(Vector3.forward, Vector3.up); //guarda d
            }
            isPress = true;
        }
        if(isPress == true)
        {
            DraugrAttack();
        }
    }


    public void DraugrAttack()
    {





            #region Only Once
            if (isStartAttack == true)
            {
                isStartAttack = false;
                //FindObjectOfType<AudioManager>().Play("ValravnSound", sfx);
                
                //if (PlayerManager.Look == 1) //guarda avanti e gira z
                //{
                //    Axe.transform.rotation = Quaternion.Euler(Axe.transform.rotation.x, Axe.transform.rotation.y, 45);
                //}
                //if (PlayerManager.Look == 2) //guarda indietro e gira z
                //{
                //    Axe.transform.rotation = Quaternion.Euler(Axe.transform.rotation.x, Axe.transform.rotation.y, -45);
                //}
                //
                //if (PlayerManager.Look == 3) //guarda destra e gira z
                //{
                //    Axe.transform.rotation = Quaternion.Euler(45, Axe.transform.rotation.y, Axe.transform.rotation.z);
                //}
                //if (PlayerManager.Look == 4) //guarda sinistra e gira z
                //{
                //    Axe.transform.rotation = Quaternion.Euler(-45, Axe.transform.rotation.y, Axe.transform.rotation.z);
                //}
        
            }
            #endregion
            #region Axe Rotate
        
            //devo vedere in che direzione guarda
            
            t += Time.deltaTime / secondsToLerp;



            //Timer per Clockwise
            PlayerContainer.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(rotPlayer.eulerAngles.y, rotPlayer.eulerAngles.y + yAngleTarget, t), 0);        //Clockwise
            if (t >= Delay)                                                                                     //Se t è maggiore o uguale del delay
            {
                f += Time.deltaTime / secondsToLerp;                                                     //Timer per Counterclockwise
                PlayerContainer.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(rotPlayer.eulerAngles.y, rotPlayer.eulerAngles.y - yAngleTarget, f), 0);   //Counterclockwise
                if (f >= Delay)                                                                                    //Se f è maggiore o uguale del delay
                {
                    f = 0;                                                                                      //Resetto f per far ricominciare il ciclo
                    t = 0;                                                                                      //Resetto t per far ricominciare il ciclo
                    isStartAttack = true;
                    isPress = false;
                    //Axe.transform.rotation = initialRotation;
                }
            }
            #endregion
    }
}
