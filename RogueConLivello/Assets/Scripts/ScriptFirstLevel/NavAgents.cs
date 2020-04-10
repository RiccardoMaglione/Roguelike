using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavAgents : MonoBehaviour
{
    public Transform goal1;
    public Transform goal2;
    public Transform goal3;
    public Transform goal4;
    NavMeshAgent agent;
    //public GameObject ChildValvran;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Path());
    }
    IEnumerator Path()
    {
        while(true)
        {
            yield return new WaitForSeconds((float)4f);
            //ChildValvran.transform.rotation = new Quaternion(ChildValvran.transform.rotation.y, transform.rotation.y, ChildValvran.transform.rotation.y, ChildValvran.transform.rotation.y);
            agent.destination = goal1.position;
            yield return new WaitForSeconds((float)4f);
            //ChildValvran.transform.rotation = new Quaternion(ChildValvran.transform.rotation.y, transform.rotation.y, ChildValvran.transform.rotation.y, ChildValvran.transform.rotation.y);
            agent.destination = goal2.position;
            yield return new WaitForSeconds((float)4f);
            //ChildValvran.transform.rotation = new Quaternion(ChildValvran.transform.rotation.y, transform.rotation.y, ChildValvran.transform.rotation.y, ChildValvran.transform.rotation.y);
            agent.destination = goal3.position;
            yield return new WaitForSeconds((float)4f);
            //ChildValvran.transform.rotation = new Quaternion(ChildValvran.transform.rotation.y, transform.rotation.y, ChildValvran.transform.rotation.y, ChildValvran.transform.rotation.y);
            agent.destination = goal4.position;
        }

    }
}
