using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int health;
    public bool isBoss;
    public GameObject BossContainer;
    public GameObject RuneReference;
    public GameObject RuneBossGammur;
    public GameObject Player;
    public static int rangeGammur;
    //public static int rangeBergrisi;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon" || other.gameObject.tag == "ShotPlayer" || other.gameObject.tag == "Spike" || other.gameObject.tag == "EggPlayer" || other.gameObject.tag == "EggcrackerPlayer")
        {
            if(other.gameObject.tag == "EggPlayer" || other.gameObject.tag == "EggcrackerPlayer")
            {
                Destroy(other.gameObject);
            }
            health--;
            if(gameObject.tag == "Boss")
            {
                isBoss = true;
            }
        }
    }
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);

            #region WillOWisp
            if (this.gameObject.name == "WillOfWisp1" || this.gameObject.name == "WillOfWisp2" || this.gameObject.name == "WillOfWisp3")
            {
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                rune.GetComponent<RuneAttack1>().enabled = false;
            }
            #endregion
            #region Valvran
            if (this.gameObject.name == "NavMeshValvran1" || this.gameObject.name == "Valvran2" || this.gameObject.name == "Valvran3")
            {
                Quaternion rot = new Quaternion(0, 90, 0, 0);
                GameObject rune = Instantiate(RuneReference, transform.position, rot);
                rune.GetComponent<RuneAttackValvran>().enabled = false;
            }
            #endregion
            #region Odin's Eye
            //if (this.gameObject.name == "" || this.gameObject.name == "" || this.gameObject.name == "")
            //{
            //    Quaternion rot = new Quaternion(0, 90, 0, 0);
            //    GameObject rune = Instantiate(RuneReference, transform.position, rot);
            //    rune.GetComponent<RuneAttackOdinsEye>().enabled = false;
            //}
            #endregion
            #region Yggdrasil Deer
            //if (this.gameObject.name == "" || this.gameObject.name == "" || this.gameObject.name == "")
            //{
            //    Quaternion rot = new Quaternion(0, 90, 0, 0);
            //    GameObject rune = Instantiate(RuneReference, transform.position, rot);
            //    rune.GetComponent<RuneAttackYggradsilDeer>().enabled = false;
            //}
            #endregion
            #region Gullinbursti
            //if (this.gameObject.name == "" || this.gameObject.name == "" || this.gameObject.name == "")
            //{
            //    Quaternion rot = new Quaternion(0, 90, 0, 0);
            //    GameObject rune = Instantiate(RuneReference, transform.position, rot);
            //    rune.GetComponent<RuneAttackGullinbursti>().enabled = false;
            //}
            #endregion
            #region Darkelf
            //if (this.gameObject.name == "" || this.gameObject.name == "" || this.gameObject.name == "")
            //{
            //    Quaternion rot = new Quaternion(0, 90, 0, 0);
            //    GameObject rune = Instantiate(RuneReference, transform.position, rot);
            //    rune.GetComponent<RuneAttackDarkelf>().enabled = false;
            //}
            #endregion
            #region Draugr
            //if (this.gameObject.name == "" || this.gameObject.name == "" || this.gameObject.name == "")
            //{
            //    Quaternion rot = new Quaternion(0, 90, 0, 0);
            //    GameObject rune = Instantiate(RuneReference, transform.position, rot);
            //    rune.GetComponent<RuneAttackDraugr>().enabled = false;
            //}
            #endregion

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
            #region Gammur
            if (this.gameObject.name == "3D_boss_gammur")
            {
                rangeGammur = Random.Range(1,4);
                switch (rangeGammur)
                {
                    case 1:
                        {
                            Quaternion rot = new Quaternion(0, 90, 0, 0);
                            Vector3 pot = new Vector3(37, 0.5f, -1);
;                           GameObject rune = Instantiate(RuneBossGammur, pot, rot);
                            rune.GetComponent<RuneAttackGammurOne>().enabled = false;
                            rune.GetComponent<RuneAttackGammurTwo>().enabled = false;
                            rune.GetComponent<RuneAttackGammurThree>().enabled = false;
                            break;
                        }
                    case 2:
                        {
                            Quaternion rot = new Quaternion(0, 0, 0, 0);
                            Vector3 pot = new Vector3(37, 0.5f, -1);
                            GameObject rune = Instantiate(RuneBossGammur, pot, rot);
                            rune.GetComponent<RuneAttackGammurOne>().enabled = false;
                            rune.GetComponent<RuneAttackGammurTwo>().enabled = false;
                            rune.GetComponent<RuneAttackGammurThree>().enabled = false;
                            break;
                        }
                    case 3:
                        {
                            Quaternion rot = new Quaternion(0, 0, 0, 0);
                            Vector3 pot = new Vector3(37, 0.5f, -1);
                            GameObject rune = Instantiate(RuneBossGammur, pot, rot);
                            rune.GetComponent<RuneAttackGammurOne>().enabled = false;
                            rune.GetComponent<RuneAttackGammurTwo>().enabled = false;
                            rune.GetComponent<RuneAttackGammurThree>().enabled = false;
                            break;
                        }
                    default:
                        break;
                }

            }
            #endregion
            #region Bergrisi
            //if (this.gameObject.name == "Bergrisi")
            //{
            //    int range = Random.Range(1, 4);
            //    switch (range)
            //    {
            //        case 1:
            //            {
            //                Quaternion rot = new Quaternion(0, 90, 0, 0);
            //                GameObject rune = Instantiate(RuneBossGammur, transform.position, rot);
            //                rune.GetComponent<RuneAttackBergrisiOne>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiTwo>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiThree>().enabled = false;
            //                break;
            //            }
            //        case 2:
            //            {
            //                Quaternion rot = new Quaternion(0, 90, 0, 0);
            //                GameObject rune = Instantiate(RuneBossGammur, transform.position, rot);
            //                rune.GetComponent<RuneAttackBergrisiOne>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiTwo>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiThree>().enabled = false;
            //                break;
            //            }
            //        case 3:
            //            {
            //                Quaternion rot = new Quaternion(0, 90, 0, 0);
            //                GameObject rune = Instantiate(RuneBossGammur, transform.position, rot);
            //                rune.GetComponent<RuneAttackBergrisiOne>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiTwo>().enabled = false;
            //                rune.GetComponent<RuneAttackBergrisiThree>().enabled = false;
            //                break;
            //            }
            //        default:
            //            break;
            //    }
            //
            //}
            #endregion
        }
    }
}
