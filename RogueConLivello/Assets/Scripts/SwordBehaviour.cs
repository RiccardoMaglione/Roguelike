using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    int health = 0;
    public GameObject RuneReference;
    public Transform startAttack;
    public Transform finishAttack;
    float speed = 0.5f;
    public bool attack = false;

    private void Start()
    {
        gameObject.tag = "NotWeapon";
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy")
    //    {
    //        Destroy(other.gameObject);
    //        GameObject rune = Instantiate(RuneReference, transform.position, transform.rotation);
    //    }
    //    if (other.gameObject.tag == "Boss")
    //    {
    //        health++;
    //        Debug.Log(health);
    //        if (health == 3)
    //        {
    //            Destroy(other.gameObject);
    //            GameObject rune = Instantiate(RuneReference, transform.position, transform.rotation);
    //            health = 0;
    //        }
    //    }
    //}

    private void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && attack == false)
        {
            this.transform.Rotate(0, 0, -75);
            gameObject.tag = "Weapon";
            attack = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space) && attack == true)
        {       
            this.transform.Rotate(0, 0, 75);
            gameObject.tag = "NotWeapon";
            attack = false;
        }
    }    
}
