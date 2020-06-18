﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternDarkElf : MonoBehaviour
{
    [Header("Reference for Material Base")]
    public Material MaterialStandard;
    public Material MaterialChange;
    public Renderer GraphicsBase;

    public Animator anim;
    public GameObject Player;
    public float desiredSpeed = 5f;
    public float CooldownForTrigger = 1f;
    public float CooldownAttack = 20f;
    public float CooldownFlash = 0.5f;

    bool isFirstActivate = true;
    bool isSecondActivate = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackLance());
    }

    // Update is called once per frame
    void Update()
    {
        anim.speed = desiredSpeed;
        if (ActivateEnemy.isRoom8DarkElf1 == true && isFirstActivate == true)            //Se isRoom3Valravn è vero e isFirstActivate è vero
        {
            if (this.name == "ValvranScript1")                                          //Se il nome dell'oggetto, cioè il proprio, è ValvranScript1
            {
                isFirstActivate = false;                                                //Setto isFirstActivate a falso
                this.GetComponent<PatternDarkElf>().enabled = true;                     //Attivo lo script
                StartCoroutine(AttackLance());                                           //Faccio partire la corutine dell'attacco
                ActivateEnemy.isRoom8DarkElf1 = false;                                   //Setto a falso la variabile di entrata per non farlo ciclare
            }
        }
        if (ActivateEnemy.isRoom8DarkElf2 == true && isSecondActivate == true)          //Se isRoom4Valravn2 è vero e isSecondActivate è vero
        {
            if (this.name == "ValvranScript2")                                          //Se il nome dell'oggetto, cioè il proprio, è ValvranScript1
            {
                isSecondActivate = false;                                               //Setto isSecondActivate a falso
                this.GetComponent<PatternDarkElf>().enabled = true;                     //Attivo lo script
                StartCoroutine(AttackLance());                                           //Faccio partire la corutine dell'attacco
                ActivateEnemy.isRoom8DarkElf2 = false;                                  //Setto a falso la variabile di entrata per non farlo ciclare
            }
        }
    }

    public IEnumerator AttackLance()
    {
        while(true)
        {
            StartCoroutine(Flash());
            transform.LookAt(Player.transform);
            anim.SetTrigger("ActiveAvanti");
            yield return new WaitForSeconds(CooldownForTrigger);
            anim.SetTrigger("ActiveDietro");
            yield return new WaitForSeconds(CooldownAttack);
        }
    }
    public IEnumerator Flash()
    {
        GraphicsBase.material = MaterialChange;
        yield return new WaitForSeconds(CooldownFlash);
        GraphicsBase.material = MaterialStandard;
    }
}
