using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternDraugr : MonoBehaviour
{
    #region Variables
    [Header("Reference for Draugr")]
    public GameObject Axe;
    public GameObject DraugrContainer;

    [Header("Reference for Material Base")]
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsBase;

    [Header("General Reference")]
    public float yAngleTarget = 360f;      //Specifica quanti di quanti gradi deve girare sull'asse y
    public float secondsToLerp = 5f;     //Specifica in quanti secondi deve compiera la rotazione
    public float Delay = 2f;        //Specifica il tempo tra una rotazione e l'altra
    public float CooldownFlash = 0.5f;
    float t = 0;                    //Setto la variabile utilizzata come timer per la rotazione clockwise a 0
    float f = 0;                    //Setto la variabile utilizzata come timer per la rotazione counterclockwise a 0

    bool isFirstActivate = true;
    bool isStartAttack = true;

    float sfx;
    #endregion

    private void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");            //Setto l'audio del cervo verde come sfx
    }
    private void Update()
    {
        DraugrAttack();
        #region Enemy Control Room
        //if (ActivateEnemy.isRoom2 == true && isFirstActivate == true)
        //{
        //    if (this.name == "WillOfWispScript1")
        //    {
        //        isFirstActivate = false;
        //        this.GetComponent<PatternGreenDeer>().enabled = true;
        //        StartCoroutine(WindAttack());
        //        ActivateEnemy.isRoom2 = false;
        //    }
        //}
        #endregion
    }

    #region Pattern
    public void DraugrAttack()
    {
        #region Only Once
        if (isStartAttack == true)
        {
            //Axe.transform.rotation = Quaternion.Euler(0, 0, 90);
            isStartAttack = false;
            StartCoroutine(Flash());
            //FindObjectOfType<AudioManager>().Play("ValravnSound", sfx);
        }
        #endregion
        #region Axe Rotate
        t += Time.deltaTime / secondsToLerp;                                                                //Timer per Clockwise
        DraugrContainer.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(0, yAngleTarget, t), 0);        //Clockwise
        if (t >= Delay)                                                                                     //Se t è maggiore o uguale del delay
        {
            f += Time.deltaTime / secondsToLerp;                                                            //Timer per Counterclockwise
            DraugrContainer.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(0, -yAngleTarget, f), 0);   //Counterclockwise
            if (f >= Delay)                                                                                    //Se f è maggiore o uguale del delay
            {
                f = 0;                                                                                      //Resetto f per far ricominciare il ciclo
                t = 0;                                                                                      //Resetto t per far ricominciare il cicloù
                //Axe.transform.rotation = Quaternion.Euler(0, 0, -90);
                isStartAttack = true;
            }
        }
        #endregion
    }
    #endregion

    #region IEnumerator Flash
    public IEnumerator Flash()
    {
        GraphicsBase.material = MaterialChange;
        yield return new WaitForSeconds(CooldownFlash);
        GraphicsBase.material = MaterialStandard;
    }
    #endregion
}