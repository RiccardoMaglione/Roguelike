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

            #region Rune Wow
            if (gameObject.tag == "RuneWow")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                GetComponent<RuneAttack1>().enabled = true;
            }
            #endregion
            #region Rune Valvran
            if (gameObject.tag == "RuneValvran")
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
                GetComponent<RuneAttackValvran>().enabled = true;
            }
            #endregion
            #region Rune Gammur
            if (gameObject.tag == "RuneGammur")
            {
                if(EnemyStats.rangeGammur == 1)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                    GetComponent<RuneAttackGammurOne>().enabled = true;
                }
                if (EnemyStats.rangeGammur == 2)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                    GetComponent<RuneAttackGammurTwo>().enabled = true;
                }
                if (EnemyStats.rangeGammur == 3)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
                    GetComponent<RuneAttackGammurThree>().enabled = true;
                }
            }
            #endregion
        }
    }
}
