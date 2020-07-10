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
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if(this.gameObject.name == "WillOfWisp4")
        {
            StartCoroutine(PathWow());
        }
        else if (this.gameObject.name == "WillOfWisp5")
        {
            StartCoroutine(PathWow());
        }
        else if (this.gameObject.name == "Valvran4")
        {
            StartCoroutine(PathWow());
        }
        else
        {
            StartCoroutine(Path());
        }
    }
    IEnumerator Path()
    {
        while(true)
        {
            yield return new WaitForSeconds((float)4f);
            agent.destination = goal1.position;
            yield return new WaitForSeconds((float)5f);
            agent.destination = goal2.position;
            yield return new WaitForSeconds((float)4f);
            agent.destination = goal3.position;
            yield return new WaitForSeconds((float)5f);
            agent.destination = goal4.position;
        }
    }
    IEnumerator PathWow()
    {
        while (true)
        {
            yield return new WaitForSeconds((float)4f);
            agent.destination = goal1.position;
            yield return new WaitForSeconds((float)4f);
            agent.destination = goal2.position;
        }
    }
}