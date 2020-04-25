using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPorte : MonoBehaviour
{
    public float thickness = 7f;
    bool isActive = true;
    int n = 0;
    int j = 0;
    public GameObject Door1;
    public GameObject Door2;
    public GameObject Door1Collider;
    public GameObject Door2Collider;
    public GameObject PrecedentColliderA;
    public GameObject PrecedentColliderD;
    private void Start()
    {
        n = 0;
        if(isActive == true)
        {
            Collider[] EnemyInRoom = Physics.OverlapSphere(transform.position, thickness);
            isActive = false;
            foreach (Collider other in EnemyInRoom)
            {
                if(other.gameObject.tag == "Enemy")
                {
                    n++;
                }
            }
            print("Ci sono " + n + " nemici");
        }
    }

    private void Update()
    {
        CheckEnemy();
        if(n == 0)
        {
            print("Non ci sono più nemici nella stanza");
            Door1.SetActive(false);
            Door2.SetActive(false);
            Door1Collider.SetActive(false);
            Door2Collider.SetActive(false);
            PrecedentColliderA.SetActive(true);
            PrecedentColliderD.SetActive(true);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawWireSphere(transform.position, thickness);
    }


    void CheckEnemy()
    {
        int j = 0;
        Collider[] EnemyInRoom = Physics.OverlapSphere(transform.position, thickness);
        foreach (Collider other in EnemyInRoom)
        {
            if (other.gameObject.tag == "Enemy")
            {
                j++;
            }
        }
        print("Ci sono ancora " + j + " nemici");
        n = j;
    }

}
