using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDark : MonoBehaviour
{
    public Animator anim;
    public float blend = -1;
    public bool isActiveLance = false;
    public float timer = 0f;

    private void Start()
    {
        anim.Rebind();
        anim.SetFloat("Inizio", -1f);
    }

    private void Update()
    {
        anim.SetFloat("Inizio", -1);
        timer += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.L) && isActiveLance == false)
        {
            blend = 1;
            anim.SetFloat("Inizio",blend); 
            if (timer > 2f)
            {
                isActiveLance = true;
                Debug.Log("Sono quaaaaaaaaaaaaaaa");
                blend = -1;
                isActiveLance = false;
                timer = 0;
            }
        }
    }
}