using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternWoW : MonoBehaviour
{
    #region Variables
    [Header("Reference for Will o Wisp")]
    public GameObject shotReference;
    public GameObject WowContainer;

    [Header("Reference for Material Base")]
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsBase;
    
    [Header("General Reference")]
    public GameObject shadow;
    public float CooldownAttack = 1f;
    public float CooldownFlash = 0.5f;

    Transform target;

    bool isFirstActivate = true;
    bool isSecondActivate = true;
    bool isThirdActivate = true;
    bool isFourActivate = true;
    bool isFour2Activate = true;

    float sfx;

    public LayerMask PlayerlayerMask;
    #endregion

    private void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");            //Setto l'audio del Will o' Wisp come sfx
    }
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;      //Setto come target l'oggetto che ha come tag Player
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
                    transform.rotation = new Quaternion(0, 0, 0, 0);
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
        if (Physics.Raycast(transform.position, Vector3.right , out hit, 50, PlayerlayerMask))
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
        //transform.LookAt(target);

        #region Enemy Control Room
        if (ActivateEnemy.isRoom2 == true && isFirstActivate == true)
        {
            if (this.name == "WillOfWispScript1")
            {
                isFirstActivate = false;
                this.GetComponent<PatternWoW>().enabled = true;
                StartCoroutine(WowAttack());
                ActivateEnemy.isRoom2 = false;
            }
        }
        if (ActivateEnemy.isRoom3Wow == true && isSecondActivate == true)
        {
            if (this.name == "WillOfWispScript2")
            {
                isSecondActivate = false;
                this.GetComponent<PatternWoW>().enabled = true;
                StartCoroutine(WowAttack());
                ActivateEnemy.isRoom3Wow = false;
            }
        }
        if (ActivateEnemy.isRoom5 == true && isThirdActivate == true)
        {
            if (this.name == "WillOfWispScript3")
            {
                isThirdActivate = false;
                this.GetComponent<PatternWoW>().enabled = true;
                StartCoroutine(WowAttack());
                ActivateEnemy.isRoom5 = false;
            }
        }

        if (ActivateEnemy.isroom4Wow4IceLevel == true && isFourActivate == true)
        {
            if (this.name == "WillOfWispScript4")
            {
                isFourActivate = false;
                this.GetComponent<PatternWoW>().enabled = true;
                StartCoroutine(WowAttack());
                ActivateEnemy.isroom4Wow4IceLevel = false;
            }
        }
        if (ActivateEnemy.isroom4Wow5IceLevel == true && isFour2Activate == true)
        {
            if (this.name == "WillOfWispScript5")
            {
                isFour2Activate = false;
                this.GetComponent<PatternWoW>().enabled = true;
                StartCoroutine(WowAttack());
                ActivateEnemy.isroom4Wow5IceLevel = false;
            }
        }
        #endregion
    }

    #region Pattern
    void Attack3Angle()
    {
        StartCoroutine(Flash());
        FindObjectOfType<AudioManager>().Play("WoWAttack", sfx);
        GameObject newShot1 = Instantiate(shotReference, WowContainer.transform.localPosition + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, 45, 0));
        GameObject newShot2 = Instantiate(shotReference, WowContainer.transform.localPosition + (transform.forward * 0.6f), transform.rotation);
        GameObject newShot3 = Instantiate(shotReference, WowContainer.transform.localPosition + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, -45, 0));

        GameObject shadow1 = Instantiate(shadow, new Vector3(WowContainer.transform.localPosition.x, 0.1f, WowContainer.transform.localPosition.z) + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, 45, 0));
        GameObject shadow2 = Instantiate(shadow, new Vector3(WowContainer.transform.localPosition.x, 0.1f, WowContainer.transform.localPosition.z) + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, 0, 0));
        GameObject shadow3 = Instantiate(shadow, new Vector3(WowContainer.transform.localPosition.x, 0.1f, WowContainer.transform.localPosition.z) + (transform.forward * 0.6f), transform.rotation * Quaternion.Euler(0, -45, 0));

        shadow1.transform.parent = newShot1.transform;
        shadow2.transform.parent = newShot2.transform;
        shadow3.transform.parent = newShot3.transform;
    }
    #endregion

    #region IEnumerator Attack and Flash
    IEnumerator WowAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(CooldownAttack);
            Attack3Angle();
        }
    }

    public IEnumerator Flash()
    {
        GraphicsBase.material = MaterialChange;
        yield return new WaitForSeconds(CooldownFlash);
        GraphicsBase.material = MaterialStandard;
    }
    #endregion
}