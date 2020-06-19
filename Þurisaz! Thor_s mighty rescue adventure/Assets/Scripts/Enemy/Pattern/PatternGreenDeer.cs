using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternGreenDeer : MonoBehaviour
{
    #region Variables
    [Header("Reference for Green Deer")]
    public GameObject Spine;
    public GameObject DeerGreenContainer;

    [Header("Reference for Material Base")]
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsBase;

    [Header("General Reference")]
    public GameObject shadow;
    public float CooldownAttack = 6f;
    public float CooldownFlash = 0.5f;

    Transform target;

    bool isSix2Activate = true;
    bool isNineActivate = true;


    float sfx;
    #endregion

    private void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");            //Setto l'audio del cervo verde come sfx
    }
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //StartCoroutine(SpineAttack());
    }
    private void Update()
    {
        transform.LookAt(target);
        #region Enemy Control Room
        if (ActivateEnemy.isRoom9Green1 == true && isNineActivate == true)
        {
            if (this.name == "GreenScript1")
            {
                Debug.Log("Cervo 1 attivo");
                isNineActivate = false;
                this.GetComponent<PatternGreenDeer>().enabled = true;
                StartCoroutine(SpineAttack());
                ActivateEnemy.isRoom9Green1 = false;
            }
        }
        if (ActivateEnemy.isRoom6NewGreen1 == true && isSix2Activate == true)
        {
            if (this.name == "GreenScript2")
            {
                Debug.Log("Cervo 2 attivo");
                isSix2Activate = false;
                this.GetComponent<PatternGreenDeer>().enabled = true;
                StartCoroutine(SpineAttack());
                ActivateEnemy.isRoom6NewGreen1 = false;
            }
        }
        #endregion
    }

    #region Pattern
    void SpawnSpike()
    {
        StartCoroutine(Flash());
        //FindObjectOfType<AudioManager>().Play("InsertNameSound", sfx);
        for (int i = -2; i < 3; i++)
        {
            for (int j = -2; j < 3; j++)
            {
                GameObject go = Instantiate(Spine, new Vector3(transform.position.x + i, /*transform.position.y*/0, transform.position.z + j), Quaternion.identity);
                go.transform.parent = DeerGreenContainer.transform;
                if (go.transform.position.x == DeerGreenContainer.transform.position.x && go.transform.position.z == DeerGreenContainer.transform.position.z)
                    Destroy(go);
                Destroy(go, 3f);
            }
        }
        
    }
    #endregion

    #region IEnumerator Attack and Flash
    public IEnumerator SpineAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(CooldownAttack);
            SpawnSpike();
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