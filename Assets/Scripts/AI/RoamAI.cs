using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class RoamAI : MonoBehaviour
{
    public VisionAI VisionAI;
    public NavMeshAgent agent;
    public int range = 75;
    public float WaitTimer = 2f;
    public bool IsStalking = false;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Roam());
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, NavMesh.AllAreas);

        return navHit.position;
    }

    public IEnumerator Roam()
    {
        bool Waiting = false;
        while (true)
        {
            if (!IsStalking)
            {
                if (!Waiting)
                {
                    Vector3 randomPoint = RandomNavSphere(gameObject.transform.position, range);
                    agent.SetDestination(randomPoint);
                    Waiting = true;
                }
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    yield return new WaitForSeconds(WaitTimer);
                    Waiting = false;
                }
                yield return null;
            }

        }
    }
}