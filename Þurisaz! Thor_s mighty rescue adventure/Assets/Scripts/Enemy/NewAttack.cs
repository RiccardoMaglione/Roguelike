using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAttack : MonoBehaviour
{
    public Collider[] hitColliders;
    public GameObject[] Player;


    void Attack(Vector3 center, float radius)                                                                            //metodo dell'attacco del valravn
    {
        hitColliders = Physics.OverlapSphere(center, radius);                                                            //il nemico spara il tornado
        foreach (Collider detectedCollider in hitColliders)
        {
            if (detectedCollider.tag == "Player")                                                                        //controlla se dentero all'area del tornado c'è il giocatore
            {
                Vector3 toTarget = (detectedCollider.transform.position - transform.position).normalized;           
                float dist = Vector3.Distance(detectedCollider.transform.localPosition, transform.localPosition);        //calcola la distanza del giocatore dal valravn
                float ris = Vector3.Dot(toTarget, transform.forward);                                                    //controlla se il giocatore sta avanti o dietro al nemico
                Debug.Log(dist);

                if (ris > 0)           //DAVANTI
                {                                                                                                               
                    detectedCollider.transform.Translate(-transform.forward * (dist + (4 - dist)));                   
                }             
            }
        }             
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
    }
 
    void Update()
    {
        transform.LookAt(Player[0].transform.position);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Attack(transform.position, 3f);
        }
        
    }
}
