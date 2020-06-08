using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternBlueDeer : MonoBehaviour
{
    #region Variables
    [Header("Reference for Blue Deer")]
    public GameObject Snowball;
    public GameObject DeerContainer;

    [Header("Reference for Material Base")]
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsBase;

    [Header("General Reference")]
    public GameObject shadow;
    public float CooldownAttack = 6f;
    public float CooldownFlash = 0.5f;

    Transform target;

    bool isFirstActivate = true;

    float sfx;
    #endregion

    private void Awake()
    {
        sfx = PlayerPrefs.GetFloat("SfxVolume");            //Setto l'audio del cervo verde come sfx
    }
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SnowballAttack());
    }
    private void Update()
    {
        transform.LookAt(target);
        #region Enemy Control Room
        //if (ActivateEnemy.isRoom2 == true && isFirstActivate == true)
        //{
        //    if (this.name == "WillOfWispScript1")
        //    {
        //        isFirstActivate = false;
        //        this.GetComponent<PatternGreenDeer>().enabled = true;
        //        StartCoroutine(SnowballAttack());
        //        ActivateEnemy.isRoom2 = false;
        //    }
        //}
        #endregion
    }

    #region Pattern
    void SpawnSnowball()
    {
        StartCoroutine(flash());
        //FindObjectOfType<AudioManager>().Play("InsertNameSound", sfx);
        GameObject go = Instantiate(Snowball, new Vector3(DeerContainer.transform.position.x, DeerContainer.transform.position.y, DeerContainer.transform.position.z), transform.rotation);
    }
    #endregion

    #region IEnumerator Attack and Flash
    public IEnumerator SnowballAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(CooldownAttack);
            SpawnSnowball();
        }
    }

    public IEnumerator flash()
    {
        GraphicsBase.material = MaterialChange;
        yield return new WaitForSeconds(CooldownFlash);
        GraphicsBase.material = MaterialStandard;
    }
    #endregion
}