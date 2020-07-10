using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThorAnim : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(AttackCiccia());
        }
    }
    public IEnumerator AttackCiccia()
    {
        anim.SetBool("StartAttack", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("StartAttack", false);
    }
}
