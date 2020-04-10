using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneToPlayer : MonoBehaviour
{
    GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.parent = Player.transform;
            
            
            if (gameObject.tag == "RuneWow")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                GetComponent<RuneAttack1>().enabled = true;
            }

            if (gameObject.tag == "RuneValvran")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                GetComponent<RuneAttackValvran>().enabled = true;
            }
        }
    }
}
