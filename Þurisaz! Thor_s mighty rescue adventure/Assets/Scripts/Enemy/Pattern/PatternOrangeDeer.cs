using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternOrangeDeer : MonoBehaviour
{
    #region Variables
    [Header("Reference for Orange Deer")]
    public GameObject DeerOrangeContainer;
    public int windSpeed = 10;
    
    [Header("Reference for Material Base")]
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsBase;
    
    [Header("General Reference")]
    public GameObject[] Player;
    public float CooldownAttack = 6f;
    public float CooldownFlash = 0.5f;

    Transform target;
    
    bool isFinishAttack = true;
    bool isFirstActivate = true;
    
    float sfx;
    #endregion

    private void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");            //Setto l'audio del cervo verde come sfx
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(WindAttack());
    }
    private void Update()
    {
        transform.LookAt(Player[0].transform);
        if(isFinishAttack == true)
        {
            StartCoroutine(WindAttack());
        }
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

    #region IEnumerator Attack and Flash
    IEnumerator SpawnWind()
    {
        StartCoroutine(Flash());
        //FindObjectOfType<AudioManager>().Play("InsertNameSound", sfx);
        Collider[] hitColliders = Physics.OverlapBox(new Vector3(DeerOrangeContainer.transform.localPosition.x, DeerOrangeContainer.transform.localPosition.y, DeerOrangeContainer.transform.localPosition.z), new Vector3(transform.localScale.x * 3 / 2, transform.localScale.y, transform.localScale.z * 9 / 2), transform.rotation);
        foreach (Collider detectedCollider in hitColliders)
        {
            if (detectedCollider.tag == "Player")
            {
                Player[0].GetComponent<Rigidbody>().isKinematic = false;
                Player[0].GetComponent<Rigidbody>().AddForce(DeerOrangeContainer.transform.forward * windSpeed);
                yield return new WaitForSeconds(3);
                Player[0].GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    IEnumerator WindAttack()
    {
        isFinishAttack = false;
        StartCoroutine(SpawnWind());
        yield return new WaitForSeconds(CooldownAttack);
        isFinishAttack = true;
    }

    public IEnumerator Flash()
    {
        GraphicsBase.material = MaterialChange;
        yield return new WaitForSeconds(CooldownFlash);
        GraphicsBase.material = MaterialStandard;
    }
    #endregion

    #region Gizmos for Area
    void OnDrawGizmosSelected()
    {
        Color prevColor = Gizmos.color;
        Matrix4x4 prevMatrix = Gizmos.matrix;
        
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.matrix = transform.localToWorldMatrix;
        
        //Vector3 boxPosition = new Vector3(11, DeerContainer.transform.localPosition.y, -26);
        Vector3 boxPosition = new Vector3(DeerOrangeContainer.transform.localPosition.x, DeerOrangeContainer.transform.localPosition.y, DeerOrangeContainer.transform.localPosition.z);

        // convert from world position to local position 
        boxPosition = transform.InverseTransformPoint(boxPosition);
        
        Vector3 boxSize = new Vector3(transform.localScale.x * 3, transform.localScale.y, transform.localScale.z * 9);
        Gizmos.DrawWireCube(boxPosition, boxSize);
        
        // restore previous Gizmos settings
        Gizmos.color = prevColor;
        Gizmos.matrix = prevMatrix;

        //Gizmos.color = new Color(1, 0, 0, 0.5f);
        //Gizmos.DrawWireCube(new Vector3(DeerContainer.transform.localPosition.x, DeerContainer.transform.localPosition.y, DeerContainer.transform.localPosition.z), new Vector3(transform.localScale.x * 3, transform.localScale.y, transform.localScale.z * 9));
    }
    #endregion
}