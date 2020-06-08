using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackLance());
    }

    // Update is called once per frame
    void Update()
    {
        anim.speed = desiredSpeed;
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
