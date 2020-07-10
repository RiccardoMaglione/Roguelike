using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternValvran : MonoBehaviour
{
    #region Variables
    [Header("Reference for Valravn")]
    public GameObject PeckReference;
    public GameObject ValvranContainer;

    [Header("Reference for Material Base")]
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsBase;

    [Header("General Reference")]
    //public GameObject shadow;               //Inizializzo l'ombra della beccata
    public Collider[] hitColliders;
    public GameObject[] Player;
    public float CooldownAttack = 6f;
    public float CooldownFlash = 0.5f;

    Transform target;
    
    bool isFirstActivate = true;            //Inizializzo la variabile che indica se il primo valravn è attivo
    bool isSecondActivate = true;           //Inizializzo la variabile che indica se il secondo valravn è attivo
    bool isThirdActivate = true;            //Inizializzo la variabile che indica se il terzo valravn è attivo
    bool isSixNewActivate = true;



    float sfx;


    public LayerMask PlayerlayerMask;

    public Transform player;
    public GameObject[] see;
    public Vector3 go;
    bool move = false;
    float dist;


    public GameObject AnimationSheet;
    public Animator anim;
    #endregion
    void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");//Setto l'audio del Valravn come sfx
    }
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;//Setto come target l'oggetto che ha come tag Player
        see = GameObject.FindGameObjectsWithTag("Player");
        AnimationSheet.SetActive(false);
    }
    private void Update()
    {

        RaycastHit hit;
        #region Axes X and Z
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 50, PlayerlayerMask))
        {
            Debug.DrawRay(transform.position, Vector3.forward * 50, Color.green);
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Giratiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
        if (Physics.Raycast(transform.position, -Vector3.forward, out hit, 50, PlayerlayerMask))
        {
            Debug.DrawRay(transform.position, -Vector3.forward * 50, Color.yellow);
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Giratiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
                    transform.rotation = new Quaternion(0, 180, 0, 0);
                }
            }
        }
        if (Physics.Raycast(transform.position, -Vector3.right, out hit, 50, PlayerlayerMask))
        {
            Debug.DrawRay(transform.position, -Vector3.right * 50, Color.blue);
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Giratiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
                    this.transform.rotation = new Quaternion(0, 90, 0, -90);
                }
            }
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 50, PlayerlayerMask))
        {
            Debug.DrawRay(transform.position, Vector3.right * 50, Color.red);
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Giratiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
                    transform.rotation = new Quaternion(0, -90, 0, -90);
                }
            }
        }
        #endregion
        #region Axes Diagonal
        if (Physics.Raycast(transform.position, Vector3.forward + Vector3.right, out hit, 50, PlayerlayerMask))
        {
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Giratiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
                    transform.rotation = Quaternion.Euler(0, 45, 0);
                }
            }
        }
        if (Physics.Raycast(transform.position, Vector3.forward + -Vector3.right, out hit, 50, PlayerlayerMask))
        {
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Giratiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
                    transform.rotation = Quaternion.Euler(0, 315, 0);
                }
            }
        }
        if (Physics.Raycast(transform.position, -Vector3.forward + -Vector3.right, out hit, 50, PlayerlayerMask))
        {
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Giratiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
                    transform.rotation = Quaternion.Euler(0, 225, 0);
                }
            }
        }
        if (Physics.Raycast(transform.position, -Vector3.forward + Vector3.right, out hit, 50, PlayerlayerMask))
        {
            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("Giratiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
                    transform.rotation = Quaternion.Euler(0, 135, 0);
                }
            }
        }
        #endregion

        #region Enemy Control Room
        if (ActivateEnemy.isRoom3Valravn == true && isFirstActivate == true)            //Se isRoom3Valravn è vero e isFirstActivate è vero
        {
            if (this.name == "ValvranScript1")                                          //Se il nome dell'oggetto, cioè il proprio, è ValvranScript1
            {
                isFirstActivate = false;                                                //Setto isFirstActivate a falso
                this.GetComponent<PatternValvran>().enabled = true;                     //Attivo lo script
                StartCoroutine(TornadoAttack());                                           //Faccio partire la corutine dell'attacco
                ActivateEnemy.isRoom3Valravn = false;                                   //Setto a falso la variabile di entrata per non farlo ciclare
            }
        }
        if (ActivateEnemy.isRoom4Valravn2 == true && isSecondActivate == true)          //Se isRoom4Valravn2 è vero e isSecondActivate è vero
        {
            if (this.name == "ValvranScript2")                                          //Se il nome dell'oggetto, cioè il proprio, è ValvranScript1
            {
                isSecondActivate = false;                                               //Setto isSecondActivate a falso
                this.GetComponent<PatternValvran>().enabled = true;                     //Attivo lo script
                StartCoroutine(TornadoAttack());                                           //Faccio partire la corutine dell'attacco
                ActivateEnemy.isRoom4Valravn2 = false;                                  //Setto a falso la variabile di entrata per non farlo ciclare
            }
        }
        if (ActivateEnemy.isRoom4Valravn3 == true && isThirdActivate == true)           //Se isRoom4Valravn3 è vero e isThirdActivate è vero
        {
            if (this.name == "ValvranScript3")                                          //Se il nome dell'oggetto, cioè il proprio, è ValvranScript1
            {
                isThirdActivate = false;                                                //Setto isThirdActivate a falso
                this.GetComponent<PatternValvran>().enabled = true;                     //Attivo lo script
                StartCoroutine(TornadoAttack());                                           //Faccio partire la corutine dell'attacco
                ActivateEnemy.isRoom4Valravn3 = false;                                  //Setto a falso la variabile di entrata per non farlo ciclare
            }
        }
        if (ActivateEnemy.isRoom6NewValravn1 == true && isSixNewActivate == true)           //Se isRoom4Valravn3 è vero e isThirdActivate è vero
        {
            if (this.name == "ValvranScript4")                                          //Se il nome dell'oggetto, cioè il proprio, è ValvranScript1
            {
                isSixNewActivate = false;                                                //Setto isThirdActivate a falso
                this.GetComponent<PatternValvran>().enabled = true;                     //Attivo lo script
                StartCoroutine(TornadoAttack());                                           //Faccio partire la corutine dell'attacco
                ActivateEnemy.isRoom6NewValravn1 = false;                                  //Setto a falso la variabile di entrata per non farlo ciclare
            }
        }
        #endregion
    }

    #region Pattern
    void Attack(Vector3 center, float radius)                                                                  //metodo dell'attacco del valravn
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);                                      //il nemico spara il tornado
        foreach (Collider detectedCollider in hitColliders)
        {
            if (detectedCollider.tag == "Player")                                                              //controlla se dentero all'area del tornado c'è il giocatore
            {               
                player = detectedCollider.transform;
                dist = Vector3.Distance(new Vector3((int)detectedCollider.transform.position.x, detectedCollider.transform.position.y, (int)detectedCollider.transform.position.z), new Vector3((int)transform.position.x, transform.position.y, (int)transform.position.z));              //calcola la distanza del giocatore dal valravn                                              
                go = new Vector3((int)detectedCollider.transform.position.x, detectedCollider.transform.position.y, (int)detectedCollider.transform.position.z) + transform.forward * (4 - dist);
                PlayerManager.endpos = new Vector3((int)go.x, go.y, (int)go.z);
                target.transform.position = Vector3.MoveTowards(target.transform.position, PlayerManager.endpos, 1);
                PlayerManager.ColpitoPlayer = true;
            }
        }
    }
    #endregion

    #region IEnumerator Attack and Flash
    IEnumerator TornadoAttack()
    {
        while(true)
        {
            FindObjectOfType<AudioManager>().Play("ValravnSound", sfx);
            anim.SetBool("Active", true);
            AnimationSheet.SetActive(true);
            yield return new WaitForSeconds(1);
            Attack(transform.position, 3f);
            AnimationSheet.SetActive(false);
            anim.SetBool("Active", false);
            yield return new WaitForSeconds(CooldownAttack);
            #region Old Attack
            //GameObject newShot1 = Instantiate(PeckReference, ValvranContainer.transform.localPosition + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, 45, 0));
            //GameObject shadow1 = Instantiate(shadow, new Vector3(ValvranContainer.transform.localPosition.x, 0.1f, ValvranContainer.transform.localPosition.z) + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, 45, 0));
            //shadow1.transform.parent = newShot1.transform;
            //yield return new WaitForSeconds(0.2f);
            //GameObject newShot2 = Instantiate(PeckReference, ValvranContainer.transform.localPosition + (transform.forward * 0.6f), transform.rotation);
            //GameObject shadow2 = Instantiate(shadow, new Vector3(ValvranContainer.transform.localPosition.x, 0.1f, ValvranContainer.transform.localPosition.z) + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, 0, 0));
            //shadow2.transform.parent = newShot2.transform;
            //yield return new WaitForSeconds(0.2f);
            //GameObject newShot3 = Instantiate(PeckReference, ValvranContainer.transform.localPosition + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, -45, 0));
            //GameObject shadow3 = Instantiate(shadow, new Vector3(ValvranContainer.transform.localPosition.x, 0.1f, ValvranContainer.transform.localPosition.z) + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, -45, 0));
            //shadow3.transform.parent = newShot3.transform;
            //yield return new WaitForSeconds(0.2f);
            //Destroy(newShot1, 0.15f);
            //Destroy(newShot2, 0.15f);
            //Destroy(newShot3, 0.15f);
            //yield return new WaitForSeconds(1f);
            #endregion
        }
    }

    public IEnumerator Flash()
    {
        GraphicsBase.material = MaterialChange;
        yield return new WaitForSeconds(CooldownFlash);
        GraphicsBase.material = MaterialStandard;
    }
    #endregion









    #region new attack




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

    #endregion
}