using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
public class AlertAI : MonoBehaviour
{
    public GameObject AlertBody;
    public GameObject InvestigatorDestination;
    quaternion DestinationRot = new quaternion(0,0,0,0);
    public float AlertCooldown = 10f;
    void Update()
    {    
        AlertCooldown -= Time.deltaTime;
        if (AlertCooldown <= 0)
        {
            Alert();
        }
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float distance)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distance;
        randomDirection += origin;
        return randomDirection;
    }
    void Alert()
    {   
        Instantiate(InvestigatorDestination, RandomNavSphere(AlertBody.transform.position, 10f), DestinationRot);
        //Vector3 origin = AlertBody.transform.position;
        //Vector3 direction = AlertBody.transform.forward;
        //float radius = 100f;
        //float maxDistance = 9999f;
        //RaycastHit hit;
        //Debug.DrawRay(origin, radius * direction, Color.red, 5f);
        //if (Physics.SphereCast(origin, radius, direction, out hit, maxDistance))
        //{
            //Debug.Log("SphereCast hit: " + hit.transform.name);
        //}
        //else
        //{
            //Debug.Log("SphereCast did not hit anything.");
        //}

        AlertCooldown = 10f;
    }
}
// 
