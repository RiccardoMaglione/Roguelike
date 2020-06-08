using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternYellowDeer : MonoBehaviour
{
    #region Variables
    [Header("Reference for Yellow Deer")]
    public GameObject Fireball;
    public GameObject DeerYellowContainer;

    [Header("Reference for Material Base")]
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsBase;
    
    [Header("General Reference")]
    public GameObject shadow;
    public int HeightAttack = 5;
    public float CooldownAttack = 3f;
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
        StartCoroutine(FireballAttack());
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
        //        StartCoroutine(FireballAttack());
        //        ActivateEnemy.isRoom2 = false;
        //    }
        //}
        #endregion
    }

    #region Pattern
    void SpawnFireball()
    {
        StartCoroutine(Flash());
        //FindObjectOfType<AudioManager>().Play("InsertNameSound", sfx);
        for (int i = 2; i < 6; i++)
        {
            GameObject go = Instantiate(Fireball, new Vector3(DeerYellowContainer.transform.localPosition.x, DeerYellowContainer.transform.localPosition.y + HeightAttack, DeerYellowContainer.transform.localPosition.z) + DeerYellowContainer.transform.forward * i, transform.rotation);
        }
    }
    #endregion

    #region IEnumerator Attack and Flash
    public IEnumerator FireballAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(CooldownAttack);
            SpawnFireball();
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