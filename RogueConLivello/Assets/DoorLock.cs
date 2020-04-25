using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorLock : MonoBehaviour
{
    public GameObject EntranceDoor;
    public GameObject ExitDoor;

    public GameObject EntranceCollider;
    public GameObject ExitCollider;

    public GameObject PrecedentColliderA;
    public GameObject PrecedentColliderD;
    //public static List<Collider> EnemyList = new List<Collider>();
    //bool DoorActive = false;
    //public static bool isEmptyList = false;
    //public static int EnemyNumber = 0;
    //Collider[] hitColliders;
    bool isFirst = true;

    private void Start()
    {
        EntranceDoor.SetActive(false);
        ExitDoor.SetActive(false);
        EntranceCollider.SetActive(false);
        ExitCollider.SetActive(false);
        PrecedentColliderA.SetActive(true);
        PrecedentColliderD.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isFirst == true)
        {
            isFirst = false;
            EntranceDoor.SetActive(true);
            ExitDoor.SetActive(true);
            EntranceCollider.SetActive(true);
            ExitCollider.SetActive(true);
            PrecedentColliderA.SetActive(false);
            PrecedentColliderD.SetActive(false);
            //DoorActive = true;
            //EnemyNumber = 0;
        }
    }

    private void Update()
    {
        //if (DoorActive == true)
        //{
        //    EnemyNumber = 0;
        //    EnemyList.Clear();
        //    DoorActive = false;
        //    hitColliders = Physics.OverlapBox(this.transform.position, new Vector3(this.transform.localScale.x * 1.5f, this.transform.localScale.y, this.transform.localScale.z), Quaternion.identity);
        //    foreach (Collider detectedCollider in hitColliders)
        //    {
        //        if (detectedCollider.tag == "Enemy")
        //        {
        //            if (this.gameObject.name == "ColliderPorteRoom2")
        //            {
        //                EnemyList.Add(detectedCollider);
        //                print("Enemy iniziali " + EnemyList.Count);
        //                EnemyNumber = EnemyList.Count;
        //            }
        //            if (this.gameObject.name == "ColliderPorteRoom3")
        //            {
        //                EnemyList.Add(detectedCollider);
        //                print("Enemy iniziali " + (EnemyList.Count - 1));
        //                EnemyNumber = (EnemyList.Count - 1);
        //            }
        //            if (this.gameObject.name == "ColliderPorteRoom4")
        //            {
        //                EnemyList.Add(detectedCollider);
        //                print("Enemy iniziali " + EnemyList.Count);
        //                EnemyNumber = EnemyList.Count;
        //            }
        //            if (this.gameObject.name == "ColliderPorteRoom5")
        //            {
        //                EnemyList.Add(detectedCollider);
        //                print("Enemy iniziali " + EnemyList.Count);
        //                EnemyNumber = EnemyList.Count;
        //            }
        //            if (EnemyList != null)
        //            {
        //                EntranceDoor.SetActive(true);
        //                ExitDoor.SetActive(true);
        //            }
        //        }
        //    }
        //}
        //if (EnemyNumber <= 0)
        //{
        //    EnemyList.Clear();
        //    Array.Clear(hitColliders, 0, hitColliders.Length);
        //    EnemyNumber = EnemyList.Count;
        //    print("Enemy finale" + EnemyList.Count);
        //    EntranceDoor.SetActive(false);
        //    ExitDoor.SetActive(false);
        //    Destroy(this.gameObject);
        //}
    }
    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = new Color(1, 0, 0, 0.5f);
    //    Gizmos.DrawWireCube(this.transform.position, new Vector3(this.transform.localScale.x * 1.5f, this.transform.localScale.y, this.transform.localScale.z));
    //}
}
