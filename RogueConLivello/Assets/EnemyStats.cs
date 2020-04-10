using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health;
    public bool isBoss;
    public GameObject BossContainer;
    public GameObject RuneReference;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon" || other.gameObject.tag == "ShotPlayer")
        {
            health--;
            if(gameObject.tag == "Boss")
            {
                isBoss = true;
            }
        }
    }
    private void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            if (this.gameObject.name == "WillOfWisp1" || this.gameObject.name == "WillOfWisp2" || this.gameObject.name == "WillOfWisp3")
            {
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                rune.GetComponent<RuneAttack1>().enabled = false;
            }
            if(this.gameObject.name == "NavMeshValvran1" || this.gameObject.name == "Valvran2" || this.gameObject.name == "Valvran3")
            {
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                rune.GetComponent<RuneAttackValvran>().enabled = false;
            }
            #region Old
             //Quaternion rot = new Quaternion(0, 90, 0, 0);
            //GameObject rune = Instantiate(RuneReference, Player.transform.position, rot);
             //GameObject rune = Instantiate(RuneReference, transform.position, rot);
            //rune.tag = "RuneWow";
            //rune.transform.parent = Player.transform;
            #endregion
        }
        if (health == 0 && gameObject.tag == "Boss" && isBoss == true)
        {
            Destroy(BossContainer);
        }
    }
}
