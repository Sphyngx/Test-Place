using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class InvestigateAI : MonoBehaviour
{
    GameObject Destination;
    public NavMeshAgent Agent;
    bool Waiting = true;

    void Update()
    {
        if (Destination == null)
        {
            Destination = GameObject.FindGameObjectWithTag("InvestigateDestination");
            if (Destination != null)
            {
                Waiting = false;
            }
        }

        if (!Waiting)
        {
            if (Destination != null)
            {
                Vector3 TrueDestination = Destination.transform.position;
                Agent.SetDestination(TrueDestination);
                Waiting = false;
            }
        }

        if (Agent.remainingDistance <= Agent.stoppingDistance)
        {
            Waiting = true;
        }
    }
}
