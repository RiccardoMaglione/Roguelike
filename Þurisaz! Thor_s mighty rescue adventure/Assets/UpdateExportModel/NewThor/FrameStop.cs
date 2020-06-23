using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameStop : MonoBehaviour
{
    Animator Anim;
    static public bool isIdle = false;

    void Start()
    {
        Anim = GetComponent<Animator>();
        Anim.Play("Idle", 0, 172);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            isIdle = false;
            StartCoroutine(AttackCiccia());
        }
        if (this.Anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && isIdle == true)
        {
            isIdle = false;
            Anim.Play("Idle", 0, 172);
        }
    }

    public IEnumerator AttackCiccia()
    {            
        PlayerManager.Frame = true;
        Anim.speed = 9f;
        Anim.SetBool("StartAttack", true);
        yield return new WaitForSeconds(0.5f);
        Anim.SetBool("StartAttack", false);
        isIdle = true;
    }
}
