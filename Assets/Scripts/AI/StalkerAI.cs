using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalkerAI : MonoBehaviour
{
    public VisionAI VisionAI;
    public RoamAI RoamAI;
    public GameObject Player;
    public float Radius;
    public int Segments;


    void Start()
    {
        VisionAI = GetComponent<VisionAI>();
        RoamAI = GetComponent<RoamAI>();
    }

    void Update()
    {
        if (VisionAI != null && VisionAI.SeeingPlayer)
        {
            Stalk();
        }
        else if (RoamAI != null)
        {
            RoamAI.IsStalking = false;
        }
    }

    void Stalk()
    {
        if (RoamAI != null)
        {
            RoamAI.IsStalking = true;
        }
        DrawCircle(Player.transform.position, Radius);

    }

    void DrawCircle(Vector3 center, float radius)
    {
        float angleStep = 360f / Segments;
        Vector3 prevPoint = center + new Vector3(Radius, 0, 0);
        Vector3[] NewPoint = new Vector3[Segments];
        for (int i = 1; i <= Segments; i++)
        {
            float angle = i * angleStep;
            float rad = Mathf.Deg2Rad * angle;

            NewPoint[i] = center + new Vector3(Mathf.Cos(rad) * Radius, 0, Mathf.Sin(rad) * Radius);

            Physics.Linecast(prevPoint, NewPoint[i]);

            prevPoint = NewPoint[i];
        }
        // create a random position on the linecast:
        RoamAI.agent.ResetPath();
        RoamAI.agent.SetDestination(NewPoint[Random.Range(0, NewPoint.Length)]);

    }


    private void OnDrawGizmos()
    {

        if (Player == null) return;

        Vector3 center = Player.transform.position;

        float angleStep = 360f / Segments;
        Vector3 prevPoint = center + new Vector3(Radius, 0, 0);

        for (int i = 1; i <= Segments; i++)
        {
            float angle = i * angleStep;
            float rad = Mathf.Deg2Rad * angle;

            Vector3 newPoint = center + new Vector3(Mathf.Cos(rad) * Radius, 0, Mathf.Sin(rad) * Radius);

            Gizmos.color = Color.green;
            Gizmos.DrawLine(prevPoint, newPoint);

            prevPoint = newPoint;
        }
    }
}